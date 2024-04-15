using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner
{
    public partial class Form2 : Form
    {
        public int ButtonPressed;
        private FoodPreferences foodPreferences;

        public RichTextBox RichTextBox1
        {
            get { return richTextBox1; }
        }

        public RichTextBox RichTextBox2
        {
            get { return richTextBox2; }
        }

        public Form2()
        {
            InitializeComponent();
        }


        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = richTextBox1.GetCharIndexFromPosition(e.Location);
                int lineStartIndex = richTextBox1.GetFirstCharIndexOfCurrentLine();
                int lineEndIndex = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.GetLineFromCharIndex(index) + 1);
                if (lineEndIndex == -1) // Last line
                {
                    lineEndIndex = richTextBox1.Text.Length;
                }

                richTextBox1.Select(lineStartIndex, lineEndIndex - lineStartIndex);
            }
        }

        private void OpenFoodPreferencesForm()
        {
            if (foodPreferences == null || foodPreferences.IsDisposed)
            {
                foodPreferences = new FoodPreferences();
                foodPreferences.Owner = this;
                foodPreferences.ButtonPressedFromForm2 = this.ButtonPressed;
                foodPreferences.ShowBelowForm(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonPressed = 1;
            OpenFoodPreferencesForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonPressed = 3;
            OpenFoodPreferencesForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectedText = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
