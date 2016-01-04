using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public class DateStringToInt
{
    public DateStringToInt()
	{		
	}
    public static int[] StringToInt(string s)//yyyy/mm/dd
    {
        string date = s;
        int[] a = new int[3];
        string[] word=new string[3];
        if(s.Contains('/'))
            word = date.Split('/');
        else
            word = date.Split('-');
        a[0] = int.Parse(word[1]);
        a[1] = int.Parse(word[2]);
        a[2] = int.Parse(word[0]);
        return a;                                //mm/dd/yyyy
        //string date = s;
        //int[] a = new int[3];
        //int i = 0;
        //string[] words = date.Split('/');
        //foreach (string word in words)
        //{
        //    if (i == 2)
        //    {
        //        a[i] = int.Parse(word.Substring(0, 4));
        //    }
        //    else
        //        a[i] = int.Parse(word);
        //    i++;
        //}
        //return a;
    }
    public static int[] MDY(string s)//m/d/y
    {
        string date = s;
        int[] a = new int[3];
        int i = 0;
        string[] words = date.Split('/');
        foreach (string word in words)
        {
            if (i == 2)
            {
                a[i] = int.Parse(word.Substring(0, 4));
            }
            else
                a[i] = int.Parse(word);
            i++;
        }
        return a;//m/d/y
    }
    public static string GetDate(int yr)
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = 4;
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetPreviousFiscalYearEnd(int yr, int month)
    {
        int[] nepaliDate = new int[3];
        if (month < 4)
        {
            nepaliDate[0] = 4;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        else
        {
            nepaliDate[0] = 4;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr+1;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    
    public static string GetPreviousYr(string date) // Previous Date In English from Nepali Date
    {
        int[] dateint = new int[3];
        dateint = StringToInt(date);
        dateint[2]--;
        return (ConvertNE.ConvertNToE(dateint));
    }
    public static string GetPreviousYr1(string date) // Previous Date In English from Nepali Date
    {
        string[] dateint = new string[3];
        int[] date1 = new int[3];
        dateint = date.Split('/');
        if (int.Parse(dateint[1]) < 4)
        {
            date1[0] = 4;
            date1[1] = 1;
            date1[2] = int.Parse(dateint[0]) - 1;
        }
        else
        {
            date1[0] = 4;
            date1[1] = 1;
            date1[2] = int.Parse(dateint[0]);
        }
        string date2=ConvertNE.ConvertNToE(date1);
        return (date2);
    }
    public static string GetMonthOpening(int yr, int month) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = month;
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetWeekOpening(int yr, int month,int Week) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = month;
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        if (Week == 1)
        {
            nepaliDate[1] = 1;
        }
        else if (Week == 2)
        {
            nepaliDate[1] = 8;
        }
        else if (Week == 3)
        {
            nepaliDate[1] = 15;
        }
        else
        {
            nepaliDate[1] = 22;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetQuarterlyOpening(int yr, int quarter) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        if (quarter == 1)
        {
            nepaliDate[0] = 4;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        if (quarter == 2)
        {
            nepaliDate[0] = 7;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        if (quarter == 3)
        {
            nepaliDate[0] = 10;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        if (quarter == 4)
        {
            nepaliDate[0] = 1;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr+1;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
 
    public static string GetMonthOpening1(int yr, int month) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = 1;
        nepaliDate[1] = month;
        nepaliDate[2] = yr;
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetMonthOpenings2(int yr, int month) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        nepaliDate[0] = month;

        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetYearOpenings2(int yr, int month) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        nepaliDate[0] = 1;

        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetYearClosing2(int yr, int month) //Returns Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[1] = 1;
        nepaliDate[2] = yr+1;
        nepaliDate[0] = 1;

        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetMonthClosing1(int yr, int month) //Returns Next Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = month + 1;
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        if (nepaliDate[0] > 12)
        {
            nepaliDate[0] -= 12;
            nepaliDate[2]++;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetMonthClosing(int yr, int month) //Returns Next Month Opening Date in English
    {
        int[] nepaliDate = new int[3];
        nepaliDate[0] = month + 1;
        nepaliDate[1] = 1;
        nepaliDate[2] = yr;
        if (nepaliDate[0] > 12)
        {
            nepaliDate[0] -= 12;
            nepaliDate[2]++;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetQuaterlyClosing(int yr, int Quarter) //Returns Queterly Closing Date in English
    {
        int[] nepaliDate = new int[3];
        if (Quarter == 1)
        {
            nepaliDate[0] = 7;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        else if (Quarter == 2)
        {
            nepaliDate[0] = 10;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        else if (Quarter == 3)
        {
            nepaliDate[0] = 1;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr + 1;
        }
        else if (Quarter == 4)
        {
            nepaliDate[0] = 4;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr + 1;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static string GetHalfYearlyClosing(int yr, int HalfYear) //Returns Half Yearly Closing Date in English
    {
        int[] nepaliDate = new int[3];
        if (HalfYear == 1)
        {
            nepaliDate[0] = 10;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr;
        }
        else if (HalfYear == 2)
        {
            nepaliDate[0] = 4;
            nepaliDate[1] = 1;
            nepaliDate[2] = yr + 1;
        }
        return (ConvertNE.ConvertNToE(nepaliDate));
    }
    public static int getMonth(string s)
    {
        string date = s;
        int a = 0;
        string[] word = new string[3];
        if (s.Contains('/'))
            word = date.Split('/');
        else
            word = date.Split('-');
        a = int.Parse(word[1]);
        return a; 
    }
    public static int getYear(string s)
    {
        string date = s;
        int a = 0;
        string[] word = new string[3];
        if (s.Contains('/'))
            word = date.Split('/');
        else
            word = date.Split('-');
        a = int.Parse(word[0]);
        return a;
    }
    public static string AddMonths(int M, string date)
    {
        string OutPut = "";
        int Year = 0;
        int Month = 0;
        int Day = 0;
        string[] word = new string[3];
        if (date.Contains('/'))
            word = date.Split('/');
        else
            word = date.Split('-');
        Year = int.Parse(word[0]);
        Month = int.Parse(word[1]);
        Day = int.Parse(word[2]);
        Month = Month + M;
        if (Month > 12)
        {
            Month = Month - 12;
            Year = Year + 1;
        }
        OutPut = Year.ToString() + "/" + Month.ToString() + "/" + Day.ToString();
        return OutPut;
    }
    public DateTime GetNextMonth(DateTime d)
    {
        string nDate = ConvertNE.ConvertEToN(d);
        int[] a = DateStringToInt.StringToInt(nDate);
        a[0] = a[0] + 1;
        if (a[0] > 12)
        {
            a[0] = 1;
            a[2] = a[2] + 1;
        }
        else
            a[2] = a[2];
        return (DateTime.Parse(ConvertNE.ConvertNToE(a)));
    }

    public DateTime GetNextMonthStart(DateTime d)
    {
        string nDate = ConvertNE.ConvertEToN(d);
        int[] a = DateStringToInt.StringToInt(nDate);
        a[0] = a[0] + 1;
        a[1] = 1;
        if (a[0] > 12)
        {
            a[0] = 1;
            a[2] = a[2] + 1;
        }
        else
            a[2] = a[2];
        return (DateTime.Parse(ConvertNE.ConvertNToE(a)));
    }

    public DateTime GetNext14Days(DateTime d)
    {
        return d.AddDays(14);
    }
    public DateTime GetNext28Days(DateTime d)
    {
        return d.AddDays(28);
    }
}
