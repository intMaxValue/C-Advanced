namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath,true);
            }

            Directory.CreateDirectory(outputPath);

            string[] fileNames = Directory.GetFiles(inputPath);

            foreach (string file in fileNames)
            {
                string name = Path.GetFileName(file);
                string destination = Path.Combine(outputPath, name);

                File.Copy(file, destination);
                
            }
        }
    }
}
