#include <iostream>
#include <string>
#include <fstream>
#include <windows.h>
#include <ctime>

using namespace std;

int WeekDay(int iYear, int iMonth, int iDay) {
	// Month:  March   -  3 ... December - 12 of Current  Year
	//         January - 13,    February - 14 of Previous Year
	if (iMonth < 3) {
		// If January or February, adjust Month and Year
		iMonth += 12;
		--iYear;
	}

	int   N1 = (26 * (iMonth + 1)) / 10;    // Month Shift
	int   N2 = (125 * iYear) / 100;         // Leap Correction

	int   N3 = iDay + N1 + N2 - (iYear / 100) + (iYear / 400) - 1;

	return N3 % 7;
}

int main() {
	time_t t;
	time(&t);
	int month = (localtime(&t)->tm_mon) + 1;
	int day = localtime(&t)->tm_mday;
	int year = (localtime(&t)->tm_year) + 1900;

	int numday = (month != 2 ? ((month % 2) ^ (month > 7)) + 30 : (!(year % 400) || !(year % 4) && (year % 25) ? 29 : 28)); //Сколько дней в месяце.

	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int students = 0, buddays = 0, choose;

	ofstream StudWr, DateWr;
	StudWr.open("C:\\Students.txt");
	DateWr.open("C:\\Date.txt");
	for (int c = 0, i = 0; c < numday; c++) {
		i = WeekDay(year, month, c);
		if (i != 0 && i != 6) {
			buddays++;
		}
	}
	int* budday = new int[buddays];
	for (int c = 1, i = 0, d = 0; c < numday; c++) {
		i = WeekDay(year, month, c);
		if (i > 0 && i < 6) {
			d++;
			budday[d] = c;
		}
	}

	ifstream dutyRead;
	dutyRead.open("C:\\Duty.txt");
	if (!dutyRead) {  //File not opened
		ofstream dutyWrite;
		dutyWrite.open("C:\\Duty.txt");
		if (!dutyWrite) {
			cout << "\nПомилка! Не вдається створити файл" << endl;
		}
		else {
			cout << "\nВведіть кількість учнів: " << endl;
			cin >> students;
			string* student = new string[students];
			cout << "Введіть ПІБ учнів: \n";
			for (int c = 0, i = 1; c < students; c++, i++) {
				cout << i << ". ";
				cin >> student[c];
				StudWr << student[c] << "\n";
			}
			for (int count = 1, i = 0, c = 1; count < buddays; count++, i++, c++) {
				if (i == students) {
					i = 0;
				}
				dutyWrite << student[i] << endl;
				DateWr << budday[c] << endl;
			}
		}
		cout << "Первинні налаштування успішно завершені. \n";
		dutyWrite.close();
	}
	else {    //File opened
		cout << "\nПервинні налаштування вже успішно завершені! \n";
		cout << "Бажаєте оновити дати?\n	1.Так.\n	2.Ні.\n";
		cin >> choose;
		switch (choose) {
		case 1: {
			for (int count = 1; count < buddays; count++) {
				DateWr << budday[count] << endl;
			}
			break;
		}
		default: dutyRead.close();
			system("Графік_Чергувань.exe");
			return 0;
		}
	}
	dutyRead.close();
	system("Графік_Чергувань.exe");
	return 0;
}
