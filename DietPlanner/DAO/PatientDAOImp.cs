using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        
                string query = String.Empty;
                SQLiteCommand command;
                bool success = false;
                try
                {
                    SQLiteConnection connection = DBUtil.GetConnection();
                    // Generate a new ID if needed
                    if (String.IsNullOrEmpty(patient.PatientID))
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
         * inserts into Patient_Preferences table the preferred foods for the given patient
         */
        public void SavePreferredFoodsForPatient(Patient patient) 
        {
            string query = String.Empty;
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
            string query = String.Empty;
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
