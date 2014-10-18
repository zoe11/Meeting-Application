using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using FT_ENV;

namespace FT_Utils
{
    public class FTPHelper
    {
        private static FtpWebRequest FTPMakeDir;
        private static WebClient FTPFunction;
        private static string BASEURL; //FTP服务器
        private static string USERNAME; //用户名
        private static string PASSWORD; //密码
        private StringBuilder URL; //上传用FTP

        public FTPHelper()
        {
            BASEURL = FTEnv.FTPADDRESS;
            USERNAME = FTEnv.FTPUSER;
            PASSWORD = FTEnv.FTPPASSWORD;
        }

        public FTPHelper(string baseurl, string username, string password)
        {
            BASEURL = baseurl;
            USERNAME = username;
            PASSWORD = password;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="UploadPathUnTrans">上传路径，未转换，为字符串数组</param>
        /// <param name="AbsoluteFileName">绝对路径</param>
        /// <returns>是否上传成功</returns>
        public bool Upload(string[] UploadPathUnTrans, string AbsoluteFileName)
        {
            URL = new StringBuilder(BASEURL);
            FTPFunction = new WebClient();
            string RelativeUploadPath = TranslateUploadPath(UploadPathUnTrans); //调用转换函数获取相对路径
            string RelativeFileName = TranslateFilename(AbsoluteFileName);
            string AbsoluteUploadPath = BASEURL + RelativeUploadPath + RelativeFileName; //获取上传的绝对路径

            // IsMakeDIR = MakeDIR(UploadPathTrans);
            FTPFunction.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            try
            {
                FTPFunction.UploadFileAsync(new Uri(AbsoluteUploadPath), AbsoluteFileName); //异步上传
                return true; //成功返回true
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false; //出现异常，返回false
            }
        }

        /// <summary>
        /// 上传文件，是否批量上传
        /// 如果是是批量上传的话，得重新解析文件名
        /// </summary>
        /// <param name="UploadPathUnTrans">上传路径，未转换，为字符串数组</param>
        /// <param name="AbsoluteFileName">绝对路径</param>
        /// <returns>是否上传成功</returns>
        public bool Upload(string[] UploadPathUnTrans, string AbsoluteFileName, bool isBatchUpload)
        {
            URL = new StringBuilder(BASEURL);
            FTPFunction = new WebClient();
            string RelativeUploadPath = TranslateUploadPath(UploadPathUnTrans); //调用转换函数获取相对路径
            string RelativeFileName;
            if (isBatchUpload)
            {
                RelativeFileName = TranslateFilename(AbsoluteFileName, true);
            }
            else
            {
                RelativeFileName = TranslateFilename(AbsoluteFileName, false);
            }
            string AbsoluteUploadPath = BASEURL + RelativeUploadPath + RelativeFileName; //获取上传的绝对路径

            // IsMakeDIR = MakeDIR(UploadPathTrans);
            FTPFunction.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            try
            {
                FTPFunction.UploadFileAsync(new Uri(AbsoluteUploadPath), AbsoluteFileName); //异步上传
                return true; //成功返回true
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false; //出现异常，返回false
            }
        }

        /// <summary>
        /// 将绝对路径转换成相对路径
        /// </summary>
        /// <param name="AbsoluteFileName">绝对路径</param>
        /// <returns>相对路径</returns>
        private string TranslateFilename(string AbsoluteFileName, bool isBatchUpload)
        {
            string ResultFilename = AbsoluteFileName.Substring(AbsoluteFileName.LastIndexOf("\\") + 1);
            if (isBatchUpload)
            {
                ResultFilename = ResultFilename.Substring(ResultFilename.LastIndexOf("#") + 1);
            }
            return ResultFilename;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="DownloadPathUnTrans">服务器上的文件路径，为字符串数组</param>
        /// <param name="AbsoluteFileName">本地文件下载路径</param>
        /// <returns></returns>
        public bool Download(string[] DownloadPathUnTrans, string AbsoluteFileName)
        {
            URL = new StringBuilder(BASEURL);
            FTPFunction = new WebClient();
            string RelativeDownloadPath = TranslateDownloadPath(DownloadPathUnTrans); //调用转换函数获取相对路径
            string RelativeFileName = TranslateFilename(AbsoluteFileName);
            //string AbsoluteDownloadPath = BASEURL + RelativeDownloadPath + RelativeFileName; //获取上传的绝对路径
            string AbsoluteDownloadPath = (BASEURL + RelativeDownloadPath).TrimEnd('/'); //获取上传的绝对路径

            // IsMakeDIR = MakeDIR(UploadPathTrans);
            FTPFunction.Credentials = new NetworkCredential(USERNAME, PASSWORD);

            try
            {
                FTPFunction.DownloadFileAsync(new Uri(AbsoluteDownloadPath), AbsoluteFileName); //异步上传
                return true; //成功返回true
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false; //出现异常，返回false
            }
        }

        /// <summary>
        /// 转换下载路径
        /// </summary>
        /// <param name="strarr">用于存放下载路径的字符串数组</param>
        /// <returns>转换后的字符串</returns>
        private string TranslateDownloadPath(string[] strarr)
        {
            string ResultStr = "";
            string DirStr = "";
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr.GetValue(i) == null)
                    break;
                DirStr = strarr.GetValue(i).ToString() + "/"; //用于创建目录的字符串
                ResultStr = ResultStr + DirStr; //用于下载文件的字符串
            }
            return ResultStr;
        }

