using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ADS.Serialization
{
    public static class SerializeArray
    {

        public static string saveMap(string mapName, int[,] map)
        {
            JaggedFile dd = new JaggedFile();
            int[,] saveMap = map;
            string message = "";
            if (saveMap != null)
            {
                dd.Colums = saveMap.GetLength(0);
                dd.Rows = saveMap.GetLength(1);
                dd.IntJagged = Engine.Utilities.Utility.convertToJaggedArray(saveMap, dd.Colums, dd.Rows);

                string cwd = System.IO.Directory.GetCurrentDirectory();

                if (cwd.EndsWith("\\bin\\Windows\\x86\\Debug"))
                {
                    cwd = cwd.Replace("\\bin\\Windows\\x86\\Debug", "");
                    Console.WriteLine(cwd);

                }
                string outpit = cwd + "\\XmlLevel\\" + mapName + ".xml";

                XmlSerializer x = new XmlSerializer(dd.GetType());
                using (TextWriter writer = new StreamWriter(outpit))
                {
                    x.Serialize(writer, dd);
                    Console.WriteLine("Map Saved");
                   message = "Map Saved";
                    Console.WriteLine(map[0, 0]);

                }
            }
            else Console.WriteLine("CANT SAVE");
            return message;
        }

        public static int[,] load2DArrayFromJagged(string mapName)
        {
            return new int[4, 20];
        }
    }
}
