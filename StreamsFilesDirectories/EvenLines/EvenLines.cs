namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };

            string line = string.Empty;
            int count = 0;

            StringBuilder sb = new StringBuilder(); 

            while (line != null)
            {
                line = reader.ReadLine();
                if (count % 2 == 0)
                {
                    string[] reversed = line.Split().Reverse().ToArray();
                    
                    sb = sb.AppendLine(string.Join(" ", reversed));

                    foreach (var item in charsToReplace)
                    {
                        sb.Replace(item, '@');
                    }

                }
                count++;
            }
            return sb.ToString();
        }
    }
}
