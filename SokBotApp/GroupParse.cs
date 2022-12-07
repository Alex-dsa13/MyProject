using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SokApp
{
    internal class GroupParse
    {
        private HttpWebRequest? _request = null;
        private string _address;

        public string Response { get; set; }


        public GroupParse(string address)
        {
            _address = address;
            Response = "";

        }

        
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "GET";


            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
