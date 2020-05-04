using System;
using RESTAPI;

namespace REST_API
{
    class Program
    {
        static void Main(string[] args)
        {
            string uriEndPoint = Tools.UserInterface.Input("Input URL: ", ConsoleColor.Green);
            Console.Write("\n1. To Send Data\n2. To Read Data\nInput: ");
            string restMethod = Console.ReadLine();
            if(restMethod == "1")
            {
                Console.Write("Input Data: ");
                string data = Console.ReadLine();
                Console.Write("Input Content-Type: ");
                string contentType = Console.ReadLine();
                REST rest = new REST(uriEndPoint, REST.QueryTypeEnum.POST);
                string restResponse = rest.WriteRequest(data, contentType);
                Tools.UserInterface.Output(restResponse, ConsoleColor.Blue);
            }
            else if(restMethod == "2")
            {
                REST rest = new REST(uriEndPoint, REST.QueryTypeEnum.GET);
                string restResponse = rest.ReadResponse();
                Tools.UserInterface.Output(restResponse, ConsoleColor.Green);
            }
        }
    }
}
