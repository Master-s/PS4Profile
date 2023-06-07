using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace PS4Profile
{
    public class FTP
    {
        private System.Net.NetworkCredential _credentials;
        public FTP(string _FTPUser, string _FTPPass)
        {
            setCredentials(_FTPUser, _FTPPass);
        }
        public void UploadFile(string _FileName, string _UploadPath)
        {
            System.IO.FileInfo _FileInfo = new System.IO.FileInfo(_FileName);
            System.Net.FtpWebRequest _FtpWebRequest = (System.Net.FtpWebRequest)System.Net.FtpWebRequest.Create(new Uri(_UploadPath));
            _FtpWebRequest.Credentials = _credentials;
            _FtpWebRequest.KeepAlive = false;
            _FtpWebRequest.Timeout = 2000;
            _FtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            _FtpWebRequest.UseBinary = true;
            _FtpWebRequest.ContentLength = _FileInfo.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength - 1 + 1];
            System.IO.FileStream _FileStream = _FileInfo.OpenRead();
            try
            {
                System.IO.Stream _Stream = _FtpWebRequest.GetRequestStream();
                int contentLen = _FileStream.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    _Stream.Write(buff, 0, contentLen);
                    contentLen = _FileStream.Read(buff, 0, buffLength);
                }
                _Stream.Close();
                _Stream.Dispose();
                _FileStream.Close();
                _FileStream.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DownloadFile(string _FileName, string _ftpDownloadPath)
        {
            try
            {
                System.Net.FtpWebRequest _request = (FtpWebRequest)System.Net.WebRequest.Create(_ftpDownloadPath);
                _request.KeepAlive = false;
                _request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
                // _request.Credentials = _credentials
                System.Net.FtpWebResponse _response = (FtpWebResponse)_request.GetResponse();
                System.IO.Stream responseStream = _response.GetResponseStream();
                System.IO.FileStream fs = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
                responseStream.CopyTo(fs);
                responseStream.Close();
                _response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Download Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<string> GetDirectory(string _ftpPath)
        {
            List<string> ret = new List<string>();
            try
            {
                System.Net.FtpWebRequest _request = (FtpWebRequest)System.Net.WebRequest.Create(_ftpPath);
                _request.KeepAlive = false;
                _request.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails;
                _request.Credentials = _credentials;
                System.Net.FtpWebResponse _response = (FtpWebResponse)_request.GetResponse();
                System.IO.Stream responseStream = _response.GetResponseStream();
                System.IO.StreamReader _reader = new System.IO.StreamReader(responseStream);
                string FileData = _reader.ReadToEnd();
                string[] Lines = FileData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string l in Lines)
                    ret.Add(l);
                _reader.Close();
                _response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Directory Fetch Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

        private void setCredentials(string _FTPUser, string _FTPPass)
        {
            _credentials = new System.Net.NetworkCredential(_FTPUser, _FTPPass);
        }
    }
}
