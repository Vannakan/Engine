using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Serialization
{
    public class JaggedFile
    {

        // [XmlIgnore]
        public string StringType;

        public int[][] IntJagged;
        public int[][] IntJagged2;
        public int Colums;
        public int Rows;

        public int IntType;
        public bool BoolType;

        public JaggedFile()
        {

        }
    }
}
