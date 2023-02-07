namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> files = new();

            var getFiles = Directory.GetFiles(inputFolderPath);


            foreach (var item in getFiles)
            {
                FileInfo fileInfo = new FileInfo(item);

                if (!files.ContainsKey(fileInfo.Extension))
                {
                    files.Add(fileInfo.Extension, new List<FileInfo>());
                }
                files[fileInfo.Extension].Add(fileInfo);
            }

            var sb = new StringBuilder();

            foreach (var item in files.OrderByDescending(f => f.Value.Count))
            {
                sb.AppendLine(item.Key);

                foreach (var fInfo in item.Value.OrderBy(f => f.Length))
                {
                    sb.AppendLine($"--{fInfo.Name} - {fInfo.Length / 1024:f3}kb");
                }
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(desktopPath, textContent);
        }
    }
}
