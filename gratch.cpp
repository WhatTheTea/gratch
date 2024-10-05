#include <iostream>
#include <windows.h>
#include <ctime>
#include <string>

using namespace std;

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

string MonthNameUKR(){
	time_t t;
		time(&t);
		int month=localtime(&t)->tm_mon;
	
	string nmonth[12];
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
		
	return nmonth[month];
}

string DayNameUKR(){
	time_t t;
		time(&t);
		int month=(localtime(&t)->tm_mon)+1;
		int day=localtime(&t)->tm_mday;
		int year=(localtime(&t)->tm_year)+1900;
		int WDay=WeekDay(year,month,day);
	
	string nwday[7];
		nwday[0] = "Неділя";
		nwday[1] = "Понеділок";
		nwday[2] = "Вівторок";
		nwday[3] = "Середа";
		nwday[4] = "Четвер";
		nwday[5] = "П'ятниця";
		nwday[6] = "Субота";
		
	return nwday[WDay];
}	

int main(){
		SetConsoleCP(1251);
		SetConsoleOutputCP(1251);
		
	time_t t;
		time(&t);
		int month=(localtime(&t)->tm_mon)+1;
		int day=localtime(&t)->tm_mday;
		int year=(localtime(&t)->tm_year)+1900;
		
	int choose;
		
string MonthName[1],DayName[1];
	MonthName[0] = MonthNameUKR();
	DayName[0] = DayNameUKR();
	
	cout<<"\nСьогодні "<<day<<" "<<MonthName[0]<<" "<<year<<" року, "<<DayName[0]<<".\n\n";
	
	cout<<"Оберіть що бажаєтє зробити:\n|	1.Провести первинні налаштування.\n|	2.Хто сьогодні черговий?\n|	3.Видалити список учнів\n|	4.Вихід\n";
	cout<<"\n";
	cin>>choose;
	switch(choose){
		case 1:{
			system("case1.exe");
			break;
		}
		case 2:{
			system("case2.exe");
			break;
		}
		case 3:{
			remove("C:\\Duty.txt");
			system("Графік_Чергувань.exe");
			break;
		}
		case 4:{
			system("pause");
			return 0;
			break;
		}
		default: cout<<"Wrong input!\nExpected [1-4]\n";
		system("pause");
	}
	
		return 0;
}
