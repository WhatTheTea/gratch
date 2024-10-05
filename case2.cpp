#include <iostream>
#include <fstream>
#include <string>
#include <ctime>
#include <windows.h>

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

int main(){
	int buddays=0;
	
	time_t t;
		time(&t);
		int month=(localtime(&t)->tm_mon)+1;
		int day=localtime(&t)->tm_mday;
		int year=(localtime(&t)->tm_year)+1900;
		
			int numday=(month!=2?((month%2)^(month>7))+30:(!(year%400)||!(year%4)&&(year%25)?29:28)); //—колько дней в мес€це.
		
		for(int c=0,i=0; c<numday; c++) {
				i=WeekDay(year,month,c);
				if(i!=0 && i!=6) {
					buddays++;
				}
			}
			int *SDay = new int[buddays];
			string *Name = new string[buddays];
		
	ifstream dutyRead,DateRd;
		dutyRead.open("C:\\Duty.txt");
		DateRd.open("C:\\Date.txt");
		if(!dutyRead){
			cout<<"\nERROR | File not opened\n";
		} else {
		for(int c=0; !DateRd.eof();c++){
			DateRd >> SDay[c];
			dutyRead >> Name[c];
		}
	for(int c=0; c<buddays;c++){
		if(SDay[c]==day){
			cout<<"—ьогодн≥ чергуЇ "<<Name[c]<<"\n";
			break;
		}
	}
}
	system("√раф≥к_„ергувань.exe");
	return 0;
}
