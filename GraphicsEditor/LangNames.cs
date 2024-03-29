using System;
using System.IO;

namespace GraphicsEditor
{
    internal static class LangNames
    {
        static string path = "Langs/Ru_ru.lang";

        public static string GetTranslete(string name)
        {
            string result = name;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strings = line.Split('=');
                        if (strings[0] == name)
                            return strings[1];
                    }
                }
            }
            catch 
            {
                return result;
            }
            
            return result;
        }

        public static string[] GetLanguages()
        {
            return new string[]
            {
                "Ru_ru",
                "En_en"
            };
        }

        public static void SetLanguage(string name)
        {
            path = $"Langs/{name}.lang";
        }
        
    }
}
