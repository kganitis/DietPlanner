using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DAO
{
    internal class PlanDAOImp : IPlanDAO
    {
        public bool Save (Plan plan)
        {
            bool success = false;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First clear any existing _plan for the patient
                string query = "DELETE FROM Plan WHERE Patient_id = @patientID";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", plan.Patient.PatientID);

                command.ExecuteNonQuery();

                // Insert new _plan data
                foreach (var mealItem in plan.MealPlan)
                {
                    query = "INSERT INTO Plan (Patient_id, Day, Time_of_day, Meal_id, Quantity) VALUES (@patientID, @day, @time, @mealID, @quantity)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientID", plan.Patient.PatientID);
                    command.Parameters.AddWithValue("@day", mealItem.Day);
                    command.Parameters.AddWithValue("@time", mealItem.TimeOfDay);
                    command.Parameters.AddWithValue("@mealID", mealItem.Meal.ID);
                    command.Parameters.AddWithValue("@quantity", mealItem.Quantity);

                    command.ExecuteNonQuery();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return success;
        }

        public Plan GetPlanForPatient(Patient patient) 
        {
            Plan plan = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = "SELECT * FROM Plan WHERE Patient_id = @id";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", patient.PatientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    plan = new Plan()
                    {
                        Patient = patient
                    };
                }

                while (reader.Read())
                {
                    string mealID = reader["Meal_id"].ToString();
                    float quantity = Convert.ToSingle(reader["Quantity"]);
                    int day = int.Parse(reader["Day"].ToString());
                    int timeOfDay = int.Parse(reader["Time_of_day"].ToString());

                    MealItem mealItem = new MealItem()
                    {
                        Meal = DietaryEntityServiceImp.Instance().GetMealByID(mealID),
                        Quantity = quantity,
                        Day = day,
                        TimeOfDay = timeOfDay
                    };

                    plan.MealPlan.Add(mealItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return plan;
        }
    }
}
