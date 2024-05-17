using DietPlanner.DAO;
using DietPlanner.Service;
using DietPlanner.View;
using System;
using System.Windows.Forms;

namespace DietPlanner
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DietaryEntityServiceImp.getInstance().Initialize();
            Application.Run(new PatientView());
        }
    }
}
