using System;
using RESTAPI;

namespace REST_API
{
    class Program
    {
        static void Main(string[] args)
        {
            string uriEndPoint = Tools.UserInterface.Input("Input URL: ", ConsoleColor.Green);
            string authenticationType = Tools.UserInterface.Input("Input Authentication Type: ", ConsoleColor.Blue);
            REST.AuthenticationTypeEnum authenticationTypeEnum = (REST.AuthenticationTypeEnum)Enum.Parse(typeof(REST.AuthenticationTypeEnum), authenticationType, true);
            string techniqueType = Tools.UserInterface.Input("Input Technique Type: ", ConsoleColor.Blue);
            REST.AutheticationTechniqueEnum autheticationTechniqueEnum = (REST.AutheticationTechniqueEnum)Enum.Parse(typeof(REST.AutheticationTechniqueEnum), techniqueType, true);
            string userLogin = Tools.UserInterface.Input("Input Login: ", ConsoleColor.Red);
            string userPassword = Tools.UserInterface.Input("Input Password: ", ConsoleColor.Red);
            REST rest = new REST(uriEndPoint, REST.QueryTypeEnum.GET, userLogin, userPassword, authenticationTypeEnum, autheticationTechniqueEnum);
            string restResponse = rest.SendRequest();
            Tools.UserInterface.Output(restResponse, ConsoleColor.Green);
        }
    }
}
