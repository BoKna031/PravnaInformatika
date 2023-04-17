using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

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

        public static void OpenReport(LegalCase lc, string dr_device_folder_path)
        {
            string facts_path = System.IO.Path.Combine(dr_device_folder_path, "facts.rdf");
            Util.Overwrite(facts_path, lc.GenerateRDF());


            string excecute_path = System.IO.Path.Combine(dr_device_folder_path, "start.bat");
            Util.ExcecuteStart(excecute_path);

            ShowLoadingWindow();

            string export_path = System.IO.Path.Combine(dr_device_folder_path, "export.rdf");
            ExportParser ep = new ExportParser();
            ReportsData rd = ep.ReadFile(export_path);

            Report reportDialog = new Report(rd);
            reportDialog.ShowDialog();

        }

        private static void ShowLoadingWindow()
        {
            Thread loadingThread = new Thread(() =>
            {
                LoadingWindow loadingWindow = new LoadingWindow();
                loadingWindow.Show();

                Thread.Sleep(18000);

                loadingWindow.Dispatcher.Invoke(() =>
                {
                    loadingWindow.Close();
                });
            });

            // Blokiraj glavnu nit dok se prozor ne zatvori
            loadingThread.SetApartmentState(ApartmentState.STA);
            loadingThread.Start();
            loadingThread.Join();
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
                Arguments = $"/c cd \"{parentFolder}\" & start cmd.exe /k start.bat",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            // Pokretanje .bat fajla
            Process process = new Process { StartInfo = startInfo };
            process.Start();

        }

    }
}
