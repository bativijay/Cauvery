using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Win32;
using System.IO;

using System.Web.UI;

/// <summary>
/// Summary description for Common
/// </summary>
public static class CommonClass
{
    public static DataTable GetGroupedBy(DataTable dt, string columnNamesInDt, string groupByColumnNames, string typeOfCalculation)
    {
        //Return its own if the column names are empty
        if (columnNamesInDt == string.Empty || groupByColumnNames == string.Empty)
        {
            return dt;
        }

        //Once the columns are added find the distinct rows and group it bu the numbet
        DataTable _dt = dt.DefaultView.ToTable(true, groupByColumnNames);

        //The column names in data table
        string[] _columnNamesInDt = columnNamesInDt.Split(',');

        for (int i = 0; i < _columnNamesInDt.Length; i = i + 1)
        {
            if (_columnNamesInDt[i] != groupByColumnNames)
            {
                _dt.Columns.Add(_columnNamesInDt[i]);
            }
        }

        //Gets the collection and send it back
        for (int i = 0; i < _dt.Rows.Count; i = i + 1)
        {
            for (int j = 0; j < _columnNamesInDt.Length; j = j + 1)
            {
                if (_columnNamesInDt[j] != groupByColumnNames)
                {
                    _dt.Rows[i][j] = dt.Compute(typeOfCalculation + "(" + _columnNamesInDt[j] + ")", groupByColumnNames + " = '" + _dt.Rows[i][groupByColumnNames].ToString() + "'");
                }
            }
        }

        return _dt;
    }
    public static void LoadDropdownList(
                                        DropDownList ddl,
                                        DataTable dt,
                                        string textFiled,
                                        string valueFiled
                                        )
    {
        ddl.DataSource = dt;
        ddl.DataValueField = valueFiled;
        ddl.DataTextField = textFiled;
        if (dt.Rows.Count > 0)
        {
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("- Select - ", "-1"));
        }
    }

    public static void LoadDropdownListWithoutSelect(
                                       DropDownList ddl,
                                       DataTable dt,
                                       string textFiled,
                                       string valueFiled
                                       )
    {
        ddl.DataSource = dt;
        ddl.DataValueField = valueFiled;
        ddl.DataTextField = textFiled;
        ddl.DataBind();
    }


    public static bool WriteToRegistry(string KeyName, object Value)
    {
        try
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\KAVERI"))
            {
                key.SetValue(KeyName, Value);
            }
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public static string ReadSubKeyValue(string subKey, string key)
    {
        string str = string.Empty;
        using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(subKey))
        {
            if (registryKey != null)
            {
                str = registryKey.GetValue(key).ToString();
                registryKey.Close();
            }
        }
        return str;
    }


}


public class WriteLogFile
{
    public static bool WriteLog(string strFileName, string strMessage)
    {
        try
        {
            FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), strFileName), FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
            objStreamWriter.WriteLine(strMessage);
            objStreamWriter.Close();
            objFilestream.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = HttpContext.Current.Server.MapPath("~/ErrorLog/ErrorLog.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
}
