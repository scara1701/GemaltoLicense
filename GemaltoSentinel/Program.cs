using GemaltoSentinel.Services;
using System;

namespace GemaltoSentinel
{
    class Program
    {
        public static string ServerName { get; set; }
        public static string ServerPort { get; set; }
        public static string KeyIndex { get; set; }
        public static string KeySerial { get; set; }
        public static string OutputPath { get; set; }

        static void Main(string[] args)
        {
            try
            {
                ServerName = args[0];
                ServerPort = args[1];
                KeyIndex = args[2];
                KeySerial = args[3];
                OutputPath = args[4];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Did you pass the required arguments?");
                Console.ReadKey();
                Environment.Exit(0);
            }
            //CSV output
             Maintenance.WriteToCSVTable(OutputPath, LicenseServer.GetLicenses(ServerName, ServerPort, KeyIndex, KeySerial));
        }
    }
}
