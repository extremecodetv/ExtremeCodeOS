using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Broser
{
    partial class Form1
    {
        private IContainer components = null;

        private string[] names = new string[] 
        { 
            "Охуевшие байкеры жарят сводную сестру.",
            "Сибил Эй: была любовь, а осталось только межрасовое порно..",
            "Хоть член и фимозный, а если это любовь...",
            "Парень сделал массаж мачехе, а потом...",
            "Пляжный съем отдыхающих местными аборигенами",
            "Психолог видел многое, но такой разврат - впервые",
            "Питер Грин приглашает в гости зрелую Ла-Сирену",
            "Горячее порно зрелых после прогулки" 
        };

        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(600, 25);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(120, 40);
            this.searchButton.TabIndex = 0;
            this.searchButton.Text = "Искать";
            this.searchButton.Click += new System.EventHandler(this.Search);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1343, 749);
            this.Controls.Add(this.searchButton);
            this.Name = "Form1";
            this.Text = "Broser";
            this.ResumeLayout(false);

        }

        private void Search(object sender, EventArgs e)
        {
            var used = new System.Collections.Generic.List<int>();
            Controls.Clear();
            for(int i = 0; i < 8; i++)
            {
                Button searchButton = new Button();
                searchButton.Size = new Size(800, 125);
                searchButton.Font = new Font("Arial", 25f);
                searchButton.Location = new Point((ClientSize.Width / 2) - 400, 100 + (125 * i));
                var n = 0;
                while(true)
                {
                    n = new Random().Next(0, 8);
                    if(!used.Contains(n))
                    {
                        used.Add(n);
                        break;
                    }
                }
                searchButton.Text = names[n];

                searchButton.BackColor = Color.Gray;
                Controls.Add(searchButton);

                searchButton.Click += new EventHandler(ShowVideo);
            }
        }

        private void ShowVideo(object sender, EventArgs e)
        {
            MessageBox.Show("Видео не доступно в вашем регионе");
        }

        private Button searchButton;
    }
}

