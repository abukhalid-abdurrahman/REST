using System;
using RESTAPI;

namespace REST_API
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = Console.ReadLine();
            REST rest = new REST(uri, REST.QueryTypeEnum.GET);
            string result = rest.SendRequest();
            Console.WriteLine(result);
        }
    }
}
