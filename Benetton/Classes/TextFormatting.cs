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
using System.Data.SqlClient;

public class TextFormatting
{
    public TextFormatting()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // by ram babu
    public static void RemoveZerroForLabel(Label l)
    {
        if (l != null)
        {
            if (l.Text == "")
                l.Text = "0";
            if (Convert.ToDecimal(l.Text) == 0)
            {
                l.Text = "";
            }
            else if (Convert.ToDecimal(l.Text) != 0)
            {
                l.Text = Formatting_Text.Insert_Commas(Convert.ToDecimal(l.Text).ToString("0.00"));
            }
        }

    }

    public static void RemoveZerroForText(TextBox t)
    {
        if (t != null)
        {
            if (t.Text == "")
                t.Text = "0";

            if (Convert.ToDecimal(t.Text) == 0)
            {
                t.Text = "0";
            }
            else if (Convert.ToDecimal(t.Text) != 0)
            {
                t.Text = Formatting_Text.Insert_Commas(Convert.ToDecimal(t.Text).ToString("0.00"));
            }
        }
    }


    public static void RemoveZerroForLabel1(Label l)
    {
        if (l != null)
        {
            if (l.Text == "")
                l.Text = "0";

            if (Convert.ToDecimal(l.Text) == 0)
            {
                l.Text = "";
            }
        }

    }

    public static void RemoveZerroForText1(TextBox t)
    {
        if (t != null)
        {
            if (t.Text == "")
                t.Text = "0";

            if (Convert.ToDecimal(t.Text) == 0)
            {
                t.Text = "0";
            }
        }
    }

   
}