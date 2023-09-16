using System;
using GroupDocs;
using GroupDocs.Conversion.Options.Convert;
using GroupDocs.Conversion.Options;
using System.Windows.Forms;

namespace Services
{
    public class Converter
    {
        public string FileFormat { get; set; }

        public Converter(string fileFormat)
        {
            FileFormat = fileFormat;

        }

        public void Convert(string inputFile, string outputFile)
        {
            using (GroupDocs.Conversion.Converter converter = new GroupDocs.Conversion.Converter(inputFile))
            {
                var options = converter.GetPossibleConversions()[FileFormat].ConvertOptions;
                converter.Convert(outputFile, options);
            }
            MessageBox.Show("Готово!");
        }
    }
}
