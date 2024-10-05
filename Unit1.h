//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <Grids.hpp>
#include <ValEdit.hpp>
//---------------------------------------------------------------------------
#include <iostream.h>
#include <string.h>
#include <vector.h>
#include <ctime.h>
#include <fstream.h>
#include <ExtCtrls.hpp>

//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TEdit *Edit1;
        TGroupBox *GroupBox2;
        TGroupBox *GroupBox3;
        TEdit *Edit2;
        TLabel *Label2;
        TRadioButton *RadioButton1;
        TRadioButton *RadioButton2;
        TButton *Button1;
        TListBox *ListBox1;
        TSpeedButton *SpeedButton1;
        TSpeedButton *SpeedButton2;
        TButton *Button2;
        TGroupBox *GroupBox4;
        TButton *Button3;
        TSpeedButton *SpeedButton3;
        TStringGrid *StringGrid1;
        TEdit *Edit3;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall Button3Click(TObject *Sender);
        void __fastcall SpeedButton3Click(TObject *Sender);
        void __fastcall FormKeyPress(TObject *Sender, char &Key);
        void __fastcall SpeedButton1Click(TObject *Sender);
        void __fastcall SpeedButton2Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
private:        // User declarations



public:
ofstream NewStudent;
ifstream ReadStudent;
vector<AnsiString> StudentVect;
string strbuff,strmas[30],strbuff2;
int intbuff,day,month,year,daysV;
AnsiString Ansibuff;
time_t t;
		// User declarations
int dayinmon(int Dmonth,int Dyear){
return (Dmonth!=2?((Dmonth%2)^(Dmonth>7))+30:(!(Dyear%400)||!(Dyear%4)&&(Dyear%25)?29:28));
        }

        bool is_empty(std::ifstream& pFile)
{
    return pFile.peek() == std::ifstream::traits_type::eof();
}

void beginning(){
ReadStudent.open("students.txt");
ReadStudent.clear();
ReadStudent >> strbuff;
if(ReadStudent.is_open()&&strbuff!=""){
ListBox1->Items->LoadFromFile("students.txt");
strbuff.clear();
}
ReadStudent.close();

        StringGrid1->RowCount = dayinmon(month+1,year)+1;
        StringGrid1->Cells[0][0] = "День";
        StringGrid1->Cells[1][0] = "Студент";
        for(int i = 0;i<dayinmon(month+1,year);i++){
        StringGrid1->Cells[0][i+1] = i+1;
        }
        ReadStudent.open("grafik.txt");
        ReadStudent.clear();
        if(ReadStudent.is_open() && !is_empty(ReadStudent)){
                NewStudent.open("laststud.txt");
                NewStudent.clear();                           // Spisok tipa 1
                for(int i = 0;i<dayinmon(month+1,year);i++){                      //2 bez dat, ibo vse
                        getline(ReadStudent,strbuff,'.');
                        Ansibuff = strbuff.c_str();
                       // ReadStudent >> Ansibuff.c_str();                         //3 mozhno sdelat
                        StringGrid1->Cells[1][i+1] = Ansibuff;
                        }
                        //-----------------------------------------?
                        Ansibuff = StringGrid1->Cells[1][dayinmon(month+1,year)];
                        NewStudent << Ansibuff.c_str();
                        strbuff = "";
                         ReadStudent.close();  //
                         ReadStudent.open("students.txt");
                         ReadStudent.clear();
                        for(intbuff=0;Ansibuff!=strbuff.c_str();intbuff++){
                        if(intbuff>ListBox1->Items->Capacity){
                                intbuff=0;
                                }
                        getline(ReadStudent,strbuff,'.');
                        }
                  ReadStudent.close();
                  ReadStudent.open("grafik.txt");
                  ReadStudent.clear();
                  /////////////////////////////////////???????????????????????????????
                 for(int i = 0;i!=day;i++){
                getline(ReadStudent,strbuff2);
                }
                Edit1->Text = strbuff2.c_str();                                        //4 cherez int i v for
                } else {
                        for(int i = 0;i<dayinmon(month+1,year);i++){
                        StringGrid1->Cells[1][i+1] = "Студент" + IntToStr(i+1);
                        }
                  }
                  ReadStudent.close();
         NewStudent.close();
         strbuff.clear();
         strbuff2.clear();

}

void wtraf(int month,int year,int daysV){
ReadStudent.open("grafik.txt");
ReadStudent.clear();
        for(int i = 0;i<dayinmon(month+1,year) ;i++){
         getline(ReadStudent,strbuff2);
        StudentVect.push_back(strbuff2.c_str());
        }
ReadStudent.close();
}

        __fastcall TForm1(TComponent* Owner);
};



//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
