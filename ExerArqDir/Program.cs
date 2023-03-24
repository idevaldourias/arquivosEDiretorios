using System.Globalization;

namespace ExerArqDir
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp\exercicio";
            string pathOut = path + @"\out";
            string sourcePath = path + @"\itens.csv";
            string fileOut = pathOut + @"\summary.csv";

            if (!Directory.Exists(pathOut))
                Directory.CreateDirectory(pathOut);

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(fileOut))
                {
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(",");
                        double price = double.Parse(values[1], CultureInfo.InvariantCulture);
                        int qtd = int.Parse(values[2]);

                        sw.WriteLine(values[0] + "," + (price * qtd).ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.Write("An error has occurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}