using System;
using System.IO;
using System.Windows.Forms;
using TestGeneration;

namespace WindowsForms
{
    public partial class Muzzle : Form
    {
        string pathDirectory;

        public Muzzle()
        {
            InitializeComponent();
            this.TopMost = true;

            pathDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void inputSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            // считывание нажатия символа
            string symbol = e.KeyChar.ToString();

            // если это цифра, то символ вводится
            if (!System.Text.RegularExpressions.Regex.Match(symbol, @"[\d\b]").Success)
                e.Handled = true;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles($@"{pathDirectory}\ТЕСТЫ");
                foreach (string file in files)
                {
                    File.Delete(file);
                }
     
                int numberOfVariants = Int32.Parse(inputNumberOfVariants.Text);

                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = numberOfVariants;
                progressBar.Value = 0;
                progressBar.Step = 1;

                for (int i = 1; i <= numberOfVariants; i++)
                {
                    Test test = new Test(i);
                    progressBar.PerformStep();
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show(
                    "TestGeneration.exe должен находиться в исходной папке!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                this.TopMost = true;
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Введите число!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                this.TopMost = true;
            };
        }
    }
}
