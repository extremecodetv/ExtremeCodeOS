using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YobkiyIDE
{
    public partial class Form1 : Form
    {
        public string _path;

        public Form1()
        {
            InitializeComponent();
        }

        public void button3_Click(object sender, EventArgs e) //emp
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Cs file|*.cs|JS file|*.js|txt file|*.txt|Pascal file|*.pas|All files|*.*";
            saveFileDialog1.Title = "Create";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                File.Create($"{saveFileDialog1.FileName}");
                _path = saveFileDialog1.FileName;
            }

            /*
            using (var sr = new StreamReader(_path))
            {
                textBox1.Text = sr.ReadToEnd();
            }
            */
        }

        public void button1_Click(object sender, EventArgs e) //ld
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cs file|*.cs|JS file|*.js|txt file|*.txt|Pascal file|*.pas|All files|*.*";
            openFileDialog1.Title = "Open";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                using (var sr = new StreamReader(openFileDialog1.FileName))
                {
                    textBox1.Text = sr.ReadToEnd();
                    _path = openFileDialog1.FileName;
                }
            }

        }

        public void button2_Click(object sender, EventArgs e) //sv as
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Cs file|*.cs|JS file|*.js|txt file|*.txt|Pascal file|*.pas|All files|*.*";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (var sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine(textBox1.Text);
                    _path = saveFileDialog1.FileName;
                }
            }
        }

        public void button4_Click(object sender, EventArgs e) //sv
        {
            
                try
                {
                using (var sw = new StreamWriter(_path))
                {
                    sw.WriteLine(textBox1.Text);
                }
                }
                catch
                {
                    MessageBox.Show("Ошибка не произашла, всё хорошо попробуйте save as", "Сообщение о не ошибке");
                }
            
        }
    }
}
