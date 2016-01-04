using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Formatting_Text
{
    static string[] check = new string[2];
    static int n, g;
    static bool IsNegative = false;
    public static string Insert_Commas(string Text)
    {
        if (Text == "")
            return Text;
        if (Text.IndexOf('-')>=0)
        {
            Text = Text.Trim('-');
            IsNegative = true;
        }
        else
            IsNegative = false;
        check = Text.Split('.');


        n = check[0].Length;
        g = n - 3;

        for (; g > 0; g -= 2)
        {
            check[0] = check[0].Insert(g, ",");

        }
        string test= string.Join(".", check);
        if (IsNegative)
            test = '-' + test;
        return test;
    }

    public static string Remove_Commas(string text)
    {
        string temp = text;

        while (temp.IndexOf(',') >= 0)
        {
            int i = temp.IndexOf(',');
            temp = temp.Remove(i, 1);
        }
        return temp;
    }

    
}