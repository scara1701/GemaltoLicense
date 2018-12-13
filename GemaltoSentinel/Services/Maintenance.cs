using GemaltoSentinel.Entities;
using System.Collections.Generic;
using System.IO;

namespace GemaltoSentinel.Services
{
    public static class Maintenance
    { 
       public static void WriteToCSVTable(string outputPath, List<LicenseDetails> licenseDetailsList)
        {
            string outputText = "";
            foreach (LicenseDetails licenseDetails in licenseDetailsList)
            {
                outputText += licenseDetails.ClientUserName + ";";
                outputText += licenseDetails.ClientIPAddress + ";";
                outputText += licenseDetails.ClientLogTime + ";";
                outputText += licenseDetails.ClientProcessID + ";";
                outputText += licenseDetails.LicenseID + ";";
                outputText += System.Environment.NewLine;
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.Write(outputText);
            }
        }
    }
}
