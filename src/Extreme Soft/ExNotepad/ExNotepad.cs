using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExNotepad
{
    public partial class window : System.Windows.Forms.Form
    {
        public window()
        {
            InitializeComponent();
        }

        bool isCreateFile = false;
        string filename;

        private void Save(object sender, EventArgs e)
        {
            if (!isCreateFile)
            {
                SaveAsDialog(0, e);

                return;
            }

            File.WriteAllText(filename, TextBox.Text);
        }

        private void SaveAsDialog(object sender, EventArgs e)
        {
            if (saveAs.ShowDialog() == DialogResult.Cancel)
                return;

            filename = saveAs.FileName;

            File.WriteAllText(filename, TextBox.Text);
        }

        private void OpenDialog(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.Cancel)
                return;

            filename = open.FileName;

            string[] path = filename.Split((char)92);

            Filename.Text = path[path.Length - 1];

            TextBox.Text = File.ReadAllText(filename);

            isCreateFile = true;
        }

        private void Max(object sender, EventArgs e)
        {
            TextBox.Font = new System.Drawing.Font("Calibri", TextBox.Font.Size + 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }

        private void Min(object sender, EventArgs e)
        {
            TextBox.Font = new System.Drawing.Font("Calibri", TextBox.Font.Size - 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }
    }
}
