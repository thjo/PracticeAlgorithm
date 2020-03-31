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



        #region | Between Two Sets | 

        [TestMethod]
        public void BetweenTwoSets()
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            a.Add(2); a.Add(3); a.Add(6);
            b.Add(42); b.Add(84);
            //a.Add(2); a.Add(4); 
            //b.Add(16); b.Add(32); b.Add(96);
            Print(getTotalX(a, b));
        }

        private int getTotalX(List<int> a, List<int> b)
        {
            int aLCM = a[0];
            int bGCD = b[0];
            if( a.Count > 1)
            {
                for (int i = 1; i < a.Count; i++)
                {
                    aLCM = GetLCM(aLCM, a[i]);
                }
            }

            if( b.Count > 1)
            {
                for (int i = 1; i < b.Count; i++)
                {
                    bGCD = GetGCD(bGCD, b[i]);
                }
            }

            //
            int totalX = 0;
            if (aLCM > bGCD)
                return 0;
            else if (aLCM == bGCD)
                return 1;
            else
            {
                int n = 1;
                while(aLCM*n <= bGCD)
                {
                    if (bGCD % (aLCM * n) == 0)
                        totalX++;
                    n++;
                }
            }
            return totalX;
        }
        private int GetGCD(int a, int b)
        {
            int min = Math.Min(a, b);
            int max = Math.Max(a, b);
            int r = -1;
            while (true)
            {
                if ((r = max % min) != 0)
                {
                    max = min;
                    min = r;
                }
                else
                    break;
            }

            return min;
        }
        private int GetLCM(int a, int b)
        {
            return a * (b / GetGCD(a,b));
        }



        #endregion


        #region | Breaking the Records | 

        [TestMethod]
        public void BreakingRecords()
        {
            int[] result = BreakRecord(new int[] { 3, 4, 21, 36, 10, 28, 35, 5, 24, 42 });
            Print(string.Format("{0} {1}", result[0], result[1]));
        }

        private int[] BreakRecord(int[] scores)
        {
            int[] result = new int[2];
            result[0] = 0;
            result[1] = 0;
            if (scores != null && scores.Length > 1)
            {
                int lowest = scores[0], highest = scores[0];
                for (int i = 1; i < scores.Length; i++)
                {
                    if (lowest > scores[i])
                    {
                        lowest = scores[i];
                        result[1]++;
                    }
                    else if (highest < scores[i])
                    {
                        highest = scores[i];
                        result[0]++;
                    }
                }
            }
            return result;
        }
        #endregion

    }
}
