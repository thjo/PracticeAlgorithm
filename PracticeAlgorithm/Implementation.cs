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

        #region | Birthday Chocolate | 

        [TestMethod]
        public void BirthdayChocolate()
        {

            //Print(Birthday(new int[] { 1, 2, 1, 3, 2 }.ToList<int>(), 3, 2));
            //Print(Birthday(new int[] { 1, 1, 1, 1, 1, 1 }.ToList<int>(), 3, 2));
            //Print(Birthday(new int[] { 4 }.ToList<int>(), 4, 1));

            Print(Birthday(new int[] { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1 }.ToList<int>(), 18, 7));
            Print(Birthday(new int[] { 4, 1, 4, 3, 3, 5, 1, 2, 4, 2, 5, 1, 5, 1, 4, 1, 3, 1, 5, 2, 2, 2, 1, 1, 3, 2, 5, 3, 1, 5, 4, 5, 2, 2, 1, 1, 2, 2, 4, 5, 4, 1, 5, 2, 1, 1, 2, 2, 1, 3, 2, 4, 4, 1, 3, 2, 2, 3, 1, 5, 4, 4, 1, 4, 2, 1, 2, 1, 5, 1, 3, 3, 4, 2, 1, 5, 5, 4, 2, 2 ,3, 3, 4, 3, 1, 2, 1, 2, 4, 3 }.ToList<int>(), 16, 7));
        }
        private int Birthday(List<int> s, int d, int m)
        {
            int cntPossiblity = 0;
            if (s.Count == 1) {
                if (d == s[0] && m == 1)
                    return 1;
                else
                    return 0;
            }

            for(int i = 0; i < s.Count; i++)
            {
                int sum = s[i];
                for (int j = i + 1; j < Math.Min(i + m, s.Count); j++)
                    sum += s[j];

                if (sum == d)
                    cntPossiblity++;
            }

            return cntPossiblity;
        }

        #endregion

        #region | Divisible Sum Pairs |

        [TestMethod]
        public void DivSumPairs()
        {
            Print(DivisibleSumPairs(6, 3, new int[] { 1, 3, 2, 6, 1, 2 }));
        }
        private int DivisibleSumPairs(int n, int k, int[] ar)
        {
            int cntPossiblity = 0;

            for(int i = 0; i < ar.Length-1; i++)
            {
                for(int j = i+1; j < ar.Length; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        cntPossiblity++;
                }
            }

            return cntPossiblity;
        }
        #endregion

        #region | Migratory Birds | 

        [TestMethod]
        public void MigBirds()
        {
            Print(MigratoryBirds(new int[] { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 }.ToList<int>()));
        }
        private int MigratoryBirds(List<int> arr)
        {
            Dictionary<int,int> result = new Dictionary<int, int>();
            for (int i = 0; i < arr.Count; i++)
            {
                if (result.ContainsKey(arr[i]))
                    result[arr[i]]++;
                else
                    result.Add(arr[i], 0);
            }

            int typeOfBird = 6, birdPop = 0;
            foreach (var bird in result)
            {
                if (birdPop < bird.Value)
                {
                    birdPop = bird.Value;
                    typeOfBird = bird.Key;
                }
                else if (birdPop == bird.Value)
                {
                    typeOfBird = Math.Min(bird.Key, typeOfBird);
                }
            }
            return typeOfBird;
        }

        #endregion

        #region | Day of the Programmer | 

        [TestMethod]
        public void DayOfProg()
        {
            //Print(DayOfProgrammer(2016));
            Print(DayOfProgrammer(1918));       //26.09.1918
        }
        private string DayOfProgrammer(int year)
        {
            bool isLeapYear = false;
            if (year > 1917)
            {
                if(year % 400 == 0)
                    isLeapYear = true;
                else if(year % 4 == 0 && year % 100 != 0)
                    isLeapYear = true;
            }
            else
            {
                if (year % 4 == 0)
                    isLeapYear = true;
            }

            if (year == 1918)
                return string.Format("26.09.{0}", year);
            else if (isLeapYear)
                return string.Format("12.09.{0}", year);
            else
                return string.Format("13.09.{0}", year);
        }

        #endregion

        #region | Bon Appétit | 

        [TestMethod]
        public void BonAppetit()
        {
            BonAppetit(new int[] { }.ToList<int>(), 1, 12);

        }
        private void BonAppetit(List<int> bill, int k, int b)
        {
            int actualBillForAnna = (bill.Sum() - bill[k]) / 2;

            if ((b - actualBillForAnna) == 0)
                Print("Bon Appetit");
            else
                Print((b - actualBillForAnna));
        }
        #endregion

        #region | Drawing Book | 

        [TestMethod]
        public void PageCount()
        {
            Print(PageCount(6, 2));
        }

        private int PageCount(int n, int p)
        {
            int cntTurn = Math.Min(p/2, n/2-p/2);

            return cntTurn;
        }

        #endregion

        #region | Grading Students | 

        [TestMethod]
        public void GradingStudents()
        {
            List<int> ret = GradingStudents(new int[] { 73, 67, 38, 33 }.ToList<int>());
            foreach (var g in ret)
                Print(g);
        }
        private List<int> GradingStudents(List<int> grades)
        {
            for(int i = 0; i < grades.Count; i++)
            {
                int grade = grades[i];
                if(grade >= 38 && grade % 5 >= 3)
                {
                    grade = grade + (5 - (grade % 5));
                    grades[i] = grade;
                }
            }

            return grades;
        }
        #endregion

        #region | Electronics Shop |

        [TestMethod]
        public void GetMoneySpent()
        {
            Print(GetMoneySpent(new int[] { 3, 1 }, new int[] { 5, 2, 8 }, 10));
        }
        private int GetMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int ret = -1;

            Array.Sort(keyboards);
            Array.Sort(drives);

            for (int k = keyboards.Length - 1; k >= 0; k--)
            {
                for (int d = drives.Length - 1; d >= 0; d--)
                {
                    int sum = keyboards[k] + drives[d];
                    if (sum == b)
                        return b;
                    else if (sum > b)
                        continue;
                    else
                    {
                        ret = Math.Max(ret, sum);
                        break;
                    }
                }
            }

            return ret;
        }

        #endregion





    }
}
