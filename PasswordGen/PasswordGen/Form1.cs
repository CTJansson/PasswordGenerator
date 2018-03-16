using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int checkBoxCount = 0;
            Random random = new Random();

            // Determine password length

            short passwordLength = 0;
            string length = "";

            foreach (Control control in PasswordLength.Controls)
            {
                RadioButton radioButton = control as RadioButton;
                if (radioButton.Checked)
                {
                    if (radioButton.Text == "Custom")
                        length = numericUpDown1.Value.ToString();
                    else
                        length = radioButton.Text.Substring(0, 2);
                }                   
            }

            short.TryParse(length, out passwordLength);

            // Confirming Password definitions

            string characters = "";

            if (checkBoxLowercase.Checked)
            {
                int num = 0;
                for (int i = 0; i < 26; i++)
                {
                    char letter = (char)('a' + num);
                    characters += letter;
                    num++;
                }

                checkBoxCount++;
            }

            if (checkBoxUppercase.Checked)
            {
                int num = 0;
                for (int i = 0; i < 26; i++)
                {
                    char letter = (char)('A' + num);
                    characters += letter;
                    num++;
                }

                checkBoxCount++;
            }

            if (checkBoxNumbers.Checked)
            {
                int[] array = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                for (int i = 0; i < array.Length; i++)
                    characters += array[i];

                checkBoxCount++;
            }

            if (checkBoxSymbols.Checked)
            {
                char[] array = new char[] { '!', '"', '#', '¤', '%', '&', '/', '(', ')', '=', '?', '^', '*', '-', '{', '}', '<', '>' };
                for (int i = 0; i < array.Length; i++)
                    characters += array[i];

                checkBoxCount++;
            }

            if (checkBoxSwedish.Checked)
            {
                characters += "åÅäÄöÖ";

                checkBoxCount++;
            }

            if (checkBoxCount > 0)
            {
                string password = "";
                int index = 0;

                for (int i = 0; i < passwordLength; i++)
                {
                    index = random.Next(0, characters.Length);
                    char letter = characters[index];
                    password += letter;
                }

                textBox1.Text = password;
            }
           

        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void ActivateNumericControl(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                numericUpDown1.Visible = true;
            else
                numericUpDown1.Visible = false;
        }
    }
}
