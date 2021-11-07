
namespace ExNotes
{
    partial class ExNotesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.delet = new System.Windows.Forms.Button();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.CreateNote);
            // 
            // delet
            // 
            this.delet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.delet.FlatAppearance.BorderSize = 0;
            this.delet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delet.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.delet.ForeColor = System.Drawing.Color.White;
            this.delet.Location = new System.Drawing.Point(170, 339);
            this.delet.Name = "delet";
            this.delet.Size = new System.Drawing.Size(158, 39);
            this.delet.TabIndex = 1;
            this.delet.Text = "Удалить ";
            this.delet.UseVisualStyleBackColor = false;
            this.delet.Click += new System.EventHandler(this.DeleteNote);
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l2.Location = new System.Drawing.Point(146, 50);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(97, 41);
            this.l2.TabIndex = 2;
            this.l2.Text = "Notes";
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.BackColor = System.Drawing.Color.Transparent;
            this.l3.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.l3.Location = new System.Drawing.Point(106, 50);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(47, 41);
            this.l3.TabIndex = 3;
            this.l3.Text = "Ex";
            // 
            // l4
            // 
            this.l4.AutoSize = true;
            this.l4.BackColor = System.Drawing.Color.Gainsboro;
            this.l4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l4.Location = new System.Drawing.Point(76, 134);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(189, 60);
            this.l4.TabIndex = 4;
            this.l4.Text = "Быстрые заметки\r\n   и списки дел";
            // 
            // ExNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(340, 391);
            this.Controls.Add(this.l4);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.delet);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 430);
            this.MinimumSize = new System.Drawing.Size(356, 430);
            this.Name = "ExNotesForm";
            this.ShowIcon = false;
            this.Text = "ExNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button delet;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
    }
}

