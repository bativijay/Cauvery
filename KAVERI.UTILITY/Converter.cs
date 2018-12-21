// Decompiled with JetBrains decompiler
// Type: KAVERI.UTILITY.Converter
// Assembly: KAVERI.UTILITY, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30B6D42C-6CAF-4D99-B8C7-AB50ECD687DA
// Assembly location: C:\inetpub\wwwroot\Cauvery\Cauvery\bin\KAVERI.UTILITY.dll

using System;
using System.Text.RegularExpressions;

namespace KAVERI.UTILITY
{
  public class Converter
  {
    private string[] SingleDigitStringArray = new string[11]
    {
      "",
      "One",
      "Two",
      "Three",
      "Four",
      "Five",
      "Six",
      "Seven",
      "Eight",
      "Nine",
      "Ten"
    };
    private string[] DoubleDigitsStringArray = new string[10]
    {
      "",
      "Ten",
      "Twenty",
      "Thirty",
      "Forty",
      "Fifty",
      "Sixty",
      "Seventy",
      "Eighty",
      "Ninety"
    };
    private string[] TenthDigitStringArray = new string[10]
    {
      "Ten",
      "Eleven",
      "Tweleve",
      "Thirteen",
      "Fourteen",
      "Fifteen",
      "Sixteen",
      "Seventeen",
      "Eighteen",
      "Nineteen"
    };
    private string[] HigherDigitEnglishStringArray = new string[9]
    {
      "",
      "",
      "Hundred",
      "Thousand",
      "Million",
      "Billion",
      "Trillion",
      "Quadrillion",
      "Quintillion"
    };
    private string[] HigherDigitAsianStringArray = new string[8]
    {
      "",
      "",
      "Hundred",
      "Thousand",
      "Lakh",
      "Karod",
      "Arab",
      "Kharab"
    };
    private string[] EnglishCodeArray = new string[3]
    {
      "1",
      "22",
      "3"
    };
    private string[] AsianCodeArray = new string[13]
    {
      "1",
      "22",
      "3",
      "4",
      "42",
      "5",
      "52",
      "6",
      "62",
      "7",
      "72",
      "8",
      "82"
    };
    private long m_amount;
    private Converter.ConvertStyle m_style;

    public long Amount
    {
      get
      {
        return this.m_amount;
      }
    }

    public Converter.ConvertStyle Style
    {
      get
      {
        return this.m_style;
      }
    }

    public Converter(long amount, Converter.ConvertStyle style)
    {
      this.m_amount = amount;
      this.m_style = style;
    }

    public string ConvertTo()
    {
      string str = string.Empty;
      switch (this.Style)
      {
        case Converter.ConvertStyle.Asian:
          str = "Rupees " + (string) this.AsianStyle() + " Only";
          break;
        case Converter.ConvertStyle.English:
          str = "Rupees " + (string) this.EnglishStyle() + " Only";
          break;
      }
      return str;
    }

    private object EnglishStyle()
    {
      if (this.Amount == 0L)
        return (object) "Zero";
      string str1 = this.Amount.ToString();
      string word = string.Empty;
      string str2 = string.Empty;
      int num1 = 3;
      string str3 = str1;
      int num2 = 0;
      do
      {
        bool flag = false;
        if (num1 > 3)
          flag = true;
        if (str3.Length >= 4)
          str3 = str1.Substring(str1.Length - num1, 3);
        if (flag && Convert.ToInt32(str3) != 0)
          word = this.ThreeDigitsConverter(Convert.ToInt32(str3)) + " " + this.HigherDigitEnglishStringArray[num1 / 3 + 1] + " " + word;
        else
          word = this.ThreeDigitsConverter(Convert.ToInt32(str3));
        num2 += str3.Length;
        str3 = str1.Substring(0, str1.Length - num2);
        num1 += 3;
      }
      while (str1.Length > num2);
      return (object) this.RemoveSpaces(word);
    }

    private string ThreeDigitsConverter(int amount)
    {
      string str1 = amount.ToString();
      int[] numArray = new int[str1.Length];
      int length1 = numArray.Length;
      while (length1 >= 1)
      {
        numArray[length1 - 1] = Convert.ToInt32(str1.Substring(length1 - 1, 1));
        length1 += -1;
      }
      string str2 = string.Empty;
      string str3 = string.Empty;
      string str4 = string.Empty;
      string str5 = string.Empty;
      int length2 = numArray.Length;
      while (length2 >= 1)
      {
        int index1 = numArray.Length - length2;
        int index2 = numArray[index1];
        string str6 = this.EnglishCodeArray[length2 - 1];
        string str7 = this.HigherDigitEnglishStringArray[Convert.ToInt32(str6.Substring(0, 1)) - 1];
        if (str6 == "1")
          str2 = str2 + str3 + this.SingleDigitStringArray[index2];
        else if (str6.Length == 2 & index2 != 0)
        {
          if (index2 == 1)
          {
            int index3 = numArray[index1 + 1];
            str2 = str2 + str3 + this.TenthDigitStringArray[index3] + " " + str7;
            --length2;
          }
          else
            str2 = str2 + str3 + this.DoubleDigitsStringArray[index2] + " " + str7;
        }
        else if (index2 != 0)
          str2 = str2 + str3 + this.SingleDigitStringArray[index2] + " " + str7;
        str3 = " ";
        length2 += -1;
      }
      return str2;
    }

    private object AsianStyle()
    {
      string str1 = this.Amount.ToString();
      if (this.Amount == 0L)
        return (object) "Zero";
      if (str1.Length > 13)
        return (object) "That's too long...";
      int[] numArray = new int[str1.Length];
      int length1 = numArray.Length;
      while (length1 >= 1)
      {
        numArray[length1 - 1] = Convert.ToInt32(str1.Substring(length1 - 1, 1));
        length1 += -1;
      }
      string word = "";
      string str2 = "";
      int length2 = numArray.Length;
      while (length2 >= 1)
      {
        int index1 = numArray.Length - length2;
        int index2 = numArray[index1];
        string str3 = this.AsianCodeArray[length2 - 1];
        string str4 = this.HigherDigitAsianStringArray[Convert.ToInt32(str3.Substring(0, 1)) - 1];
        if (str3 == "1")
          word = word + str2 + this.SingleDigitStringArray[index2];
        else if (str3.Length == 2 & index2 != 0)
        {
          int index3 = numArray[index1 + 1];
          if (index2 == 1)
          {
            word = word + str2 + this.TenthDigitStringArray[index3] + " " + str4;
            --length2;
          }
          else if (index3 == 0)
            word = word + str2 + this.DoubleDigitsStringArray[index2] + " " + str4;
          else
            word = word + str2 + this.DoubleDigitsStringArray[index2];
        }
        else if (index2 != 0)
          word = word + str2 + this.SingleDigitStringArray[index2] + " " + str4;
        str2 = " ";
        length2 += -1;
      }
      return (object) this.RemoveSpaces(word);
    }

    private string RemoveSpaces(string word)
    {
      return new Regex("  ").Replace(word, " ").Trim();
    }

    public enum ConvertStyle
    {
      Asian,
      English,
    }
  }
}
