//---------------------------------------------------------------------------

#ifndef Unit2H
#define Unit2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Grids.hpp>
#include <ComCtrls.hpp>
#include <fstream.h>
#include <ExtCtrls.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TForm2 : public TForm
{
__published:	// IDE-managed Components
        TEdit *Edit1;
        TComboBox *ComboBox1;
        TButton *Button3;
        TButton *Button4;
        TButton *Button5;
        TButton *Button1;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button4Click(TObject *Sender);
        void __fastcall Button3Click(TObject *Sender);
        void __fastcall Button5Click(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
ifstream sr;
time_t t;
int day;
int year;
int month;
//Files
ofstream gw,sw,gdw;
string studf,last;
public:		// User declarations

int dayinmon(int Dmonth,int Dyear){
return (Dmonth!=2?((Dmonth%2)^(Dmonth>7))+30:(!(Dyear%400)||!(Dyear%4)&&(Dyear%25)?29:28));
}



        __fastcall TForm2(TComponent* Owner);
};

//---------------------------------------------------------------------------
extern PACKAGE TForm2 *Form2;
//---------------------------------------------------------------------------
#endif
