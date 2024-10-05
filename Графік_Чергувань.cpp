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
		nmonth[0] = "ѳ���"; 
		nmonth[1] = "������"; 
		nmonth[2]="�������"; 
		nmonth[3]="�����"; 
		nmonth[4]="������"; 
		nmonth[5]="������"; 
		nmonth[6]="�����"; 
		nmonth[7]="������";
		nmonth[8]="�������"; 
		nmonth[9]="������"; 
		nmonth[10]="���������";
		nmonth[11]="������"; 
		
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
		nwday[0] = "�����";
		nwday[1] = "��������";
		nwday[2] = "³������";
		nwday[3] = "������";
		nwday[4] = "������";
		nwday[5] = "�'������";
		nwday[6] = "������";
		
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
	
	cout<<"\n������� "<<day<<" "<<MonthName[0]<<" "<<year<<" ����, "<<DayName[0]<<".\n\n";
	
	cout<<"������ �� ����� �������:\n|	1.�������� ������� ������������.\n|	2.��� ������� ��������?\n|	3.�������� ������ ����\n|	4.�����\n";
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
			system("������_���������.exe");
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
