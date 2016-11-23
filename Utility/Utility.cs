using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utility
{
   public static class Utility
    {
      public static int[][] convertToJaggedArray(int[,] mArray, int Colums, int Rows)
       {
           int[][] jaggedArray = new int[Colums][];

           for (int i = 0; i < Colums; i++)
           {
               jaggedArray[i] = new int[Rows];
               for (int j = 0; j < Rows; j++)
               {
                   jaggedArray[i][j] = mArray[i, j];
               }
           }

           return jaggedArray;
       }

      public static int[,] convertTo2DArray(int[][] jaggedArray, int Colums, int Rows)
       {
           int[,] temp2DArray = new int[Colums,Rows];

           for (int c = 0; c < Colums; c++)
           {
               for (int r = 0; r < Rows; r++)
               {
                   temp2DArray[c, r] = jaggedArray[c][r];
                  
               }
           }

           return temp2DArray;
       } 

    }
}
