unit Unit1;

{$mode objfpc}{$H+}

interface

uses
 Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, StdCtrls;

type

 { TForm1 }

 TForm1 = class(TForm)
   Button1: TButton;
   Button2: TButton;
   Button3: TButton;
   Button4: TButton;
   Edit1: TEdit;
   Edit2: TEdit;
   Edit3: TEdit;
   Label1: TLabel;
   Label2: TLabel;
   procedure Button1Click(Sender: TObject);
   procedure Button2Click(Sender: TObject);
   procedure Button3Click(Sender: TObject);
   procedure Button4Click(Sender: TObject);
 private
   { private declarations }
 public
   { public declarations }
 end;

var
 Form1: TForm1;

implementation

{$R *.lfm}

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
var pershe, druhe,  rez: real;
begin
   pershe := StrToFloat(edit1.text);
   druhe := StrToFloat(edit2.text);
   rez := (pershe + druhe);
   edit3.text := FloatToStr(rez);
end;

procedure TForm1.Button2Click(Sender: TObject);
  var pershe, druhe,  rez: real;
begin
   pershe := StrToFloat(edit1.text);
   druhe := StrToFloat(edit2.text);
   rez :=(pershe - druhe);
   edit3.text := FloatToStr(rez);
end;

procedure TForm1.Button3Click(Sender: TObject);
    var pershe, druhe,  rez: real;
begin
      pershe := StrToFloat(edit1.text);
   druhe := StrToFloat(edit2.text);
   rez :=(pershe * druhe);
   edit3.text := FloatToStr(rez);
end;

procedure TForm1.Button4Click(Sender: TObject);
    var pershe, druhe,  rez: real;
begin
     pershe := StrToFloat(edit1.text);
   druhe := StrToFloat(edit2.text);
   rez :=(pershe / druhe);
   edit3.text := FloatToStr(rez);
end;





end.