        /// <summary>
        /// 在FTP服务器上创建目录
        /// </summary>
        /// <param name="RelativePath">相对路径</param>
        /// <returns></returns>
        public bool MakeDIR(string RelativePath)
        {
            if (DirExists(RelativePath)) //如果当前路径已存在，则不建立路径
                return true;
            else
            {
                try
                {
                    //URL.Append
                    URL.Append(RelativePath); //stringbuilder实例
                    Uri uri = new Uri(URL.ToString());
                    FTPMakeDir = (FtpWebRequest) FtpWebRequest.Create(uri); //目的地址
                    FTPMakeDir.Credentials = new NetworkCredential(USERNAME, PASSWORD);
                    FTPMakeDir.Proxy = null;
                    FTPMakeDir.KeepAlive = false; //完成后保持连接状态设false
                    FTPMakeDir.Method = WebRequestMethods.Ftp.MakeDirectory; //选择方法为建立目录
                    FTPMakeDir.UseBinary = true; //使用二进制方式
                    FtpWebResponse response = (FtpWebResponse) FTPMakeDir.GetResponse(); //建立连接
                    response.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    return false;
                }
            }
        }

        /// <summary>
        /// 将得到的字符串数组转换成需要的字符串，在每个字符串之间加上反斜杠
        /// </summary>
        /// <param name="strarr">源字符串数组</param>
        /// <returns>结果字符串</returns>
        public string TranslateUploadPath(string[] strarr)
        {
            string ResultStr = "";
            string DirStr = "";
            for (int i = 0; i < strarr.Length; i++)
            {
                if (strarr.GetValue(i) == null)
                    break;
                DirStr = strarr.GetValue(i).ToString() + "/"; //用于创建目录的字符串
                MakeDIR(DirStr); //建立上传路径

                ResultStr = ResultStr + DirStr; //用于上传文件的字符串
            }
            return ResultStr;
        }

        /// <summary>
        /// 将绝对路径转换成相对路径
        /// </summary>
        /// <param name="AbsoluteFileName">绝对路径</param>
        /// <returns>相对路径</returns>
        private string TranslateFilename(string AbsoluteFileName)
        {
            string ResultFilename = AbsoluteFileName.Substring(AbsoluteFileName.LastIndexOf("\\") + 1);
            return ResultFilename;
        }

        /// <summary>
        /// 得到当前路径
        /// </summary>
        /// <param name="url">上一级地址</param>
        /// <returns>当前相对路径</returns>
        public string GetDir(string url)
        {
            Stream ResponseStream = null;
            StreamReader ReadStream = null;
            string CurrentDir; //当前路径
            try
            {
                //URL.Append
                FtpWebRequest GetDirectory = (FtpWebRequest) FtpWebRequest.Create(url); //目的地址
                GetDirectory.Credentials = new NetworkCredential(USERNAME, PASSWORD);
                GetDirectory.Proxy = null;
                GetDirectory.KeepAlive = false; //完成后保持连接状态设false
                GetDirectory.Method = WebRequestMethods.Ftp.ListDirectory; //方法为获取路径
                GetDirectory.UseBinary = true; //使用二进制方式
                FtpWebResponse response = (FtpWebResponse) GetDirectory.GetResponse(); //建立连接
                ResponseStream = response.GetResponseStream();
                ReadStream = new StreamReader(ResponseStream, System.Text.Encoding.UTF8);
                CurrentDir = ReadStream.ReadToEnd().ToString(); //将获得的二进制流读入字符串
                ReadStream.Close();
                response.Close();
                return CurrentDir; //返回当前相对路径路径

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        /// <summary>
        /// 判断当前路径是否已存在
        /// </summary>
        /// <param name="DirStr">当前相对路径</param>
        /// <returns>如果已存在，返回true</returns>
        public bool DirExists(string DirStr)
        {
            if (DirStr.Equals(GetDir(URL.ToString())))
                return true;
            else
                return false;
        }
    }
}
