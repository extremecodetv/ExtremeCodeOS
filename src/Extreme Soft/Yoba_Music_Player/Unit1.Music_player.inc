procedure InitializeComponent;
    begin
        self.components := new System.ComponentModel.Container();
        var resources: System.ComponentModel.ComponentResourceManager := new System.ComponentModel.ComponentResourceManager(typeof(Music_player));
        self.Prev := new System.Windows.Forms.Button();
        self.next := new System.Windows.Forms.Button();
        self.Start_Pause := new System.Windows.Forms.Button();
        self.Music_bar := new System.Windows.Forms.ProgressBar();
        self.Music_played_name := new System.Windows.Forms.Label();
        self.Sel_dir := new System.Windows.Forms.Button();
        self.PlayList := new System.Windows.Forms.Label();
        self.folderBrowserDialog1 := new System.Windows.Forms.FolderBrowserDialog();
        self.timer1 := new System.Windows.Forms.Timer(self.components);
        self.Volume_ := new System.Windows.Forms.TrackBar();
        self.label1 := new System.Windows.Forms.Label();
        self.Volume_bar := new System.Windows.Forms.ProgressBar();
        self.Time_ := new System.Windows.Forms.Label();
        (System.ComponentModel.ISupportInitialize(self.Volume_)).BeginInit();
        self.SuspendLayout();
        // 
        // Prev
        // 
        self.Prev.Location := new System.Drawing.Point(12, 243);
        self.Prev.Name := 'Prev';
        self.Prev.Size := new System.Drawing.Size(78, 57);
        self.Prev.TabIndex := 0;
        self.Prev.Text := '<----';
        self.Prev.UseVisualStyleBackColor := true;
        self.Prev.Click += Prev_Click;
        // 
        // next
        // 
        self.next.Location := new System.Drawing.Point(194, 243);
        self.next.Name := 'next';
        self.next.Size := new System.Drawing.Size(78, 57);
        self.next.TabIndex := 1;
        self.next.Text := '---->';
        self.next.UseVisualStyleBackColor := true;
        self.next.Click += next_Click;
        // 
        // Start_Pause
        // 
        self.Start_Pause.Location := new System.Drawing.Point(96, 228);
        self.Start_Pause.Name := 'Start_Pause';
        self.Start_Pause.Size := new System.Drawing.Size(92, 72);
        self.Start_Pause.TabIndex := 2;
        self.Start_Pause.Text := 'Start';
        self.Start_Pause.UseVisualStyleBackColor := true;
        self.Start_Pause.Click += Start_Pause_Click;
        // 
        // Music_bar
        // 
        self.Music_bar.Location := new System.Drawing.Point(11, 72);
        self.Music_bar.Name := 'Music_bar';
        self.Music_bar.Size := new System.Drawing.Size(200, 30);
        self.Music_bar.TabIndex := 3;
        self.Music_bar.Visible := false;
        // 
        // Music_played_name
        // 
        self.Music_played_name.Location := new System.Drawing.Point(13, 46);
        self.Music_played_name.Name := 'Music_played_name';
        self.Music_played_name.Size := new System.Drawing.Size(259, 23);
        self.Music_played_name.TabIndex := 4;
        // 
        // Sel_dir
        // 
        self.Sel_dir.Location := new System.Drawing.Point(11, 10);
        self.Sel_dir.Name := 'Sel_dir';
        self.Sel_dir.Size := new System.Drawing.Size(75, 23);
        self.Sel_dir.TabIndex := 5;
        self.Sel_dir.Text := 'Select Dir';
        self.Sel_dir.UseVisualStyleBackColor := true;
        self.Sel_dir.Click += Sel_dir_Click;
        // 
        // PlayList
        // 
        self.PlayList.Location := new System.Drawing.Point(12, 105);
        self.PlayList.Name := 'PlayList';
        self.PlayList.Size := new System.Drawing.Size(259, 106);
        self.PlayList.TabIndex := 6;
        // 
        // folderBrowserDialog1
        // 
        // 
        // timer1
        // 
        self.timer1.Interval := 1000;
        self.timer1.Tick += Update_music_bar;
        // 
        // Volume_
        // 
        self.Volume_.Location := new System.Drawing.Point(145, 10);
        self.Volume_.Maximum := 100;
        self.Volume_.Name := 'Volume_';
        self.Volume_.Size := new System.Drawing.Size(104, 45);
        self.Volume_.TabIndex := 7;
        self.Volume_.Value := 50;
        self.Volume_.Visible := false;
        self.Volume_.Scroll += Volume__Scroll;
        // 
        // label1
        // 
        self.label1.Location := new System.Drawing.Point(92, 10);
        self.label1.Name := 'label1';
        self.label1.Size := new System.Drawing.Size(47, 23);
        self.label1.TabIndex := 8;
        self.label1.Text := 'Volume:';
        self.label1.Visible := false;
        // 
        // Volume_bar
        // 
        self.Volume_bar.ForeColor := System.Drawing.SystemColors.MenuHighlight;
        self.Volume_bar.Location := new System.Drawing.Point(154, 31);
        self.Volume_bar.MarqueeAnimationSpeed := 1;
        self.Volume_bar.Name := 'Volume_bar';
        self.Volume_bar.Size := new System.Drawing.Size(85, 12);
        self.Volume_bar.Step := 1;
        self.Volume_bar.Style := System.Windows.Forms.ProgressBarStyle.Continuous;
        self.Volume_bar.TabIndex := 9;
        self.Volume_bar.Value := 50;
        self.Volume_bar.Visible := false;
        // 
        // Time_
        // 
        self.Time_.Font := new System.Drawing.Font('Century Gothic', 20.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (System.Byte(204)));
        self.Time_.Location := new System.Drawing.Point(11, 62);
        self.Time_.Name := 'Time_';
        self.Time_.Size := new System.Drawing.Size(260, 40);
        self.Time_.TabIndex := 10;
        self.Time_.Text := '00:00:00';
        self.Time_.TextAlign := System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Music_player
        // 
        self.AutoScaleMode := System.Windows.Forms.AutoScaleMode.None;
        self.BackColor := System.Drawing.Color.White;
        self.ClientSize := new System.Drawing.Size(284, 312);
        self.Controls.Add(self.Time_);
        self.Controls.Add(self.Music_played_name);
        self.Controls.Add(self.Volume_bar);
        self.Controls.Add(self.label1);
        self.Controls.Add(self.Volume_);
        self.Controls.Add(self.PlayList);
        self.Controls.Add(self.Sel_dir);
        self.Controls.Add(self.Music_bar);
        self.Controls.Add(self.Start_Pause);
        self.Controls.Add(self.next);
        self.Controls.Add(self.Prev);
        self.Icon := (System.Drawing.Icon(resources.GetObject('$this.Icon')));
        self.MaximizeBox := false;
        self.MaximumSize := new System.Drawing.Size(300, 350);
        self.MinimumSize := new System.Drawing.Size(300, 350);
        self.Name := 'Music_player';
        self.StartPosition := System.Windows.Forms.FormStartPosition.CenterScreen;
        self.Text := 'Yoba Music Player';
        (System.ComponentModel.ISupportInitialize(self.Volume_)).EndInit();
        self.ResumeLayout(false);
        self.PerformLayout();
    end;
