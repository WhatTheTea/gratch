//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "Unit2.h"
#include "Unit3.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm2 *Form2;
int c=0,index=0;
//---------------------------------------------------------------------------
__fastcall TForm2::TForm2(TComponent* Owner)
        : TForm(Owner)
{
        time(&t);
        month=(localtime(&t)->tm_mon)+1;
        day=localtime(&t)->tm_mday;
        year=(localtime(&t)->tm_year)+1900;

}
//---------------------------------------------------------------------------


void __fastcall TForm2::Button1Click(TObject *Sender)
{
/*Form1->LSr.open("config\\laststudent.txt");
sr.open("config\\students.txt");
                gw.open("config\\grafik.txt");
                gdw.open("config\\grafikdate.txt");
                last.clear();
                studf.clear();
                Form1->LSr >> last;
                Form1->LSr.close();
                for(;last!=studf;){
                 sr >> studf;
                        }
                 Form1->LSr.close();
                  for(int i=1;dayinmon(month,year)>i-1;i++){
               sr >> studf;
               if(studf!=""){
               gdw << i <<endl;
               gw << studf<<endl;
                                } else {
                                i--;
                                }
              if(sr.eof()){
               sr.clear();
               sr.seekg(0);
               }

              studf.clear();
                                }
                                sr.close();
gw.close();
gdw.close();

Form1->Close();
Form2->Close();
Form3->Close();
 */
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button4Click(TObject *Sender)
{
/*Edit1->Text!=""?ComboBox1->Items->Add(Edit1->Text):ComboBox1->Items->Add("Slot");
if(ComboBox1->Items->Capacity>0){
index = ComboBox1->ItemIndex;
ComboBox1->Items->Delete(index);
}

if(ComboBox1->Items->Capacity == NULL){
                 Button5->Enabled = false;
                 } else { Button5->Enabled = true;
                        }         */
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button3Click(TObject *Sender)
{
/*if(ComboBox1->Items->Capacity>0){
index = ComboBox1->ItemIndex;
ComboBox1->Items->Delete(index);
}

if(ComboBox1->Items->Capacity == NULL){
                 Button5->Enabled = false;
                 } else { Button5->Enabled = true;
                        }
                        */
}
//---------------------------------------------------------------------------

void __fastcall TForm2::Button5Click(TObject *Sender)
{
 /*
if(sr.is_open()){
sr.close();
gw.close();

}
ComboBox1->Items->SaveToFile("config\\students.txt");
//script

        sr.open("config\\students.txt");
        gw.open("config\\grafik.txt");
        gdw.open("config\\grafikdate.txt");
               for(int i=1;dayinmon(month,year)>i-1;i++){
               sr >> studf;
               if(studf!=""){
               gdw << i <<endl;
               gw << studf<<endl;
                                } else {
                                i--;
                                }
              if(sr.eof()){
               sr.clear();
               sr.seekg(0);
               }

              studf.clear();
                                }
        sr.close();
gw.close();
gdw.close();
Form1->Close();
Form2->Close();
Form3->Close();
 */
}
//---------------------------------------------------------------------------


void __fastcall TForm2::FormShow(TObject *Sender)
{
/*
ComboBox1->Items->LoadFromFile("config\\students.txt");
if(ComboBox1->Items->Capacity == NULL){
                 Button5->Enabled = false;
                 } else { Button5->Enabled = true;
                        }

 */
}
//---------------------------------------------------------------------------


void __fastcall TForm2::FormClose(TObject *Sender, TCloseAction &Action)
{

sr.close();
gw.close();
gdw.close();
/*                Form1->Enabled = true;
              Form1->LScr.open("config\\laststudent.txt");
              Form3->Enabled = true;
              Form3->Memo1->Lines->LoadFromFile("config\\grafik.txt");
              last.clear();
              last = Form3->Memo1->Lines->Strings[dayinmon(month,year)-1].c_str();
              Form1->LScr<<last;
              Form1->LScr.close();
              Form1->Visible=true; */

}
//---------------------------------------------------------------------------

