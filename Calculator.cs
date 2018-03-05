using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class Calculator
{


    public static float LinearSequnce(int levelNumber, float baseNumber, float plusNumber)
    {
        float sum = baseNumber;
        for (int i = 0; i < levelNumber; i++)
        {
            sum += plusNumber;
        }
        return sum;
    }
    public static bool probability(float n)
    {
        if (n > 100)
        {
            n = 100;
        }

        int x = UnityEngine.Random.Range(1, 101);
        if (x <= (int)n)
            return true;

        return false;
    }
    
    public static string ToMinuteSeccond(TimeSpan span)
    {
        return new DateTime(span.Ticks).ToString("mm:ss");
    }
    public static string ToMinuteSeccond(int seccond)
    {
        TimeSpan span = TimeSpan.FromSeconds(seccond);
        return new DateTime(span.Ticks).ToString("mm:ss");
    }
    public static string ToHoursMinute(TimeSpan span)
    {
        return new DateTime(span.Ticks).ToString("HH:mm");
    }
    public static string ToHoursMinuteSecconds(TimeSpan span)
    {
        return new DateTime(span.Ticks).ToString("HH:mm:ss");
    }
    public static string ToReadableString(TimeSpan span)
    {
        string formatted = string.Format("{0}{1}{2}{3}",
            span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
            span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
            span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
            span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty);

        if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

        if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

        return formatted;
    }
    /// <summary>
    /// if  day>1  format dd-HH:mm
    ///else if  HH>1  format HH:mm
    ///else   format mm:ss
    /// </summary>
    /// <param name="timeToDie"></param>
    /// <returns></returns>
    public static string ConvertToBestFormat(TimeSpan timeToDie,TypeWrite type)
    {
        if (timeToDie.Days >= 1)
        {
            if (type==TypeWrite.Symbol)
            {
                return String.Format("{0}:{1}:{2}'", timeToDie.Days, timeToDie.Hours, timeToDie.Minutes);
            }
            if (type == TypeWrite.Alphabet)
            {
                return String.Format("{0}h:{1}m:{2}s", timeToDie.Days, timeToDie.Hours, timeToDie.Minutes);
            }
            return String.Format("{0}:{1}:{2}'", timeToDie.Days, timeToDie.Hours, timeToDie.Minutes);
        }
        else if (timeToDie.Hours >= 1)
        {
            if (type == TypeWrite.Symbol)
            {
                return String.Format("{0}:{1}'", timeToDie.Hours, timeToDie.Minutes);
            }
            if (type == TypeWrite.Alphabet)
            {
                return String.Format("{0}m:{1}s", timeToDie.Hours, timeToDie.Minutes);
            }
            return String.Format("{0}:{1}'", timeToDie.Hours, timeToDie.Minutes);
            //return new DateTime(timeToDie.Ticks).ToString("HH:mm'");
        }
        else
        {
            if (type == TypeWrite.Symbol)
            {
                return String.Format("{0}':{1}''", timeToDie.Minutes, timeToDie.Seconds);
            }
            if (type == TypeWrite.Alphabet)
            {
                return String.Format("{0}m:{1}s", timeToDie.Minutes, timeToDie.Seconds);
            }
            return String.Format("{0}':{1}''", timeToDie.Minutes, timeToDie.Seconds);
            //return new DateTime(timeToDie.Ticks).ToString("mm':ss\"");
        }
    }

   public enum TypeWrite
    {
        Symbol,
        Alphabet,
    }
    public static string ConvertToBestFormat(int seccond,TypeWrite type)
    {
        TimeSpan ts = TimeSpan.FromSeconds(seccond);
        return ConvertToBestFormat(ts, type);
    }
    /// <summary>
    /// check user name between min -max 
    /// [a-zA-Z]{min,max}
    /// </summary>
    /// <param name="t">string to check match pattern</param>
    /// <returns></returns>
    public static bool CheckUserNameCount(string t,int minNumber,int maxNumber)
    {


        string pattern = @"^[a-zA-Z]{"+minNumber+","+maxNumber+"}$";
        Regex reg = new Regex(pattern);

        if (reg.IsMatch(t))
        {

            return true;
        }
        else
        {
            return false;

        }
    }
    /*
    public static int probabilityAccu(List<enemy_Factory.IntInt> chances)
    {
        int index = 0;
        int max = 0;
        foreach (var item in chances)
        {
            max += item.chance;
        }
        int x = UnityEngine.Random.Range(1, max + 1);

        int rengeMin = 1;
        int rengeMax = 1;
        for (int i = 0; i < chances.Count; i++)
        {
            rengeMin = rengeMax;
            rengeMax += chances[i].chance;

            if (x >= rengeMin && x < rengeMax)
            {
                // Debug.Log("Select Spell In renge " + rengeMin + " and renge " + rengeMax);
                //  Debug.Log("index "+i+" selected");
                index = i;
                break;
            }
        }
        return index;
    }
    */
    public static bool CheckMobileNumber(string t)
    {

        string pattern = @"^(09)\d{9}$";
        Regex reg = new Regex(pattern);

        if (reg.IsMatch(t))
        {
            return true;
        }
        else
        {
            return false;
        }


    }
    public static string RandomString(int Size)
    {
        string input = "abcdefghijklmnopqrstuvwxyz0123456789";
        var chars = Enumerable.Range(0, Size)
                               .Select(x => input[UnityEngine.Random.Range(0, input.Length)]);
        return new string(chars.ToArray());
    }
    public static string TextToNumberStringXOR(string text, int plus)
    {
        string newText = "";

        for (int i = 0; i < text.Length; i++)
        {
            int charValue = Convert.ToInt32(text[i]);
            charValue ^= plus;

            newText += char.ConvertFromUtf32(charValue);
        }

        return newText;
    }
}
