//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <string.h>
#include <iostream.h>
#include <ctime.h>
#include <ExtCtrls.hpp>
#include <ActnCtrls.hpp>
#include <ActnMan.hpp>
#include <ActnMenus.hpp>
#include <ToolWin.hpp>
#include <fstream.h>
#include <sstream.h>
#include <Buttons.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TBevel *Bevel1;
        TLabel *Label1;
        TLabel *Label2;
        TEdit *Edit1;
        TButton *Button1;
        TButton *Button2;
        TLabel *Label3;
        TSpeedButton *SpeedButton1;
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall Button2Click(TObject *Sender);
        void __fastcall SpeedButton1Click(TObject *Sender);
        void __fastcall FormShow(TObject *Sender);
private:	// User declarations
string edit,student,gdate;
time_t t;
int day;
int year;
int month;
long fsize;
int date;

public:		// User declarations
ifstream GrafRead,StudRead,LSr,grdr;
ofstream StudCreate,GFcr,LScr,gwd;

bool is_empty(std::ifstream& pFile)
{
    return pFile.peek() == std::ifstream::traits_type::eof();
}

string IntToCString(int a)
{
    ostringstream temp;
    temp << a;
    return temp.str();
}

int dayinmon(int Dmonth,int Dyear){
return (Dmonth!=2?((Dmonth%2)^(Dmonth>7))+30:(!(Dyear%400)||!(Dyear%4)&&(Dyear%25)?29:28));
}

AnsiString MonthNameUKR(){

	time_t t;
		time(&t);
		int month=(localtime(&t)->tm_mon)+1;

	AnsiString nmonth[12];
		nmonth[0] = "Січня";
		nmonth[1] = "Лютого";
		nmonth[2]="Березня";
		nmonth[3]="Квітня";
		nmonth[4]="Травня";
		nmonth[5]="Червня";
		nmonth[6]="Липня";
		nmonth[7]="Серпня";
		nmonth[8]="Вересня";
		nmonth[9]="Жовтня";
		nmonth[10]="Листопада";
		nmonth[11]="Грудня";

	return nmonth[month-1];
}

int WeekDay(int iYear,int iMonth,int iDay) {
	// Month:  March   -  3 ... December - 12 of Current  Year
	//         January - 13,    February - 14 of Previous Year
	if (iMonth < 3) {
		iMonth += 12;
		--iYear;
	}

	int   N1 = (26 * (iMonth + 1)) / 10;
	int   N2 = (125 * iYear) / 100;

	int   N3 = iDay + N1 + N2 - (iYear / 100) + (iYear / 400) - 1;

	return N3 % 7;
}

AnsiString DayNameUKR(){
	time_t t;
		time(&t);
		int month=(localtime(&t)->tm_mon)+1;
		int day=localtime(&t)->tm_mday;
		int year=(localtime(&t)->tm_year)+1900;
		int WDay=WeekDay(year,month,day);

	AnsiString nwday[7];
		nwday[0] = "Неділя";
		nwday[1] = "Понеділок";
		nwday[2] = "Вівторок";
		nwday[3] = "Середа";
		nwday[4] = "Четвер";
		nwday[5] = "П'ятниця";
		nwday[6] = "Субота";
		
	return nwday[WDay];
}

        __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------



#endif
 