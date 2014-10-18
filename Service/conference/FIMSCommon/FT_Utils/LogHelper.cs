using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace FT_Utils
{
    public class LogHelper
    {

        public static string CreateLogFile()
        {
            string folderPath = FT_ENV.FTEnv.EXE_LOG_PATH;
            string filePath = folderPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (!File.Exists(filePath))
            {
                try
                {
                    FileStream file = File.Create(filePath);
                    file.Dispose();
                    file.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return filePath;
        }

        public static string CreateLogFile(string folderName)
        {
            string folderPath = FT_ENV.FTEnv.EXE_DATA_PATH + "\\"+folderName+"\\";
            string filePath = folderPath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (!File.Exists(filePath))
            {
                try
                {
                    FileStream file = File.Create(filePath);
                    file.Dispose();
                    file.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return filePath;
        }

        public static string CreateXMLLogFile(string folderName)
        {
            string folderPath = FT_ENV.FTEnv.EXE_DATA_PATH + "\\" + folderName + "\\";
            string filePath = folderPath + DateTime.Now.ToString("yyyy-MM-dd") + ".xml";
            if (!Directory.Exists(folderPath))
            {
                try
                {
                    Directory.CreateDirectory(folderPath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (!File.Exists(filePath))
            {
                try
                {
                    XElement element = new XElement("Logs");
                    element.Save(filePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return filePath;
        }

        /// <summary>
        ///向日志文件中写入日志
        /// </summary>
        /// <param name="logText"></param>
        public static void LogWrite(string logText)
        {
            string filePath =CreateLogFile();
            StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8);
            try
            {
                sw.WriteLine("1:/********************************/");
                sw.WriteLine();
                sw.WriteLine(logText);
                sw.WriteLine("2:/********************************/");
                sw.WriteLine();
                sw.WriteLine();
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
            catch (Exception ex)
            {
                sw.Dispose();
                sw.Close();
            }
        }

        public static void LogWrite(string logText,string folderName)
        {
            string filePath = CreateLogFile(folderName);

            StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8);
            try
            {
                sw.WriteLine("1:/********************************/");
                sw.WriteLine();
                sw.WriteLine(logText);
                sw.WriteLine("2:/********************************/");
                sw.WriteLine();
                sw.WriteLine();
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
            catch (Exception e)
            {
                sw.Dispose();
                sw.Close();
            }
        }


        public static void LogWrite(XElement logText, string folderName)
        {
            string filePath = CreateXMLLogFile(folderName);


            XElement element = XElement.Load(filePath);
            element.Add(logText);
            element.Save(filePath);
        }
    }
}
