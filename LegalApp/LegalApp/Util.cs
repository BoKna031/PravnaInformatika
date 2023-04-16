using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class Util
    {
        public static void Overwrite(string filepath, string content)
        {
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                writer.Write(content);
            }
        }

        public static string ToUpperDirectory(string path, int num)
        {
            string result = path;
            for (int i = 0; i < num; i++)
            {
                result = System.IO.Directory.GetParent(result).FullName;
            }
            return result;
        }

        public static void ExcecuteStart(string filepath)
        {
            string parentFolder = System.IO.Directory.GetParent(filepath).FullName;
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c cd \"{parentFolder}\" & start start.bat",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            // Pokretanje .bat fajla
            Process process = new Process { StartInfo = startInfo };
            process.Start();
        }

    }
}
