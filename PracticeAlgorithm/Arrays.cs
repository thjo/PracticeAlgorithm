using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class Arrays
    {
        void Print(object output)
        {
            System.Diagnostics.Debug.WriteLine(output);
        }

        #region | 2D Array - DS | 

        [TestMethod]
        public void DS2DArray()
        {
            int[,] arr = new int[,] {
                 {0, -4, -6, 0, -7, -6}
                ,{-1, -2, -6, -8, -3, -1}
                ,{-8, -4, -2, -8, -8, -6}
                ,{-3, -1, -2, -5, -7, -4}
                ,{-3, -5, -3, -6, -6, -6}
                ,{ -3, -6, 0, -8, -6, -7}
            };

            int result = hourglassSum(arr);
            Print(result);
        }
        private int hourglassSum(int[,] arr)
        {
            int? maxhourglassSum = null;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int max = arr[row, col] + arr[row, col + 1] + arr[row, col + 2] +
                            arr[row + 1, col + 1] +
                            arr[row + 2, col] + arr[row + 2, col + 1] + arr[row + 2, col + 2];
                    Print(max);
                    if (maxhourglassSum == null || maxhourglassSum.Value < max)
                        maxhourglassSum = max;
                }
            }

            return maxhourglassSum.Value;
        }

        #endregion

        #region | Left Rotation | 

        [TestMethod]
        public void LeftRotatioon()
        {
            int n = 1, d = 4;
            int[] a = new int[] { 1 };

            int[] result = rotLeft(a, d);
            string.Join(" ", result);
        }
        private int[] rotLeft(int[] a, int d)
        {
            int[] result = null;

            if (a == null || d < 0)
                return result;

            int realRotationCnt = d % a.Length;
            if (realRotationCnt == 0)
                return a;

            result = new int[a.Length];
            for(int i = 0; i < a.Length; i++)
            {
                int newIdx = i - d;
                if (newIdx < 0)
                    newIdx = a.Length + newIdx;

                result[newIdx] = a[i];
            }

            return result;
        }

        #endregion

        #region | New Year Chaos | 

        [TestMethod]
        public void MinBribes()
        {
            int[] q = new int[] { 2, 1, 5, 3, 4 };
            minimumBribes(q);
        }
        // Complete the minimumBribes function below.
        private void minimumBribes(int[] q)
        {

            int minBribes = 0;

            int[] basic = new int[q.Length];
            for (int i = 0; i <= q.Length - 1; i++)
                basic[i] = i + 1;

            for (int i = 0; i < q.Length - 1; i++)
            {
                if (q[i] == basic[i])
                    continue;
                else
                {
                    int selIdx = i + 1;
                    do
                    {
                        if (basic[selIdx] == q[i])
                            break;

                        selIdx++;
                    } while (selIdx <= basic.Length - 1);
                    if (selIdx - i > 2)
                    {
                        minBribes = -1;
                        break;
                    }

                    //re-orignazation
                    for (int idx = selIdx; idx > i; idx--)
                    {
                        int buff = basic[idx];
                        basic[idx] = basic[idx - 1];
                        basic[idx - 1] = buff;
                        minBribes++;
                    }
                }
            }
            
            if (minBribes < 0)
                Print("Too chaotic");
            else
            {
                Print(minBribes);
            }
        }

        #endregion
    }
}
