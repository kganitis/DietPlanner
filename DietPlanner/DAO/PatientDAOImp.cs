using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;

namespace DietPlanner.DAO
{
    internal class PatientDAOImp : IPatientDAO
    {

        /*
         * Connects to the DB,
         * inserts into Patient table the data of the given patient,
         * or updates them if the given patient is found,
         * by deleting them first, then re-inserting them.
         */
        public bool Save(Patient patient)
        {
                        
                string query = string.Empty;
                SQLiteCommand command;
                bool success = false;
                try
                {
                    SQLiteConnection connection = DBUtil.GetConnection();
                    // Generate a new ID if needed
                    if (string.IsNullOrEmpty(patient.PatientID))
                    {
                        // Get the maximum patient_id value
                        query = "SELECT MAX(CAST(SUBSTR(Patient_id, 2) AS INTEGER)) FROM Patient";
                        command = new SQLiteCommand(query, connection);
                        object maxIdResult = command.ExecuteScalar();

                        // Get the next value, or start from "p0000" if there are no records yet
                        int newIdNumber = maxIdResult == DBNull.Value ? 0 : Convert.ToInt32(maxIdResult) + 1;

                        // Format the new patientID
                        patient.PatientID = "p" + newIdNumber.ToString("D4"); // D4 ensures 4 digits, padding with leading zeros if necessary
                    }

                    // First delete the given patient's data, if found
                    query = "DELETE FROM Patient WHERE Patient_id = @patientId";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);

                    command.ExecuteNonQuery();

                    // Insert patient's data (essentially updating them if previously deleted)
                    query = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level, Goal) " +
                                "VALUES (@patientId, @name, @gender, @phoneNumber, @date, @height, @weight, @activity, @goal)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@name", patient.Name);
                    command.Parameters.AddWithValue("@gender", patient.Gender);
                    command.Parameters.AddWithValue("@phoneNumber", patient.PhoneNumber);
                    command.Parameters.AddWithValue("@date", patient.DateOfBirthStr);
                    command.Parameters.AddWithValue("@height", patient.Height);
                    command.Parameters.AddWithValue("@weight", patient.Weight);
                    command.Parameters.AddWithValue("@activity", patient.ActivityLevel);
                    command.Parameters.AddWithValue("@goal", patient.Goal);

                    command.ExecuteNonQuery();

                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                finally 
                {
                    DBUtil.CloseConnection();
                }

                return success;
            
        }

        /*
         * Connects to the DB,
         * READS patient data corresponding to the given patientID,
         * creates a Patient instance,
         * READS patient preferences data for the given patientID,
         * fetches the dietary entity instances,
         * and adds them to the appropriate patient's preferenece list,
         * then returns the patient instance.
         */
        public Patient GetPatientByNameAndPhone(string name, string phoneNumber)
        {
            Patient patient = null;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = "SELECT * FROM Patient WHERE Name LIKE @name AND Phone_number = @phoneNumber";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", "%" + name + "%");
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve patient data from the Patient table
                    string patientID = reader["Patient_id"].ToString();
                    name = reader["Name"].ToString();
                    string gender = reader["Gender"].ToString();
                    phoneNumber = reader["Phone_number"].ToString();

                    string dateOfBirth = reader["Date_of_birth"].ToString();
                    DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                    float height = Convert.ToSingle(reader["Height"]);
                    float weight = Convert.ToSingle(reader["Weight"]);
                    float activityLevel = Convert.ToSingle(reader["Activity_level"]);
                    int goal = int.Parse(reader["Goal"].ToString());

                    patient = new Patient()
                    {
                        PatientID = patientID,
                        Name = name,
                        Gender = gender,
                        PhoneNumber = phoneNumber,
                        DateOfBirth = parsedDate,
                        Height = height,
                        Weight = weight,
                        ActivityLevel = activityLevel,
                        Goal = goal
                    };

                    // Retrieve patient preferences from the Patient_Preferences table
                    query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientID", patientID);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string entityID = reader["Dietary_entity_id"].ToString();
                        int rule = Convert.ToInt32(reader["Rule"]);

                        // Add dietary entity to the appropriate list based on the rule
                        if (rule == 1)
                        {
                            patient.PreferredFoods.Add(DietaryEntityServiceImp.Instance().GetDietaryEntityByID(entityID));
                        }
                        else if (rule == 0)
                        {
                            patient.FoodsToAvoid.Add(DietaryEntityServiceImp.Instance().GetDietaryEntityByID(entityID));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα ασθενή με τα στοιχεία που δώσατε.", "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            return patient;
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the preferred foods for the given patient
         */
        public void SavePreferredFoodsForPatient(Patient patient) 
        {
            string query = string.Empty;
            SQLiteCommand command;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First delete the given patient's data, if found
                query = "DELETE FROM Patient_Preferences WHERE Patient_id = @patientId AND Rule = 1";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);

                command.ExecuteNonQuery();

                foreach (var entity in patient.PreferredFoods)
                {
                    query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 1);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }
        }

        /*
         * Connects to the DB,
         * inserts into Patient_Preferences table the avoided foods for the given patient
         */
        public void SaveFoodsAvoidedForPatient(Patient patient) 
        {
            string query = string.Empty;
            SQLiteCommand command;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // First delete the given patient's data, if found
                query = "DELETE FROM Patient_Preferences WHERE Patient_id = @patientId AND Rule = 0";

                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);

                command.ExecuteNonQuery();

                foreach (var entity in patient.FoodsToAvoid)
                {
                    query = "INSERT INTO Patient_Preferences (Patient_id, Dietary_entity_id, Rule) VALUES (@patientId, @dietaryEntityId, @rule)";

                    command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@dietaryEntityId", entity.ID);
                    command.Parameters.AddWithValue("@rule", 0);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }
        }
    }
}
