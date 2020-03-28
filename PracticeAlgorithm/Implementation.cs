using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class Implementation
    {
        void Print(object output, bool newLine = true)
        {
            if (newLine)
                System.Diagnostics.Debug.WriteLine(output);
            else
            {
                System.Diagnostics.Debug.Write(output);
                System.Diagnostics.Debug.Write(" ");
            }
        }

        #region | Apple and Orange | 

        [TestMethod]
        public void CntApplesNOanges()
        {
            CountApplesAndOranges(7, 11, 5, 15, new int[] { -1, 2, 1 }, new int[] { 5, -6 });
        }
        private void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int maxLen = Math.Max(apples.Length, oranges.Length);
            int cntApples = 0, cntOranges = 0;
            for(int i = 0; i < maxLen; i++)
            {
                if (i < apples.Length && isMidNum(s, t, a, apples[i]))
                    cntApples++;
                if (i < oranges.Length && isMidNum(s , t, b, oranges[i]))
                    cntOranges++;
            }

            Print(cntApples);
            Print(cntOranges);
        }
        private bool isMidNum(int s, int t, int p, int n)
        {
            bool isMid = false;
            n += p;
            if (n <= t && n >= s)
                isMid = true;

            return isMid;
        }
        #endregion


        #region | Kangaroo | 

        [TestMethod]
        public void KangarooA()
        {
            Print(kangaroo(0, 3, 4, 2));
            Print(kangaroo(21, 6, 47, 3));
        }
        private string kangaroo(int x1, int v1, int x2, int v2)
        {
            double n = -1;

            if( v1 - v2 > 0)
            {
                n = (x2 - x1) / ((v1 - v2)*1.0);
                if( n * 10 % 10  != 0)
                {
                    //Not integer
                    n = -1;
                }
            }

            return n > 0 ? "YES" : "NO";
        }
        #endregion
    }
}
