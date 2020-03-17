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
            for (int i = 0; i < a.Length; i++)
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


        #region | Bonetrousle | 

        [TestMethod]
        public void BonetrousleCase()
        {
            bonetrousle(12, 8, 3);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"># of spaghetti sticks</param>
        /// <param name="k"># of boxes of spaghetti sticks in th store.</param>
        /// <param name="b"># of boxes of spahetti sticks</param>
        /// <returns></returns>
        private long[] bonetrousle(long n, long k, int b)
        {
            long min, max, lb = b;
            long quo, mod, i;
            min = (lb) * (lb + 1) / 2;
            if (n < min) return new long[] { -1 };

            mod = (n - min) % lb;
            quo = (n - min) / lb;
            List<long> v = new List<long>();
            for (i = b; i >= 1; i--)
            {
                v.Add((i + mod > lb) ? i + quo + 1 : i + quo);
                if (v[v.Count - 1] > k) return new long[] { -1 };
            }
            return v.ToArray();
        }

        #endregion


        #region | PowerSet | 

        [TestMethod]
        public void PowerSet()
        {
            char[] data = { 'a', 'b', 'c' };
            int[] flag = new int[data.Length];

            poSet(data, flag, 0);
        }

        private void poSet(char[] data, int[] flag, int n)
        {
            if (n == data.Length)
            {
                printPowerSet(data, flag);
                return;
            }

            flag[n] = 1;
            poSet(data, flag, n+1);

            flag[n] = 0;
            poSet(data, flag, n + 1);
        }

        private void printPowerSet(char[] data, int[] flag)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                if (flag[i] == 1)
                {
                    Print(data[i], false);
                }
            }
            Print("");
        }

        #endregion


        #region | Combination | 

        [TestMethod]
        public void Combination()
        {
            int[] data = { 1 , 2 , 3, 4, 5, 6, 7, 8 };
            int[] flag = new int[data.Length];

            comb(data, flag, 0, data.Length, 3);
        }

        private void comb(int[] arr, int[] flag, int depth, int n, int size)
        {
            if( size == 0)
            {
                printComb(arr, flag, n);
                return;
            }

            if (depth == n) {
                return;
            }
            else
            {
                flag[depth] = 1;
                comb(arr, flag, depth + 1, n, size-1);

                flag[depth] = 0;
                comb(arr, flag, depth + 1, n, size);
            }
        }

        private void printComb(int[] data, int[] flag, int n)
        {
            for (int i = 0; i < flag.Length; i++)
            {
                if (flag[i] == 1)
                {
                    Print(data[i], false);
                }
            }
            Print("");
        }

        #endregion



        #region | Diagonal Difference |

        [TestMethod]
        public void DiagonalDiff()
        {

            List<List<int>> arr = new List<List<int>>();
            arr.Add(new List<int>());
            arr[0].Add(-10);
            arr[0].Add(3);
            arr[0].Add(0);
            arr[0].Add(5);
            arr[0].Add(-4);
            arr.Add(new List<int>());
            arr[1].Add(2);
            arr[1].Add(-1);
            arr[1].Add(0);
            arr[1].Add(2);
            arr[1].Add(-8);
            arr.Add(new List<int>());
            arr[2].Add(9);
            arr[2].Add(-2);
            arr[2].Add(-5);
            arr[2].Add(6);
            arr[2].Add(0);
            arr.Add(new List<int>());
            arr[3].Add(9);
            arr[3].Add(-7);
            arr[3].Add(4);
            arr[3].Add(8);
            arr[3].Add(-2);
            arr.Add(new List<int>());
            arr[4].Add(3);
            arr[4].Add(7);
            arr[4].Add(8);
            arr[4].Add(-5);
            arr[4].Add(0);
            DiagonalDifference(arr);
        }

        public void DiagonalDifference(List<List<int>> arr)
        {
            if (arr == null || arr.Count < 1)
                return;
            try
            {
                int lrDiagonal = 0, rlDiagonal = 0;
                for (int i = 0; i < arr.Count; i++)
                {
                    lrDiagonal += arr[i][i];
                    rlDiagonal += arr[i][arr.Count - 1 - i];
                    //Print(string.Format("{0} {1}", i, (arr.Count - 1 - i)));
                    Print(string.Format("{0} {1}", lrDiagonal, rlDiagonal));
                }


                Print("");
                Print(string.Format("{0} {1}", lrDiagonal, rlDiagonal));
                Print(Math.Abs(lrDiagonal - rlDiagonal));
            }
            catch (Exception ex)
            {
                Print(ex);
            }
            //-10 3 0 5 - 4
            //2 - 1 0 2 - 8
            //9 - 2 - 5 6 0
            //9 - 7 4 8 - 2
            //3 7 8 - 5 0
        }

        #endregion

        #region | Two Sum | 

        [TestMethod]
        public void SumInteger()
        {
            //Two Sum
            //int[] result = twoIntSum(new int[3] { 3, 2, 3 }, 6);
            //if(result != null)
            //    Print(string.Format("{0}, {1}", result[0], result[1]));

            //Three Sum

        }
        private int[] twoIntSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map.Add(nums[i], i);
            }
            return null;
        }

        private IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = null;


            return result;
        }

        #endregion
    }
}
