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

        public enum AuthenticationTypeEnum
        {
            BASIC,
            NTLM
        };

        public enum AutheticationTechniqueEnum
        {
            OWN,
            NetworkCredential
        }
        private string endPoint { get; set; }
        private string userName { get; set; }
        private string userPassword { get; set; }
        private QueryTypeEnum queryMethod;
        private AutheticationTechniqueEnum autheticationTechnique;
        private AuthenticationTypeEnum authenticationType;
        public REST(string endPoint, QueryTypeEnum queryMethod)
        {
            this.endPoint = endPoint;
            this.queryMethod = queryMethod;
        }

        public REST(string endPoint, QueryTypeEnum queryMethod, string userName, string userPassword, AuthenticationTypeEnum authenticationType, AutheticationTechniqueEnum autheticationTechnique)
        {
            this.endPoint = endPoint;
            this.queryMethod = queryMethod;
            this.userName = userName;
            this.userPassword = userPassword;
            this.authenticationType = authenticationType;
            this.autheticationTechnique = autheticationTechnique;
        }


        public string SendRequestAutheticated()
        {
            string responseValue = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            httpWebRequest.Method = queryMethod.ToString();
            string authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
            httpWebRequest.Headers.Add("Authorization", authenticationType.ToString() + " " + authHeaer);
            HttpWebResponse httpWebResponse = null;
            try
            {
                using (httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
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
            }
            catch (Exception ex)
            {
                responseValue = $"/error/{ex.Message}/";
            }
            finally
            {
                if(httpWebResponse != null)
                {
                    ((IDisposable)httpWebResponse).Dispose();
                }
            }
            return responseValue;
        }
        public string SendRequest()
        {
            string responseValue = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(endPoint);
            httpWebRequest.Method = queryMethod.ToString();
            HttpWebResponse httpWebResponse = null;
            try
            {
                using (httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
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
            }
            catch (Exception ex)
            {
                responseValue = $"/error/{ex.Message}/";
            }
            finally
            {
                if(httpWebResponse != null)
                {
                    ((IDisposable)httpWebResponse).Dispose();
                }
            }
            return responseValue;
        }
    }
}