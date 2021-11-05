unit Unit1;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, ExtCtrls, ExtDlgs;

type

  { TForm1 }

  TForm1 = class(TForm)
    Image1: TImage;
    Image2: TImage;
    Image3: TImage;
    Image4: TImage;
    OpenPictureDialog1: TOpenPictureDialog;
    procedure FormCreate(Sender: TObject);
    procedure FormResize(Sender: TObject);
    procedure Image1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image1MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image2ChangeBounds(Sender: TObject);
    procedure Image2MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image2MouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer
      );
    procedure Image2MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Image3Click(Sender: TObject);
    procedure Image4Click(Sender: TObject);
  private

  public

  end;

var
  Form1: TForm1;

implementation

{$R *.lfm}

var
  Nazhato: Boolean;
  Xp, Yp: Integer;

{ TForm1 }

procedure TForm1.FormResize(Sender: TObject);
begin

end;

procedure TForm1.Image1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin

end;

procedure TForm1.Image1MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  Image2.Picture.Bitmap.Canvas.Pen.Color := Image1.Canvas.Pixels[X, Y];
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Image2.Picture.Bitmap.Canvas.Pen.Width := 5;
end;

procedure TForm1.Image2ChangeBounds(Sender: TObject);
begin

end;

procedure TForm1.Image2MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  Nazhato := True;
  Xp := X;
  Yp := Y;
end;

procedure TForm1.Image2MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
        if Nazhato then begin
             Image2.Picture.Bitmap.Canvas.Pen.Width := 5;
  Image2.Picture.Bitmap.Canvas.MoveTo(Xp, Yp);
  Image2.Picture.Bitmap.Canvas.LineTo(X, Y);

             Xp := X;
  Yp := Y;
        end;
end;

procedure TForm1.Image2MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  Nazhato := False;
end;

procedure TForm1.Image3Click(Sender: TObject);
begin
  ShowMessage('DLYA DOSTUPA K SLOYAM KUPITE POLNy> VERSI>!!!111');
end;

procedure TForm1.Image4Click(Sender: TObject);
begin
 if  OpenPictureDialog1.Execute then
 begin
    Image2.Picture.LoadFromFile(OpenPictureDialog1.FileName);
 end;
end;

end.

