using DietPlanner.DataAccess;
using DietPlanner.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DietPlanner
{
    internal class PlanGenerator
    {
        private readonly Plan plan;

        public Plan Plan => plan;

        // Lists for dietary entities
        private List<FoodCategory> foodCategoriesAllowed, foodCategoriesPreferred, foodCategoriesAvoided;
        private List<Food> foodsAllowed, foodsPreferred, foodsAvoided;
        private List<Meal> mealsAllowed, mealsPreferred, mealsAvoided;
        private List<MealType> mealTypesAllowed, mealTypesPreferred, mealTypesAvoided;

        // Specific meal types
        private readonly MealType breakfast, lunch, dinner, snack, dessert, cheatMeal;

        // Dictionary for meal type weights
        private Dictionary<MealType, int> mealTypeWeights;

        // Other parameters
        private List<Meal> mealsSelectedForDay = new List<Meal>();
        private readonly int daysInPlan = 7;
        private readonly int mealsPerDay = 6;
        private readonly double dailyCalorieGoal;
        private readonly int calorieDeficit = 500;
        private readonly int calorieSurplus = 500;
        private readonly float[] possibleMealItemQuantities = { 0.5f, 1.0f, 1.5f, 2.0f };
        private double preferredMealProbability = 0.66;
        private List<int> dessertDays = new List<int> { };
        private int dessertTime = 4;
        private int cheatMealDay = 0;
        private int cheatMealTime = 5;

        public PlanGenerator(Patient patient)
        {
            plan = new Plan()
            {
                Patient = patient,
                MealsPerDay = mealsPerDay,
            };

            // Initialization
            breakfast = DietaryEntityData.GetMealTypeByName("Breakfast");
            lunch = DietaryEntityData.GetMealTypeByName("Lunch");
            dinner = DietaryEntityData.GetMealTypeByName("Dinner");
            snack = DietaryEntityData.GetMealTypeByName("Snack");
            dessert = DietaryEntityData.GetMealTypeByName("Dessert");
            cheatMeal = DietaryEntityData.GetMealTypeByName("Cheat Meal");

            InitializeMealTypeWeights();

            DetermineAvoidedEntities(patient);
            DetermineAllowedEntities();
            DeterminePreferredEntities(patient);
            
            dailyCalorieGoal = CalculateDailyCalorieGoal(patient);

            AdjustParametersBasedOnMealTypes();

            PrintAllLists();

            GeneratePlan();
        }

        #region Initialization methods

        private void InitializeMealTypeWeights()
        {
            mealTypeWeights = new Dictionary<MealType, int>()
            {
                { breakfast, 2 }, { lunch, 2 }, { dinner, 2 }, { snack, 1 }, { dessert, 1 }, { cheatMeal, 2 }
            };
        }

        private void DetermineAvoidedEntities(Patient patient)
        {
            foodCategoriesAvoided = DetermineFoodCategoriesToAvoid(patient);
            foodsAvoided = DetermineFoodsToAvoid(patient);
            mealsAvoided = DetermineMealsToAvoid(patient);
            mealTypesAvoided = DetermineMealTypesToAvoid(patient);
        }

        private void DetermineAllowedEntities()
        {
            foodCategoriesAllowed = DetermineAllowedFoodCategories();
            foodsAllowed = DetermineAllowedFoods();
            mealTypesAllowed = DetermineAllowedMealTypes();
            mealsAllowed = DetermineAllowedMeals();
        }

        private void DeterminePreferredEntities(Patient patient)
        {
            foodCategoriesPreferred = DeterminePreferredFoodCategories(patient);
            foodsPreferred = DeterminePreferredFoods(patient);
            mealTypesPreferred = DeterminePreferredMealTypes(patient);
            mealsPreferred = DeterminePreferredMeals(patient);
        }

        // Methods to determine allowed, preferred, and avoided entities

        private List<FoodCategory> DetermineFoodCategoriesToAvoid(Patient patient)
        {
            return patient.FoodsToAvoid.OfType<FoodCategory>().ToList();
        }

        private List<Food> DetermineFoodsToAvoid(Patient patient)
        {
            return patient.FoodsToAvoid.OfType<Food>().ToList();
        }

        private List<Meal> DetermineMealsToAvoid(Patient patient)
        {
            return patient.FoodsToAvoid.OfType<Meal>().ToList();
        }

        private List<MealType> DetermineMealTypesToAvoid(Patient patient)
        {
            return patient.FoodsToAvoid.OfType<MealType>().ToList();
        }

        private List<FoodCategory> DetermineAllowedFoodCategories()
        {
            var allowedCategories = new List<FoodCategory>();
            AddNode(DietaryEntityData.GetFoodCategoryTree());
            return allowedCategories;

            void AddNode(FoodCategory category)
            {
                if (!foodCategoriesAvoided.Contains(category))
                {
                    allowedCategories.Add(category);
                    foreach (var subCategory in category.SubCategories)
                    {
                        AddNode(subCategory);
                    }
                }
            }
        }

        private List<Food> DetermineAllowedFoods()
        {
            return DietaryEntityData.GetAllFoodsList()
                .Where(food => foodCategoriesAllowed.Contains(food.Category))
                .Where(food => !foodsAvoided.Contains(food))
                .ToList();
        }

        private List<MealType> DetermineAllowedMealTypes()
        {
            return DietaryEntityData.GetAllMealTypesList().Where(type => !mealTypesAvoided.Contains(type)).ToList();
        }

        private List<Meal> DetermineAllowedMeals()
        {
            return DietaryEntityData.GetAllMealsList()
                .Where(meal => meal.Ingredients.All(ingredient => foodsAllowed.Contains(ingredient.Key)))
                .Where(meal => mealTypesAllowed.Contains(meal.Type))
                .Where(meal => !mealsAvoided.Contains(meal))
                .ToList();
        }

        private List<FoodCategory> DeterminePreferredFoodCategories(Patient patient)
        {
            List<FoodCategory> preferredList = patient.PreferredFoods.OfType<FoodCategory>().ToList();
            List<FoodCategory> preferredAndDescendants = new List<FoodCategory>();

            SearchForPreferredCategory(DietaryEntityData.GetFoodCategoryTree());

            foodCategoriesAllowed = foodCategoriesAllowed.Union(preferredAndDescendants).ToList();

            return preferredAndDescendants;

            void SearchForPreferredCategory(FoodCategory category)
            {
                if (preferredList.Contains(category))
                {
                    AddCategoryAndDescendants(category);
                }
                else
                {
                    foreach (var subCategory in category.SubCategories)
                    {
                        SearchForPreferredCategory(subCategory);
                    }
                }
            }

            void AddCategoryAndDescendants(FoodCategory category)
            {
                if (category != null)
                {
                    preferredAndDescendants.Add(category);
                }

                foreach (var subCategory in category.SubCategories)
                {
                    AddCategoryAndDescendants(subCategory);
                }
            }
        }

        private List<Food> DeterminePreferredFoods(Patient patient)
        {
            List<Food> foodsPreferred = patient.PreferredFoods.OfType<Food>().ToList();

            List<Food> foodsPreferredFromCategories = foodsAllowed
                .Where(food => foodCategoriesPreferred.Contains(food.Category))
                .ToList();

            List<Food> combinedFoodsPreferred = foodsPreferred.Union(foodsPreferredFromCategories).ToList();

            foodsAllowed = foodsAllowed.Union(combinedFoodsPreferred).ToList();

            return combinedFoodsPreferred;
        }

        private List<MealType> DeterminePreferredMealTypes(Patient patient)
        {
            return patient.PreferredFoods.OfType<MealType>().ToList();
        }

        private List<Meal> DeterminePreferredMeals(Patient patient)
        {
            List<Meal> mealsPreferred = patient.PreferredFoods.OfType<Meal>().ToList();

            List<Meal> mealsPreferredFromFoods = DietaryEntityData.GetAllMealsList()
                .Where(meal => meal.Ingredients.Keys.Any(key => foodsPreferred.Contains(key)))
                .ToList();

            List<Meal> mealsPreferredFromMealTypes = mealsAllowed
                .Where(meal => mealTypesPreferred.Contains(meal.Type))
                .ToList();

            List<Meal> combinedMealsPreferred = mealsPreferred
                .Union(mealsPreferredFromFoods)
                .Union(mealsPreferredFromMealTypes)
                .ToList();

            mealsAllowed = mealsAllowed.Union(combinedMealsPreferred).ToList();

            return combinedMealsPreferred;
        }

        // Other methods

        private double CalculateDailyCalorieGoal(Patient patient)
        {
            double dailyGoal = patient.TDEE;

            if (patient.Goal == Goal.Values[Goal.LOSE_WEIGHT])
            {
                dailyGoal -= calorieDeficit;
            }
            else if (patient.Goal == Goal.Values[Goal.GAIN_WEIGHT])
            {
                dailyGoal += calorieSurplus;
            }

            return dailyGoal;
        }

        private void AdjustParametersBasedOnMealTypes()
        {
            if (mealTypesAllowed.Contains(dessert))
            {
                dessertDays = new List<int> { 5 };
            }
            if (mealTypesPreferred.Contains(dessert))
            {
                dessertDays = new List<int> { 1, 3, 5 };
            }
            if (mealTypesPreferred.Contains(cheatMeal))
            {
                cheatMealDay = 6;
            }
        }

        #endregion

        #region Plan Generation methods

        private void GeneratePlan()
        {
            for (int day = 1; day <= daysInPlan; day++)
            {
                GenerateDayPlan(day);
            }
        }

        private void GenerateDayPlan(int day)
        {
            double remainingCalories = dailyCalorieGoal;
            int remainingWeightedMeals = 9;
            mealsSelectedForDay.Clear();

            Shuffle(mealsAllowed);
            Shuffle(mealsPreferred);

            for (int time = 1; time <= mealsPerDay; time++)
            {
                MealType mealType = GetMealTypeForTime(day, time);

                Meal selectedMeal = SelectMealOfType(mealType);

                float quantity = CalculateQuantityForMeal(selectedMeal, remainingCalories, remainingWeightedMeals);

                plan.MealPlan.Add(new MealItem(selectedMeal, quantity, day, time));

                mealsSelectedForDay.Add(selectedMeal);

                remainingCalories -= selectedMeal.Calories * quantity;
                remainingWeightedMeals -= mealTypeWeights[selectedMeal.Type];
            }
        }

        private Meal SelectMealOfType(MealType mealType)
        {
            Random random = new Random();

            List<Meal> preferredMealsForType = mealsPreferred.Where(meal => meal.Type == mealType).ToList();

            // Prioritize preferred meals by giving it an appearance boost
            if (random.NextDouble() < preferredMealProbability && preferredMealsForType.Any())
            {
                Meal selectedPreferredMeal = SelectNonRepeatedMeal(preferredMealsForType);
                if (selectedPreferredMeal != null)
                {
                    return selectedPreferredMeal;
                }
            }

            // Select any allowed meal
            List<Meal> mealsForType = mealsAllowed.Where(meal => meal.Type == mealType).ToList();
            Meal selectedMeal;

            if (mealsForType.Any())
            {
                selectedMeal = SelectNonRepeatedMeal(mealsForType);
                if (selectedMeal == null)
                {
                    selectedMeal = mealsForType[random.Next(mealsForType.Count)];
                }
            }
            else
            {
                selectedMeal = mealsAllowed[random.Next(mealsAllowed.Count)];
            }

            return selectedMeal;
        }

        private Meal SelectNonRepeatedMeal(List<Meal> mealsForType)
        {
            return mealsForType.FirstOrDefault(meal => !mealsSelectedForDay.Contains(meal));
        }

        private MealType GetMealTypeForTime(int day, int time)
        {
            if (dessertDays.Contains(day) && time == dessertTime)
            {
                return dessert;
            }
            if (cheatMealDay == day && cheatMealTime == time)
            {
                return cheatMeal;
            }

            switch (time)
            {
                case 1:
                    return breakfast;
                case 3:
                    return lunch;
                case 5:
                    return dinner;
                default:
                    return snack;
            }
        }

        private float CalculateQuantityForMeal(Meal meal, double remainingCalories, int remainingWeightedMeals)
        {
            float quantity = 1f;
            double calorieTarget = remainingCalories / remainingWeightedMeals * mealTypeWeights[meal.Type];

            double minDiff = int.MaxValue;
            foreach (var possibleQuantity in possibleMealItemQuantities)
            {
                double diff = Math.Abs(possibleQuantity * meal.Calories - calorieTarget);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    quantity = possibleQuantity;
                }
            }
            return quantity;
        }

        // Fisher-Yates shuffle algorithm
        private void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion

        #region Printing methods

        private void PrintList<T>(string title, List<T> list) where T : DietaryEntity
        {
            Console.WriteLine(title);
            Console.WriteLine("===========================================");
            foreach (var entity in list)
            {
                Console.WriteLine("-" + entity.Name);
            }
            Console.WriteLine();
        }

        private void PrintAllLists()
        {
            PrintList("Food Categories Allowed:", foodCategoriesAllowed);
            PrintList("Food Categories Preferred:", foodCategoriesPreferred);
            PrintList("Food Categories Avoided:", foodCategoriesAvoided);

            PrintList("Foods Allowed:", foodsAllowed);
            PrintList("Foods Preferred:", foodsPreferred);
            PrintList("Foods Avoided:", foodsAvoided);

            PrintList("Meals Allowed:", mealsAllowed);
            PrintList("Meals Preferred:", mealsPreferred);
            PrintList("Meals Avoided:", mealsAvoided);

            PrintList("Meal Types Allowed:", mealTypesAllowed);
            PrintList("Meal Types Preferred:", mealTypesPreferred);
            PrintList("Meal Types Avoided:", mealTypesAvoided);
        }

        private void PrintPlan()
        {
            Console.WriteLine($"Plan for Patient ID: {plan.Patient.PatientID}");
            Console.WriteLine("===========================================");
            Console.WriteLine($"Daily Calorie Goal: {dailyCalorieGoal} kcal");
            Console.WriteLine();

            for (int day = 1; day <= 7; day++)
            {
                float totalCaloriesForDay = 0;

                Console.WriteLine($"Day {day}:");
                Console.WriteLine("-------------------------------------------");

                for (int timeOfDay = 1; timeOfDay <= 6; timeOfDay++)
                {
                    var mealItem = plan.MealPlan.FirstOrDefault(item => item.Day == day && item.TimeOfDay == timeOfDay);
                    if (mealItem != null)
                    {
                        float mealCalories = mealItem.Meal.Calories * mealItem.Quantity;
                        totalCaloriesForDay += mealCalories;

                        Console.WriteLine($"Time of Day: {mealItem.Meal.Type.Name}");
                        Console.WriteLine($"Meal: {mealItem.Meal.Name} (Quantity: {mealItem.Quantity})");
                        Console.WriteLine($"Calories: {mealCalories} kcal");
                        Console.WriteLine("Ingredients:");
                        foreach (var ingredient in mealItem.Ingredients)
                        {
                            Console.WriteLine($"- {ingredient.Key.Name}: {ingredient.Value * ingredient.Key.Quantity} {ingredient.Key.Unit}");
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine($"Total Calories for Day {day}: {totalCaloriesForDay} kcal");
                Console.WriteLine();
            }
        }

        #endregion
    }
}
