using System;
using System.IO;
using System.Net;

namespace REST_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("REST API");
            WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            request.Method = "POST";

            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
            }

            response.Close();
        }
    }
}
