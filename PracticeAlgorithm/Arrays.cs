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

        #region | Plus Minus Fraction | 

        [TestMethod]
        public void PlusMinusFraction()
        {
            plusMinus(new int[] { -4, 3, -9, 0, 4, 1 });
        }

        private void plusMinus(int[] arr)
        {
            decimal n = arr.Length;
            decimal plus = 0, minus = 0, zero = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == 0)
                    zero++;
                else if (arr[i] > 0)
                    plus++;
                else
                    minus++;
            }
            Print(string.Format("{0:F6}", plus / n));
            Print(string.Format("{0:F6}", minus / n));
            Print(string.Format("{0:F6}", zero / n));
        }

        #endregion

        #region | Staircase - Star | 

        [TestMethod]
        public void StaircaseStar()
        {
            staircase(6);
        }

        private void staircase(int n)
        {
            int i = 1;
            while(i <= n)
            {
                Print(PrintChar(" ", (n-i)), false);
                Print(PrintChar("#", i), false);
                Print("");
                i++;
            }

        }
        private string PrintChar(string s, int n)
        {
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                sb.Append(s);
                n--;
            }
            return sb.ToString();
        }
        #endregion

        #region | Array - Sum of Pair numbers | 

        [TestMethod]
        public void SumOfPairNums()
        {
            //Print(SumOfPairwithSortedArray(new int[] { 1, 2, 3, 9}, 8));
            //Print(SumOfPairwithSortedArray(new int[] { 1, 2, 4, 4}, 8));

            Print(SumOfPairwithoutSortedArray(new int[] { 1, 2, 3, 9 }, 8));
            Print(SumOfPairwithoutSortedArray(new int[] { 1, 2, 4, 4 }, 8));
        }

        public bool SumOfPairwithSortedArray(int[] arr, int sum)
        {
            bool isExist = false;

            int min = 0, max = arr.Length - 1;
            Array.Sort(arr);
            while (min < max)
            {
                int s = arr[min] + arr[max];
                if (s > sum)
                    max--;
                else if (s < sum)
                    min++;
                else
                {
                    Print(string.Format("{0} - {1}", min, max));
                    return true;
                }
            }

            return isExist;
        }


        public bool SumOfPairwithoutSortedArray(int[] arr, int sum)
        {
            bool isExist = false;
            HashSet<int> dp = new HashSet<int>();
            for(int i = 0; i < arr.Length; i++)
            {
                int comp = sum - arr[i];
                if(dp.Contains(comp))
                {
                    return true;
                }
                else
                {
                    dp.Add(comp);
                }
            }
            return isExist;
        }

        #endregion

        #region | Mini-Max Sum | 

        [TestMethod]
        public void MiniMax()
        {
            MiniMaxSum(new int[] { 1, 2, 3, 4, 5 });
        }
        public void MiniMaxSum(int[] arr)
        {
            Array.Sort(arr);
            Int64 min = 0, max = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    min += arr[i];
                else if (i == arr.Length - 1)
                    max += arr[i];
                else
                {
                    min += arr[i];
                    max += arr[i];
                }
            }
            Print(string.Format("{0} {1}", min, max));
        }



        #endregion

        #region | Time Conversion |

        [TestMethod]
        public void TimeConversion()
        {
            Print(TimCoverter("12:40:22AM"));
        }

        private string TimCoverter(string s)
        {
            bool isAM = string.Compare(s.Substring(s.Length - 2, 2), "AM", true) == 0 ? true : false;

            int hour = int.Parse(s.Substring(0, 2));
            if (isAM && hour == 12)
                hour = 0;
            else if (isAM == false)
            {
                if(hour != 12)
                    hour = hour + 12;
            }

            return string.Format("{0:00}:{1}:{2}", hour, s.Substring(3,2), s.Substring(6, 2));
        }

        #endregion


        #region | DuplicateZeros | 

        [TestMethod]
        public void DuplicateZeros()
        {
            DuplicateZeros(new int[] { 1, 5, 2, 0, 6, 8, 0, 6, 0 });
        }
        public void DuplicateZeros(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0 && i < (arr.Length - 1))
                {
                    for (int j = arr.Length-1; j >= i+1; j--)
                        arr[j] = arr[j-1];
                    arr[++i] = 0;
                }
            }
        }

        #endregion

        #region | Merge | 

        [TestMethod]
        public void Merge()
        {
            Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] newArr = new int[m+n];

            int n1 = 0, n2 = 0;
            int i = 0;
            while(m > 0 && n > 0)
            {
                if (nums1[n1] > nums2[n2])
                {
                    newArr[i] = nums2[n2++];
                    n--;
                }
                else
                {
                    newArr[i] = nums1[n1++];
                    m--;
                }
                i++;
            }

            while (m > 0)
            {
                newArr[i++] = nums1[n1++];
                m--;
            }
            while (n > 0)
            {
                newArr[i++] = nums2[n2++];
                n--;
            }

            for (int j = 0; j < newArr.Length; j++)
                nums1[j] = newArr[j];
        }

        #endregion

        #region | In Place | 

        [TestMethod]
        public void ReplaceElements()
        {
            int[] a = ReplaceElements(new int[] { 17, 18, 5, 4, 6, 1});
            foreach (int i in a)
                Print(i, true);
        }
        public int[] ReplaceElements(int[] arr)
        {
            if(arr != null && arr.Length > 0)
            {
                int max = arr[arr.Length - 1];
                arr[arr.Length - 1] = -1;
                int tmp = 0;
                for(int i = arr.Length-2; i >= 0; i--)
                {
                    tmp = arr[i];
                    arr[i] = max;
                    if (max < tmp)
                        max = tmp;
                }
            }

            return arr;
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            Print(RemoveDuplicates(new int[] {1, 1, 2 }));
        }
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else
            {
                int len = 1;
                int previousNum = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (previousNum != nums[i])
                    {
                        nums[len++] = nums[i];
                    }

                    previousNum = nums[i];
                }

                return len;
            }
        }

        [TestMethod]
        public void MoveZeroes()
        {
            MoveZeroes(new int[] { });
        }
        public void MoveZeroes(int[] nums)
        {
            if(nums != null && nums.Length > 1)
            {
                int currentIdx = 0;
                for(int i = 0; i < nums.Length; i++)
                {
                    if(nums[i] != 0)
                    {
                        nums[currentIdx++] = nums[i];
                    }
                }

                while(currentIdx < nums.Length)
                    nums[currentIdx++] = 0;

            }
        }

        [TestMethod]
        public void SortArrayByParity()
        {
            int[] a = SortArrayByParity(new int[] { 17, 18, 5, 4, 6, 1 });
            foreach (int i in a)
                Print(i, true);
        }
        public int[] SortArrayByParity(int[] A)
        {
            if (A != null && A.Length > 1)
            {
                int evenIdx = 0;

                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 == 0)
                    {
                        if (evenIdx == i)
                            evenIdx++;
                        else
                        {
                            int tmp = A[evenIdx];
                            A[evenIdx++] = A[i];
                            A[i] = tmp;
                        }
                    }
                }
            }

            return A;
        }

        [TestMethod]
        public void SortedSquares()
        {
            int[] a = SortedSquares(new int[] { 17, 18, 5, 4, 6, 1 });
            foreach (int i in a)
                Print(i, true);
        }
        public int[] SortedSquares(int[] A)
        {
            if( A != null && A.Length > 0)
            {
                for (int i = 0; i < A.Length; i++)
                    A[i] = A[i] * A[i];

                Array.Sort(A);
            }

            return A;
        }

        [TestMethod]
        public void HeightChecker()
        {
            Print(HeightChecker(new int[] { 1, 1, 4, 2, 1, 3 }));
        }
        public int HeightChecker(int[] heights)
        {
            int cnt = 0;

            if (heights != null && heights.Length > 1)
            {
                int[] sortedHeights = new int[heights.Length];
                Array.Copy(heights, sortedHeights, heights.Length);
                Array.Sort(sortedHeights);

                for (int i = 0; i < heights.Length; i++)
                    if (heights[i] != sortedHeights[i])
                        cnt++;
            }

            return cnt;
        }

        [TestMethod]
        public void ThirdMax()
        {
            Print(ThirdMax(new int[] { 3, 2, 1 }));
        }
        public int ThirdMax(int[] nums)
        {
            int? max = null;
            int? secondMax = null;
            int? thirdMax = null;
            
            foreach(int num in nums)
            {
                if (num == max || num == secondMax || num == thirdMax)
                    continue;
                else if (max == null || max.Value < num)
                {
                    thirdMax = secondMax;
                    secondMax = max;
                    max = num;
                }
                else if (secondMax == null || secondMax.Value < num)
                {
                    thirdMax = secondMax;
                    secondMax = num;
                }
                else if (thirdMax == null || thirdMax.Value < num)
                {
                    thirdMax = num;
                }
            }
            if (thirdMax == null)
                thirdMax = max;

            return thirdMax.Value;
        }

        [TestMethod]
        public void FindDisappearedNumbers()
        {
            FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
        }
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> output = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int tmpIdx = Math.Abs(nums[i]);
                if (nums[tmpIdx - 1] > 0)
                    nums[tmpIdx - 1] *= -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    output.Add(i + 1);
            }
            return output;
        }
        #endregion


    }
}
