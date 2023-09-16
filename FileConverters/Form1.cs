using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Services;

namespace FileConverters
{
    public partial class Form1 : Form
    {
        private string _inputFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _inputFile = fileDialog.FileName;
                FileNameLabel.Text = "Файл: " + _inputFile.Split('\\').Last();
                ConvertButton.Visible = true;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "All formats (*.*)|*.*";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                MessageBox.Show("Зачикайте, файл конвертується. (Це може зайняти пару хвилин)");

                Converter converter = new Converter(filePath.Split('.').Last());

                Thread thread = new Thread(() => converter.Convert(_inputFile, filePath));
                thread.Start();
            }
        }
    }
}
