//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit3.h"
#include "Unit1.h"
#include "Unit2.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm3 *Form3;

//---------------------------------------------------------------------------
__fastcall TForm3::TForm3(TComponent* Owner)
        : TForm(Owner)
{
 time(&t);
        month=(localtime(&t)->tm_mon)+1;
        day=localtime(&t)->tm_mday;
        year=(localtime(&t)->tm_year)+1900;

        if(Form1->grdr && Form1->GrafRead){
                Memo1->Lines->LoadFromFile("config\\grafik.txt");
                Memo2->Lines->LoadFromFile("config\\grafikdate.txt");
                }

       
}
//---------------------------------------------------------------------------







void __fastcall TForm3::FormShow(TObject *Sender)
{
Memo1->Lines->LoadFromFile("config\\grafik.txt");
                Memo2->Lines->LoadFromFile("config\\grafikdate.txt");
                Memo1->Lines->Delete(Form1->dayinmon(month,year)+1);
}
//---------------------------------------------------------------------------

void __fastcall TForm3::FormClose(TObject *Sender, TCloseAction &Action)
{

while(Memo1->Lines->Capacity > Form1->dayinmon(month,year)){
if(Memo1->Lines->Capacity > Form1->dayinmon(month,year)){
        for(int i=Form1->dayinmon(month,year);i<Memo1->Lines->Capacity;i++){
                Memo1->Lines->Delete(i);
                }
        }
   }
Memo1->Lines->SaveToFile("config\\grafik.txt");

                Form3->Visible=false;
                Form1->Visible=true;

                Form1->grdr.close();
                Form1->GrafRead.close();

}
//---------------------------------------------------------------------------

