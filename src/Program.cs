using cs2pu.converter;

namespace cs2pu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string inputPath = Directory.GetCurrentDirectory();
                string outputPath = Directory.GetCurrentDirectory() + @"\out.pu";
                inputPath = @"C:\Users\kkobashi\source\cs2pu\src";
                var csDirectory = new CSharpDirectory(inputPath);

                var puFile = new PlantUmlFile(outputPath);
                var converter = new Converter();
                var pu = converter.Execute(csDirectory);
                puFile.Save(pu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
