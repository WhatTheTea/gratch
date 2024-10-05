//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit2.h"
#include "Unit3.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{//Form
SpeedButton1->Hint = "Оновити";


        if(is_empty(StudRead)&&is_empty(GrafRead)&&is_empty(grdr)){
        Button2->Enabled = false;
        } else {
        Button2->Enabled = true;
        }

        time(&t);
        month=(localtime(&t)->tm_mon)+1;
        day=localtime(&t)->tm_mday;
        year=(localtime(&t)->tm_year)+1900;
Label3->Caption = "Сьогодні " + IntToStr(day) + " " + MonthNameUKR()+" "+IntToStr(year);

GrafRead.open("config\\grafik.txt");
GrafRead.clear();
grdr.open("config\\grafikdate.txt");
grdr.clear();

   for(int i=1;i<dayinmon(month,year);i++){
       grdr >> gdate;
       GrafRead >> student;
       if(gdate==IntToCString(day)){
                Edit1->Text = student.c_str();
                break;
                        }
            }

GrafRead.close();
grdr.close();
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)
{
Form1->Visible=false;
Form2->Visible=true;
GrafRead.close();
StudRead.close();
LSr.close();
grdr.close();
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------



void __fastcall TForm1::Button2Click(TObject *Sender)
{
Form3->Visible=true;
Form1->Visible=false;
GrafRead.close();
StudRead.close();
LSr.close();
grdr.close();
}
//---------------------------------------------------------------------------



void __fastcall TForm1::SpeedButton1Click(TObject *Sender)
{
GrafRead.open("config\\grafik.txt");
GrafRead.clear();
grdr.open("config\\grafikdate.txt");
grdr.clear();

   for(int i=1;i<dayinmon(month,year);i++){
       grdr >> gdate;
       GrafRead >> student;
       if(gdate==IntToCString(day)){
                Edit1->Text = student.c_str();
                break;
                        }
            }

GrafRead.close();
grdr.close();
}
//---------------------------------------------------------------------------


void __fastcall TForm1::FormShow(TObject *Sender)
{
StudRead.open("config\\students.txt");
GrafRead.open("config\\grafik.txt");
GrafRead.clear();
LSr.open("config\\laststudent.txt");
grdr.open("config\\grafikdate.txt");

if(!StudRead.is_open()){
        StudCreate.open("config\\Students.txt");
        StudCreate.close();}
                if(!GrafRead.is_open()){
                GFcr.open("config\\grafik.txt");
                GFcr.close(); }
                        if(!LSr.is_open()){
                        LScr.open("config\\laststudent.txt");
                        LScr.close(); }
                                if(!grdr.is_open()){
                                gwd.open("config\\grafikdate.txt");
                                gwd.close(); }

 if(is_empty(StudRead)&&is_empty(GrafRead)&&is_empty(grdr)){
        Button2->Enabled = false;
        } else {
        Button2->Enabled = true;
        }


}
//---------------------------------------------------------------------------



