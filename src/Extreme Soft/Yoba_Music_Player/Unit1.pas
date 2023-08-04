Unit Unit1;

interface

uses System, System.Drawing, System.Windows.Forms, System.Windows.Forms.ComponentModel, Sounds;

var File_names, Safe_file_names, Result_file_names: array of string;
var Number: integer;
var Play:Boolean;
var Music: Sound;
var _Time_: StopWatch;

type
  Music_player = class(Form)
    procedure Sel_dir_Click(sender: Object; e: EventArgs);
    procedure Prev_Click(sender: Object; e: EventArgs);
    procedure Next_Click(sender: Object; e: EventArgs);
    procedure Start_Pause_Click(sender: Object; e: EventArgs);
    procedure Update_Playlist();
    procedure Pause_music();
    procedure Update_music_bar(sender: Object; e: EventArgs);
    procedure Volume__Scroll(sender: Object; e: EventArgs);
  {$region FormDesigner}
  internal
    {$resource Unit1.Music_player.resources}
    Prev: Button;
    next: Button;
    Start_Pause: Button;
    Music_bar: ProgressBar;
    Music_played_name: &Label;
    Sel_dir: Button;
    folderBrowserDialog1: FolderBrowserDialog;
    components: System.ComponentModel.IContainer;
    timer1: Timer;
    Volume_: TrackBar;
    label1: &Label;
    Volume_bar: ProgressBar;
    Time_: &Label;
    PlayList: &Label;
    {$include Unit1.Music_player.inc}
  {$endregion FormDesigner}
  public
    constructor;
    begin
      InitializeComponent;
    end;
  end;

implementation

procedure Music_player.Pause_music();
begin
   if Result_file_names <> nil then begin
     self.Start_Pause.Text := 'Play';
     Play := False;
     self.timer1.Enabled := False;
     _Time_.Stop;
     Music.Pause;
   end;
end;

procedure Music_player.Update_Playlist();
begin
  if  Result_file_names <> nil then begin
    self.PlayList.Text := '';
    self.Music_played_name.Text := Result_file_names[Number];
    Music := new Sound(file_names[Number]);
    println(Music.fsound.Position.Seconds);
    for var i := 0 to 10 do begin
      if Number+i <= Result_file_names.Length-1 then begin
        self.PlayList.Text += $'{Result_file_names[Number+i]} {newline}';
      end;
    end;
  end;
end;

procedure Music_player.Prev_Click(sender: Object; e: EventArgs);
begin
  Number := Number<>0 ? Number-1 : 0;
  _Time_.Reset;
  self.Time_.Text := '00:00:00';
  self.Pause_music();
  self.Update_Playlist();
end;

procedure Music_player.next_Click(sender: Object; e: EventArgs);
begin
  if Result_file_names <> nil then begin
    Number := Number< Result_file_names.Length-1 ? Number+1 :  Result_file_names.Length-1;
    self.Time_.Text := '00:00:00';
    _Time_.Reset;
    self.Pause_music();
    self.Update_Playlist();
  end;
end;


procedure Music_player.Sel_dir_Click(sender: Object; e: EventArgs);
begin
  var FolderBrowserDialog1 := new  FolderBrowserDialog; 
  _Time_:= new StopWatch;
  FolderBrowserDialog1.ShowDialog();
  if FolderBrowserDialog1.SelectedPath <> '' then begin
    File_names := EnumerateAllFiles(FolderBrowserDialog1.SelectedPath,'*.*').ToArray;
    Safe_file_names := File_names;
    SetLength(Result_file_names,Safe_file_names.Length);
    for var i := 0 to File_names.Length-1 do begin
      var last_in := File_names[i].LastIndexOf('\');
      Result_file_names[i] := Safe_file_names[i].Remove(0, last_in+1); //Это ёбанный пиздец
    self.Volume_bar.Visible := True;
    self.label1.Visible := True;
    self.Volume_.Visible := True;
    end;    
    Safe_file_names := nil;
    self.Update_Playlist();
  end;
end;   


procedure Music_player.Start_Pause_Click(sender: Object; e: EventArgs);
begin
 if not Play then begin
   if Result_file_names <> nil then begin
     Start_Pause.Text := 'Pause';
     Play := True;
     self.timer1.Enabled := True;
     _Time_.Start;
     Music.Play;
   end;
 end
 else if Play then begin
   self.Pause_music();
 end;
end;

procedure Music_player.Update_music_bar(sender: Object; e: EventArgs);
begin
  var Hours := _Time_.Elapsed.Hours<10 ? '0'+_Time_.Elapsed.Hours.ToString : _Time_.Elapsed.Hours.ToString;
  var Min := _Time_.Elapsed.Minutes < 10 ? '0' + _Time_.Elapsed.Minutes.Tostring : _Time_.Elapsed.Minutes.ToString;
  var Sec := _Time_.Elapsed.Seconds < 10 ? '0' + _Time_.Elapsed.Seconds.Tostring : _Time_.Elapsed.Seconds.ToString;
  self.Time_.Text := $'{Hours}:{Min}:{Sec}';
end;

procedure Music_player.Volume__Scroll(sender: Object; e: EventArgs);
begin
  if Music <> nil then begin
   self.Volume_bar.Value := Volume_.Value;
   Music.fsound.Volume := Volume_.Value / 100;
  end;
end;



end.