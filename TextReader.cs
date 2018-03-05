using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

namespace MyTextReader
{
    public static class TextReader
    {
        public static string ReadTextFile(TextAsset t)
        {
            if (t.text != null)
            {
                string outPut = t.text;
                return outPut;
            }
            else
            {
                return null;
            }

        }

        public static string ReadTextFile(string fileName)
        {
            string outPut = "";

            //  Debug.Log(Application.persistentDataPath);
            var name = Application.persistentDataPath + "/" + fileName;
            if (File.Exists(name))
            {
                var sr = File.OpenText(name);
                var line = sr.ReadLine();

                while (line != null)
                {
                    //    Debug.Log(line); // prints each line of the file
                    line = sr.ReadLine();
                    outPut += line;

                }
                return outPut;
            }
            else
            {
                //     Debug.Log("Could not Open the file: " + name + " for reading.");
                return outPut;

            }

        }

        public static string[] ReadTextFileLines(TextAsset t, char c)
        {
            if (t != null)
            {
                string[] outPut = t.text.Split(c);
                return outPut;
            }
            else
            {
                return null;
            }

        }

        public static string[] ReadTextFileLines(string path, char c)
        {
            if (path != null)
            {
                TextAsset temp = Resources.Load(path) as TextAsset;
                string[] outPut = temp.text.Split(c);
                return outPut;
            }
            else
            {
                return null;
            }
        }
        public static string ReadTextFileFromResources(string path)
        {
            if (path != null)
            {
                TextAsset temp = Resources.Load(path) as TextAsset;

                return temp.text;
            }
            else
            {
                return null;
            }
        }

        public static void WriteTextFile(string fileName, string stringToWrite)
        {

            var path = Application.persistentDataPath + "/" + fileName;
            if (File.Exists(path))
            {
                //   Debug.Log(path + " already exists.");
                return;
            }
            var sr = File.CreateText(path);
            sr.Write(stringToWrite);
            sr.Close();

        }

        public static void AppendToTextFile(string fileName, string s)
        {
            var path = Application.persistentDataPath + "/" + fileName;
            var temp = File.AppendText(path);
            temp.Write(s);
            temp.Close();

        }

        public static bool CompareUnicodeString(string s, string r)
        {
            string sNormalized = s.ToString().Normalize();
            string rNormalized = r.ToString().Normalize();

            if (sNormalized.Equals(rNormalized))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CompareUnicodeChar(char c, char r)
        {
            string cNormalized = c.ToString().Normalize();
            string rNormalized = r.ToString().Normalize();

            if (cNormalized.Equals(rNormalized))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static string ConvertToPersian(string s)
        {

            s = ReverseText(ArabicSupport.ArabicFixer.Fix(s.Trim()));
            return s;
        }

        public static void ConvertToPersian(TextMeshPro textfield, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                textfield.text = ReverseText(ArabicSupport.ArabicFixer.Fix(text.Trim()));
            }

            textfield.isRightToLeftText = true;
        }

        public static void ConvertToPersian(TextMeshProUGUI textfield, string text)
        {

            textfield.text = ReverseText(ArabicSupport.ArabicFixer.Fix(text.Trim()));
            textfield.isRightToLeftText = true;
        }

        public static void ConvertToPersianAppend(TextMeshProUGUI textfield, string text)
        {

            textfield.text += ReverseText(ArabicSupport.ArabicFixer.Fix(text.Trim()));
            textfield.isRightToLeftText = true;
        }

        public static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string ReverseText(string source)
        {
            char[] split = {'\n'};
            string[] paragraphs = source.Split(split);
            string result = "";
            foreach (string paragraph in paragraphs)
            {
                char[] output = new char[paragraph.Length];
                for (int i = 0; i < paragraph.Length; i++)
                {
                    output[(output.Length - 1) - i] = paragraph[i];
                }
                result += new string(output);
                result += "\n";
            }
            return result;
        }

        public static string ReadFromAssetBundle(string path, string name)
        {
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "path"));
            if (myLoadedAssetBundle == null)
            {
                //  Debug.Log("Failed to load AssetBundle!");
                return "Failed to load AssetBundle!";

            }

            TextAsset temp = myLoadedAssetBundle.LoadAsset<TextAsset>("name");


            myLoadedAssetBundle.Unload(false);
            return temp.text;
        }

        internal static void ReadTextFileLines(string p)
        {
            throw new NotImplementedException();
        }
    }
}