using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.EntityFramework
{
    public abstract class BaseSeed
    {
        protected static IEnumerable<string[]> ParseCsv(string path, string delimiters = "|",
            bool hasFieldsEnclosedInQuotes = true, bool hasHeader = false)
        {
            using (var parser = new TextFieldParser(new StringReader(path)))
            {
                parser.SetDelimiters(delimiters);
                parser.HasFieldsEnclosedInQuotes = hasFieldsEnclosedInQuotes;
                if (hasHeader) parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (fields != null)
                        yield return fields;
                }
            }
        }
    }
}
