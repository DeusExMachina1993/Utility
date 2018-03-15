using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SinSin
{



    public class BazarIntent
    {

        public static void RateUS(string pakageName)
        {
            try
            {
                AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
                AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_EDIT"));
                intentObject.Call<AndroidJavaObject>("setData",
                    uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + pakageName));
                intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
                AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                currentActivity.Call("startActivity", intentObject);
            }
            catch
            {
                Application.OpenURL("https://cafebazaar.ir/app/"+pakageName);
            }

        }

        public static void ViewAppPage(string pakageName)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData",
                uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + pakageName));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);

        }


        public static void OpenInstagram(string channeluri)
        {
            //telegram=https://t.me/DragonsCave
            Application.OpenURL(channeluri);
        }

        public static void OpenTelegramChannel(string channeluri)
        {
            //telegram=https://t.me/DragonsCave
            Application.OpenURL(channeluri);
        }

        public static void SendEmail(string gmail, string subject, string body)
        {
            string email = gmail;
            string _subject = MyEscapeURL(subject);
            string _body = MyEscapeURL(body);
            Application.OpenURL("mailto:" + email + "?subject=" + _subject + "&body=" + _body);
        }

        public static string MyEscapeURL(string url)
        {
            return WWW.EscapeURL(url).Replace("+", "%20");
        }
    }
}