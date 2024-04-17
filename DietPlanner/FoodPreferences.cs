using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class FoodPreferences : Form
    {
        public int ButtonPressedFromForm2 { get; set; }

        public FoodPreferences()
        {
            InitializeComponent();
        }

        public void ShowBelowForm(Form form)
        {
            if (form != null)
            {
                // Calculate the location below the given form
                int x = form.Location.X + 400;
                int y = form.Location.Y + 400;


                // Set the location of FoodPreferences form
                this.Location = new Point(x, y);
            }

            // Show the FoodPreferences form
            this.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();

            foreach (string item in category.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBox1.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBox2.SelectedItems)
            {
                selectedItems.Add(item);
            }
            foreach (string item in listBox3.SelectedItems)
            {
                selectedItems.Add(item);
            }
            Form2 form2 = (Form2)this.Owner; // Αναφορά στην Form2
            if (form2 != null)
            {
                ListBox listBox;
                // Χρήση της ButtonPressed για να αποφασίσουμε ποιο richtextbox να χρησιμοποιήσουμε
                if (form2.ButtonPressed == 1)
                {
                    listBox = form2.ListBox1;
                }
                else
                {
                    listBox = form2.ListBox2;
                }
                if (listBox != null)
                {
                    foreach (string item in selectedItems)
                    {
                        listBox.Items.Add(item);
                    }
                }
            }
            this.Close();
        }
    }
}
