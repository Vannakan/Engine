using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Engine.Serialization
{
   public class saveDataTest
    {
      // [XmlIgnore]
       public string StringType;

       public int[][] IntJagged;
        public int[][] IntJagged2;
       public int Colums;
       public int Rows;

       public int IntType;
       public bool BoolType;

       public saveDataTest()
       {
      
       }
    }
}
