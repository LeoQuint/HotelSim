﻿public enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, NumberOfWeekdays }
public enum months{ January, February, March, April, May, June, July, August, September, October, November, December }
[System.Serializable]
public class Date
{
	public int year;
	public int dayOfTheMonth;
	public WeekDays day;
	public months month;
	public int numberOfWeeks;

    public Date(){ }

    public Date(int currentYear, int dayOTM, WeekDays dayP, months monthP, int numberOfWeeks)
    {
        this.year = currentYear;
        this.dayOfTheMonth = dayOTM;
        this.day = dayP;
        this.month = monthP;
        this.numberOfWeeks = numberOfWeeks;
    }
    public Date deepCopy()
    {
		Date newdate = new Date();
		newdate.year = this.year;
		newdate.dayOfTheMonth = this.dayOfTheMonth;
		newdate.day = this.day;
		newdate.month = this.month;
		newdate.numberOfWeeks = this.numberOfWeeks;
		return newdate;
	}
  
	
}
public static class Calendar {

	private static Date currentDate = new Date(2017, 1, WeekDays.Sunday, months.January, Calendar.GetNumberOfWeeksInMonth(0));
	private static int dayOfTheYear = 1;

	public static void addDay()
	{
        if (currentDate.day < WeekDays.Sunday)
            currentDate.day++;
		else
            currentDate.day = WeekDays.Monday;


        switch (currentDate.month) 
		{
		case months.January:
			checkMonth(31);
			break;
		case months.February:
            if (currentDate.year % 4 == 0)
				checkMonth(29);
			else
			checkMonth(28);
			break;
		case months.March:
			checkMonth(31);
			break;
		case months.April:
			checkMonth(30);
			break;
		case months.May:
			checkMonth(31);
			break;
		case months.June:
			checkMonth(30);
			break;
		case months.July:
			checkMonth(31);
			break;
		case months.August:
			checkMonth(31);
			break;
		case months.September:
			checkMonth(30);
			break;
		case months.October:
			checkMonth(31);
			break;
		case months.November:
			checkMonth(30);
			break;
		case months.December:
			checkMonth(31);
			break;
		}

	}
	static void checkMonth(int numDays){
		if (currentDate.dayOfTheMonth == numDays && currentDate.month != months.December) {
			currentDate.month++;
			dayOfTheYear++;
			currentDate.dayOfTheMonth = 1;
		}
		else if (currentDate.dayOfTheMonth == numDays && currentDate.month == months.December) {
			currentDate.month = months.January;
			currentDate.dayOfTheMonth = 1;
			currentDate.year++;
			dayOfTheYear = 1;
		}
		else
		{
			currentDate.dayOfTheMonth++;
			dayOfTheYear++;
		}
	}

	public static Date GetDate()
	{
		return currentDate;
	}
    public static void SetDate(Date newDate)
    {
        currentDate = newDate;
    }
	public static int GetDayOfTheYear()
	{
		return dayOfTheYear;
	}
    //returns the number of weeks in the current month.
	public static int GetNumberOfWeeksInMonth()
	{
		int[] numWeekInMonth = new int[12]{4,4,5,4,5,4,4,5,4,4,5,5};
		return numWeekInMonth[(int)currentDate.month];
	}
    //overloaded method to return the number of weeks in selected month.
    public static int GetNumberOfWeeksInMonth(int period) 
    {
        int[] numWeekInMonth = new int[12] { 4, 4, 5, 4, 5, 4, 4, 5, 4, 4, 5, 5 };
        return numWeekInMonth[period];
    }
    public static Date GetEndOfPeriodDate(int period) 
    {
        Date toReturn = new Date();

        for (int i = 0; i < period; i++)
        {
            int weeksInPeriod = GetNumberOfWeeksInMonth(i%12);
            for (int j = 0; j < weeksInPeriod; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    if (toReturn.day < WeekDays.Sunday)
                        toReturn.day++;
                    else
                        toReturn.day = WeekDays.Monday;

                    switch (currentDate.month)
                    {
                        case months.January:
                            checkMonth(31, toReturn);
                            break;
                        case months.February:
                            if (toReturn.year % 4 == 0)
                                checkMonth(29, toReturn);
                            else
                                checkMonth(28, toReturn);
                            break;
                        case months.March:
                            checkMonth(31, toReturn);
                            break;
                        case months.April:
                            checkMonth(30, toReturn);
                            break;
                        case months.May:
                            checkMonth(31, toReturn);
                            break;
                        case months.June:
                            checkMonth(30, toReturn);
                            break;
                        case months.July:
                            checkMonth(31, toReturn);
                            break;
                        case months.August:
                            checkMonth(31, toReturn);
                            break;
                        case months.September:
                            checkMonth(30, toReturn);
                            break;
                        case months.October:
                            checkMonth(31, toReturn);
                            break;
                        case months.November:
                            checkMonth(30, toReturn);
                            break;
                        case months.December:
                            checkMonth(31, toReturn);
                            break;
                    }
                }
            }
        }
        return toReturn;
    }
    static void checkMonth(int numDays, Date myDate)
    {
        if (myDate.dayOfTheMonth == numDays && myDate.month != months.December)
        {
            myDate.month++;
            myDate.dayOfTheMonth = 1;
        }
        else if (myDate.dayOfTheMonth == numDays && myDate.month == months.December)
        {
            myDate.month = months.January;
            myDate.dayOfTheMonth = 1;
            myDate.year++;
        }
        else
            myDate.dayOfTheMonth++;
    }
}
