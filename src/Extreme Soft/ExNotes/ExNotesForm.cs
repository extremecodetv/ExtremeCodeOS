using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExNotes
{
    public partial class ExNotesForm : Form
    {
        public ExNotesForm()
        {
            InitializeComponent();
        }

        int position { get; set; } = 10;
        int count { get; set; } = 0;

        Control[,] elems = new Control[9, 3];

        public void CreateNote (object sender, EventArgs e)
        {
            if (count == 9)
                return;

            l2.Visible = false;
            l3.Visible = false;
            l4.Visible = false;

            TextBox textBox1 = new TextBox();
            CheckBox checkBox1 = new CheckBox();
            Label label1 = new Label();

            // 
            // Note
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(33, position);
            textBox1.Name = $"textBox{count}";
            textBox1.Size = new System.Drawing.Size(238, 24);
            textBox1.TabIndex = count + 0;
            // 
            // checkBox
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox1.Location = new System.Drawing.Point(12, position + 5);
            checkBox1.Name = "checkBox{count}";
            checkBox1.Size = new System.Drawing.Size(15, 14);
            checkBox1.TabIndex = 2 + count;
            checkBox1.UseVisualStyleBackColor = true;
            //
            // label
            //
            label1.AutoSize = false;
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(284, position);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 22);
            label1.TabIndex = 2;
            label1.Text = $"  {count + 1}";

            elems[count, 0] = textBox1;
            elems[count, 1] = checkBox1;
            elems[count, 2] = label1;

            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(label1);

            count++;
            position += 32;
        }

        public void DeleteNote (object sender, EventArgs e)
        {
            if (count == 0)
                return;

            for (int i = 0; i < 3; i++)
            {
                Controls.Remove(elems[count - 1, i]);
                elems[count - 1, i] = null;
            }

            count--;
            position -= 32;

            if (count == 0)
            {
                l2.Visible = true;
                l3.Visible = true;
                l4.Visible = true;
            }
        }
    }
}
