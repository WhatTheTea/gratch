//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{

time(&t);
month = localtime(&t)->tm_mon; //ot 0 do 11, +1 dlya real
day = localtime(&t)->tm_mday;
year = localtime(&t)->tm_year+1900;
beginning();
Edit3->Text = Edit1->Text;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
if(Edit2->Text==""){
        Beep();
        } else {
        ListBox1->Items->Add(Edit2->Text+".");
        }
        Edit2->Text = "";
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormClose(TObject *Sender, TCloseAction &Action)
{
NewStudent.clear();
NewStudent.close();
ReadStudent.clear();
ReadStudent.close();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender)
{
for(int i = ListBox1->Items->Count-1; i >= 0; i--){
if(ListBox1->Selected[i])
ListBox1->Items->Delete(i);
        }
Edit2->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TForm1::SpeedButton3Click(TObject *Sender)
{


if(ListBox1->Items->Capacity != 0){
        ListBox1->Items->SaveToFile("students.txt");
        //Grafik
        if(RadioButton2->Checked){
        NewStudent.open("grafik.txt");
        NewStudent.clear();
        ReadStudent.open("students.txt");
        ReadStudent.clear();
        for(int i = 0;i<ListBox1->Items->Capacity;i++){
        getline(ReadStudent,strmas[i]);
        }
                for(int i = 0,c = 0;c<dayinmon(month+1,year);i++,c++){
                if(i>=ListBox1->Items->Capacity){
                i=0;
                }
                NewStudent << strmas[i] << endl;
                        }
        NewStudent.close();
        ReadStudent.close();
        } else { //RadioButton1 obnovlenie
                NewStudent.open("grafik.txt");
        NewStudent.clear();
        ReadStudent.open("students.txt");
        ReadStudent.clear();
        for(int i = 0;i<ListBox1->Items->Capacity;i++){
        getline(ReadStudent,strmas[i]);
        }
                for(int i = 0+intbuff,c = 0;c<dayinmon(month+1,year);i++,c++){
                if(i>ListBox1->Items->Capacity-1){
                i=0;
                }
                NewStudent << strmas[i] << endl;
                        }
        NewStudent.close();
        ReadStudent.close();
                }
                if(StringGrid1->Cells[1][dayinmon(month+1,year)]!=""){
                 NewStudent.open("laststud.txt");
                 NewStudent.clear();
                 Ansibuff = StringGrid1->Cells[1][dayinmon(month+1,year)];
                        NewStudent << Ansibuff.c_str();
                        NewStudent.close();
                        } else {
                        ShowMessage("ERROR! laststud.txt(NewStudent)");
                        }
  }
   NewStudent.close();
    ReadStudent.close();
  ShellExecute(0,0,Application->ExeName.c_str(),0,0,SW_SHOW);
Close();
}
//---------------------------------------------------------------------------


void __fastcall TForm1::FormKeyPress(TObject *Sender, char &Key)
{
if(Key == 0x8){
for(int i = ListBox1->Items->Count-1; i >= 0; i--){
        Button3->Click();
  }
}
if(Key ==0x0D){
Key = 0;
      Button1->Click();
        }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SpeedButton1Click(TObject *Sender)
{
if(daysV<dayinmon(month+1,year)-day){
daysV++;
        if(daysV%10==1&&daysV!=11){
        Button2->Caption = "Штраф на "+IntToStr(daysV)+" день";
        } else {
        Button2->Caption = "Штраф на "+IntToStr(daysV)+" днів";
        }
    } else {
    Beep();
    }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SpeedButton2Click(TObject *Sender)
{
if(daysV>1){
        daysV--;
         if(daysV%10==1&&daysV!=11){
        Button2->Caption = "Штраф на "+IntToStr(daysV)+" день";
        } else {
        Button2->Caption = "Штраф на "+IntToStr(daysV)+" днів";
        }
        }  else {
        Beep();
        }

}
//---------------------------------------------------------------------------


void __fastcall TForm1::Button2Click(TObject *Sender)
{
wtraf(month,year,daysV);
for(int i=0;i!=daysV;i++){

        StudentVect.insert(StudentVect.begin()+day-1,Edit3->Text);
        }
        NewStudent.open("grafik.txt");
        NewStudent.clear();
        for(int i=0;i<dayinmon(month+1,year);i++){
        strbuff2 = StudentVect[i].c_str();
        NewStudent << strbuff2 << endl;
        }
NewStudent.close();
  ShellExecute(0,0,Application->ExeName.c_str(),0,0,SW_SHOW);
Close();
}
//---------------------------------------------------------------------------


