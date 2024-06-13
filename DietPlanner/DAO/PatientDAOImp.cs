using DietPlanner.Model;
using DietPlanner.Service;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DietPlanner.DAO
{
    internal class PatientDAOImp : IPatientDAO
    {
        /*
         * Connects to the DB,
         * INSERTS into Patient table the data of the given patient,
         */
        public bool Insert(Patient patient)
        {
                string query = string.Empty;
                SQLiteCommand command;
                bool success = false;

                try
                {
                    SQLiteConnection connection = DBUtil.GetConnection();

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
         * READS the maximum ID in the Patient table
         * and returns the next value 
         */
        public string GetNextAvailablePatientID()
        {
            string query = string.Empty;
            SQLiteCommand command;
            string patientID = string.Empty;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                // Get the maximum patient_id value
                query = "SELECT MAX(CAST(SUBSTR(Patient_id, 2) AS INTEGER)) FROM Patient";
                command = new SQLiteCommand(query, connection);
                object maxIdResult = command.ExecuteScalar();

                // Get the next value, or start from "p0000" if there are no records yet
                int newIdNumber = maxIdResult == DBNull.Value ? 0 : Convert.ToInt32(maxIdResult) + 1;

                // Format the new patientID
                patientID = "p" + newIdNumber.ToString("D4"); // D4 ensures 4 digits, padding with leading zeros if necessary
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + query, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBUtil.CloseConnection();
            }

            return patientID;
        }

        /*
         * Connects to the DB,
         * DELETES a given patient from the Patient table
         */
        public bool Delete(Patient patient)
        {
            string query = string.Empty;
            SQLiteCommand command;
            bool success = false;

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                query = "DELETE FROM Patient WHERE Patient_id = @patientId";
                command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientId", patient.PatientID);
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
         * READS the preferred foods data for a given patient
         * and returns them into a List
         */
        public List<DietaryEntity> GetPreferredFoodsForPatient(Patient patient)
        {
            List<DietaryEntity> preferredFoods = new List<DietaryEntity>();

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patient.PatientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα ασθενή με τα στοιχεία που δώσατε.", "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                while (reader.Read())
                {
                    string entityID = reader["Dietary_entity_id"].ToString();
                    int rule = Convert.ToInt32(reader["Rule"]);
                    if (rule == 1)
                    {
                        preferredFoods.Add(DietaryEntityServiceImp.Instance().GetDietaryEntityByID(entityID));
                    }
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

            return preferredFoods;
        }

        /*
         * Connects to the DB,
         * READS the avoided foods data for a given patient
         * and returns them into a List
         */
        public List<DietaryEntity> GetAvoidedFoodsForPatient(Patient patient)
        {
            List<DietaryEntity> avoidedFoods = new List<DietaryEntity>();

            try
            {
                SQLiteConnection connection = DBUtil.GetConnection();

                string query = @"SELECT Patient_id, Dietary_entity_id, Rule
                                FROM Patient_Preferences
                                WHERE Patient_id = @patientID";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@patientID", patient.PatientID);
                SQLiteDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Δεν βρέθηκαν δεδομένα ασθενή με τα στοιχεία που δώσατε.", "Μήνυμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                while (reader.Read())
                {
                    string entityID = reader["Dietary_entity_id"].ToString();
                    int rule = Convert.ToInt32(reader["Rule"]);
                    if (rule == 0)
                    {
                        avoidedFoods.Add(DietaryEntityServiceImp.Instance().GetDietaryEntityByID(entityID));
                    }
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

            return avoidedFoods;
        }

        /*
         * Connects to the DB,
         * INSERTS into Patient_Preferences table the preferred foods for the given patient
         */
        public void InsertPreferredFoodsForPatient(Patient patient) 
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
         * INSERTS into Patient_Preferences table the avoided foods for the given patient
         */
        public void InsertFoodsAvoidedForPatient(Patient patient) 
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
