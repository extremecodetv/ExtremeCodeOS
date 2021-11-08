
namespace ExNotepad
{
    partial class window
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
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.view = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MaxButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MinButton = new System.Windows.Forms.ToolStripMenuItem();
            this.Filename = new System.Windows.Forms.ToolStripTextBox();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.saveAs = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.DetectUrls = false;
            this.TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox.ForeColor = System.Drawing.Color.White;
            this.TextBox.Location = new System.Drawing.Point(0, 29);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(683, 341);
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = "";
            this.TextBox.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileButton,
            this.view,
            this.Filename});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileButton
            // 
            this.FileButton.BackColor = System.Drawing.Color.Gray;
            this.FileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.SaveAsButton});
            this.FileButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileButton.ForeColor = System.Drawing.Color.Black;
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(41, 25);
            this.FileButton.Text = "File";
            // 
            // OpenButton
            // 
            this.OpenButton.BackColor = System.Drawing.Color.Gray;
            this.OpenButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OpenButton.ForeColor = System.Drawing.Color.Black;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(114, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenDialog);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Gray;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.ForeColor = System.Drawing.Color.Black;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(114, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.Save);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.BackColor = System.Drawing.Color.Gray;
            this.SaveAsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveAsButton.ForeColor = System.Drawing.Color.Black;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(114, 22);
            this.SaveAsButton.Text = "Save as";
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsDialog);
            // 
            // view
            // 
            this.view.BackColor = System.Drawing.Color.Gray;
            this.view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScaleButton});
            this.view.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.view.ForeColor = System.Drawing.Color.Black;
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(50, 25);
            this.view.Text = "View";
            // 
            // ScaleButton
            // 
            this.ScaleButton.BackColor = System.Drawing.Color.Gray;
            this.ScaleButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaxButton,
            this.MinButton});
            this.ScaleButton.ForeColor = System.Drawing.Color.Black;
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(108, 24);
            this.ScaleButton.Text = "Scale";
            // 
            // MaxButton
            // 
            this.MaxButton.BackColor = System.Drawing.Color.Gray;
            this.MaxButton.ForeColor = System.Drawing.Color.Black;
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(88, 24);
            this.MaxButton.Text = "+";
            this.MaxButton.Click += new System.EventHandler(this.Max);
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Gray;
            this.MinButton.ForeColor = System.Drawing.Color.Black;
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(88, 24);
            this.MinButton.Text = "-";
            this.MinButton.Click += new System.EventHandler(this.Min);
            // 
            // Filename
            // 
            this.Filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Filename.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Filename.ForeColor = System.Drawing.Color.White;
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Size = new System.Drawing.Size(130, 25);
            this.Filename.Text = "Untiled";
            // 
            // saveAs
            // 
            this.saveAs.FileName = "untiled";
            this.saveAs.Filter = "Text .txt|*.txt|JSON .json|*.json|Markdown .md|*.md|All files|*.*";
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 370);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "window";
            this.Text = "ExNotepad";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileButton;
        private System.Windows.Forms.ToolStripMenuItem OpenButton;
        private System.Windows.Forms.ToolStripMenuItem SaveButton;
        private System.Windows.Forms.ToolStripMenuItem SaveAsButton;
        private System.Windows.Forms.ToolStripMenuItem view;
        private System.Windows.Forms.ToolStripMenuItem ScaleButton;
        private System.Windows.Forms.ToolStripMenuItem MaxButton;
        private System.Windows.Forms.ToolStripMenuItem MinButton;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.SaveFileDialog saveAs;
        private System.Windows.Forms.ToolStripTextBox Filename;
    }
}

