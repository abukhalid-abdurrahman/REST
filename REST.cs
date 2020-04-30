using System;
using System.IO;
using System.Net;

namespace RESTAPI
{
    public class REST
    {
        public enum QueryTypeEnum
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        };
        public string EndPoint { get; set; }
        public QueryTypeEnum QueryMethod;
        public REST(string endPoint, QueryTypeEnum queryMethod)
        {
            this.EndPoint = endPoint;
            this.QueryMethod = queryMethod;
        }

        public string SendRequest()
        {
            string responseValue = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(EndPoint);
            httpWebRequest.Method = "GET";
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception();
                }

                using (Stream responseStreamReader = httpWebResponse.GetResponseStream())
                {
                    if (responseStreamReader != null)
                    {
                        using (StreamReader streamReader = new StreamReader(responseStreamReader))
                        {
                            responseValue = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return responseValue;
        }
    }
}