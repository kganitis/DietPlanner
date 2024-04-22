using DietPlanner.DAO.dbutil;
using DietPlanner.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DietPlanner.DAO
{
    internal class PatientDAOImp : IPatientDAO
    {
        readonly SQLiteConnection connection = DBUtil.OpenConnection();

        // Insert a new Patient
        public void Save(Patient patient)
        {
            using (connection)
            {
                try
                {
                    string insertSQL = "INSERT INTO Patient(Patient_id, Name, Gender, Phone_number, Date_of_birth, Height, Weight, Activity_level) " +
                                                "VALUES (@patientId, @name, @gender, @phone, @date, @height, @weight, @activity)";

                    SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
                    command.Parameters.AddWithValue("@patientId", patient.PatientID);
                    command.Parameters.AddWithValue("@name", patient.Name);
                    command.Parameters.AddWithValue("@gender", patient.Gender);
                    command.Parameters.AddWithValue("@phone", patient.PhoneNumber);
                    command.Parameters.AddWithValue("@date", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@height", patient.Height);
                    command.Parameters.AddWithValue("@weight", patient.Weight);
                    command.Parameters.AddWithValue("@activity", patient.ActivityLevel);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Ο ασθενής καταχωρήθηκε με επιτυχία, με ΑΜ: " + patient.PatientID);
                } 
                catch (Exception ex) 
                {
                    MessageBox.Show("Προέκυψε ένα σφάλμα: " + ex.Message);
                }
                finally { connection.Close(); }
            }         
        }      
    }
}
