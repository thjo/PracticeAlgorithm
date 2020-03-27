using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class Leetcode_practice1
    {
        public int TEN = 10;

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


        #region | Add Two Numbers | 

        [TestMethod]
        public void AddTwoNumbers()
        {
            //ListNode l1 = new ListNode(2);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(3);
            //ListNode l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //l2.next.next = new ListNode(4);
            ListNode l1 = new ListNode(0);
            ListNode l2 = new ListNode(0);

            ListNode result = AddTwoNum(l1, l2);
            Print(string.Format("{0}", result.val));
            ListNode next = result;
            while ((next = next.next) != null)
            {
                Print(string.Format("{0}", next.val));
            }
            

            Print("");
        }

        private ListNode AddTwoNum(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);

            int extraVal = 0;
            ListNode n1 = l1, n2 = l2;

            ListNode currNext = result;
            while (n1 != null || n2 != null)
            {
                int val1 = n1 != null ? n1.val : 0;
                int val2 = n2 != null ? n2.val : 0;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;

                currNext.next = createNote(val1, val2, ref extraVal);
                currNext = currNext.next;

                if (n1 != null) n1 = n1.next;
                if (n2 != null) n2 = n2.next;
            }

            if (extraVal > 0)
                currNext.next = new ListNode(extraVal);

            return result.next;
        }

        private ListNode createNote(int l1, int l2, ref int extra)
        {
            int toal = l1 + l2 + extra;
            extra = toal / TEN;
            return new ListNode(toal % TEN);
        }

        #endregion
         
        
        #region | Reverse Integer | 

        [TestMethod]
        public void ReverseInteger()
        {
            Print(ReverseInt(-2147483648));
        }

        private int ReverseInt(int x)
        {
            int? retVal = 0;

            long tmp = retVal.Value;
            bool negative = x < 0 ? true : false;

            while (x != 0)
            {
                tmp = (tmp * 10) + x % 10;
                if (tmp > Int32.MaxValue || tmp < Int32.MinValue)
                {
                    retVal = null;
                    break;
                }
                x = x / 10;
            }

            if (retVal != null)
                retVal = (int)tmp;
            else
                retVal = 0;
            return retVal.Value;
        }

        #endregion
      

        #region | Palindorme | 

        [TestMethod]
        public void Palindrome()
        {
            IsPalindrome(121);
        }
        private bool IsPalindrome(int x)
        {
            if (x < 0 || x == 10)
                return false;
            else if (x < 10)
                return true;
            else
            {
                bool isPalindorme = true;
                string origin = x.ToString();
                int l = 0, r = origin.Length - 1;
                while( 1 < r)
                {
                    if( origin[l] != origin[r])
                    {
                        isPalindorme = false;
                        break;
                    }
                    l++; r--;

                }

                return isPalindorme;
                //int reverseNum = 0;
                //int origin = x;
                //while (origin > 0)
                //{
                //    reverseNum = (reverseNum * 10) + (origin % 10);
                //    origin = origin / 10;
                //}

                //return x == reverseNum;
            }
        }

        #endregion



        #region | Coin Changes | 

        [TestMethod]
        public void CoinChange()
        {
            //int result = TheFewestNumOgCoins(new int[] { 186, 419, 83, 408 }, 6249);
            //int result = TheFewestNumOgCoins(new int[] { 1, 2, 5 }, 12);
            //Print(result);

            Print(coinChange2(new int[] { 1, 2, 5 }, 5));
        }

        public int coinChange(int[] coins, int amount)
        {
            if (amount < 1)
                return 0;

            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
                dp[i] = amount + 1;

            Array.Sort(coins);
            if (coins[coins.Length - 1] == amount)
                return 1;

            for (int a = 1; a <= amount; a++)
            {
                for (int c = 0; c < coins.Length; c++)
                {
                    if (a == coins[c] || a % coins[c] == 0)
                    {
                        dp[a] = Math.Min(dp[a], a / coins[c]);
                    }
                    else if (a > coins[c])
                    {
                        dp[a] = Math.Min(dp[a], dp[a - coins[c]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
        public int coinChange2(int[] coins, int amount)
        {
            if (amount == 0 )
                return 1;
            else if (amount < 1 || coins == null || coins.Length < 1)
                return 0;

            int[] dp = new int[amount + 1];
            dp[0] = 1;
            for (int i = 1; i <= amount; i++)
                dp[i] = 0;

            Array.Sort(coins);
            if (coins[0] > amount)
                return 0;
            else if (coins[0] == amount)
                return 1;

            for (int c = 0; c < coins.Length; c++)
            {
                for (int a = 1; a <= amount; a++)
                {
                    if (a >= coins[c])
                        dp[a] = dp[a] + dp[a - coins[c]];
                }
            }

            return dp[amount];
        }
        public int coinChangeBase(int[] coins, int amount)
        {
            if (amount < 1)
                return 0;
            if (coins.Length == 1)
            {
                if (coins[0] == 0)
                    return -1;
            }

            int[][] dp = new int[2][];
            dp[0] = new int[amount + 1];
            dp[1] = new int[amount + 1];
            dp[0][0] = 1;
            dp[1][0] = 1;
            for (int i = 1; i <= amount; i++)
            {
                dp[0][i] = 0; dp[1][i] = 0;
            }

            int curr = 1, before = 0;
            Array.Sort(coins);
            for (int i = 0; i < coins.Length; i++)
            {
                curr = curr == 0 ? 1 : 0;
                before = before == 0 ? 1 : 0;
                if (coins[i] == 0)
                {
                    continue;
                }
                for (int a = 1; a <= amount; a++)
                {
                    if (coins[i] == a || a % coins[i] == 0)
                    {
                        dp[curr][a] = dp[before][a] + 1;
                    }
                    else if (coins[i] < a)
                    {
                        if (dp[before][a - coins[i]] > 0)
                            dp[curr][a] = dp[before][a - coins[i]] + 1;
                    }
                    else
                        dp[curr][a] = dp[before][a];
                }
            } //End for - coins

            return dp[curr][amount] > 0 ? dp[curr][amount] : -1;
        }

        #endregion



        #region | Longest Substring Without Repeating Characters | 

        [TestMethod]
        public void LongestSubstring()
        {
            Print(LengthOfLongestSubstring("abcabcbb"));
        }

        private int LengthOfLongestSubstring(string s)
        {
            int longestLen = 0;
            int totalLen = s == null ? 0 : s.Length;
            if (totalLen <= 1)
                return totalLen;

            int cursor = 0, startIdx = 0;
            List<char> fullStr = s.ToList();
            while (cursor < totalLen)
            {
                if (cursor - startIdx > 0)
                {
                    int idx = fullStr.IndexOf(s[cursor], startIdx, (cursor - startIdx));

                    if (idx >= 0)
                    {
                        longestLen = Math.Max(longestLen, (cursor - startIdx));
                        startIdx = idx+1;
                    }
                }
                cursor++;
            }
            longestLen = Math.Max(longestLen, (cursor - startIdx));

            return longestLen;
        }

        #endregion



        #region | Median of Two Sorted Arrays

        [TestMethod]
        public void FindMedianSorted()
        {
            Print(FindMedianSortedArrays(new int[] {1, 3}, new int[] { 2 }));
            Print(FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
        }

        private double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double medianVal = 0;
            List<int> mergedList = new List<int>();
            if ( (nums1 == null && nums2 == null)
                || (nums1.Length < 1 && nums2.Length < 1))
            {
                return medianVal;
            }

            int idx1 = 0, idx2 = 0;
            while(idx1 < nums1.Length && idx2 < nums2.Length)
            {
                if(nums1[idx1] > nums2[idx2])
                {
                    mergedList.Add(nums2[idx2]);
                    idx2++;
                }
                else if (nums1[idx1] < nums2[idx2])
                {
                    mergedList.Add(nums1[idx1]);
                    idx1++;
                }
                else
                {
                    mergedList.Add(nums1[idx1]);
                    mergedList.Add(nums2[idx2]);
                    idx1++;
                    idx2++;
                }
            }

            while (idx1 < nums1.Length)
            {
                mergedList.Add(nums1[idx1]);
                idx1++;
            }
            while (idx2 < nums2.Length)
            {
                mergedList.Add(nums2[idx2]);
                idx2++;
            }

            if (mergedList.Count > 2)
            {
                if (mergedList.Count % 2 == 1)
                {
                    Print(string.Format("{0}", mergedList[mergedList.Count / 2]));
                    medianVal = mergedList[mergedList.Count / 2];
                }
                else
                {
                    Print(string.Format("{0}, {1}", mergedList[(mergedList.Count / 2)-1], mergedList[(mergedList.Count / 2)]));
                    medianVal = (mergedList[(mergedList.Count / 2)-1] + mergedList[(mergedList.Count / 2)]) / 2.0;
                }
            }
            else if (mergedList.Count == 2)
            {
                Print(string.Format("{0}, {1}", mergedList[0], mergedList[1]));
                medianVal = (mergedList[0] + mergedList[1]) / 2.0;
            }
            else if (mergedList.Count == 1)
                medianVal = mergedList[0];

            return medianVal;
        }

        #endregion



        #region | Roman to Int | 

        [TestMethod]
        public void RomanStrToInt()
        {
            RomanToInt("MCMXCIV");
        }

        public int RomanToInt(string s)
        {
            /*
            int total = 0;

            if (s == null || s.Length < 1)
                return 0;
            else if (s.Length == 1)
                return RomanAlabet(s[0]);

            int tmp = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (tmp == 0)
                {
                    tmp = RomanAlabet(s[i]);
                    continue;
                }
                else
                {
                    if (s[i - 1] == s[i])
                        tmp += RomanAlabet(s[i]);
                    else
                    {
                        if(tmp / 10 != RomanAlabet(s[i]) / 10)
                        {
                            //자리수 변경
                            if (tmp < RomanAlabet(s[i]))
                            {
                                total += RomanAlabet(s[i]) - tmp;
                                tmp = 0;
                            }
                            else
                            {
                                total += tmp;
                                tmp = RomanAlabet(s[i]);
                            }
                        }
                        else
                        {
                            if(tmp < RomanAlabet(s[i]))
                            {
                                total += RomanAlabet(s[i]) - tmp;
                                tmp = 0;
                            }
                            else
                            {
                                tmp += RomanAlabet(s[i]);
                            }
                        }
                    }
                }
            } //End For

            if (tmp > 0)
                total += tmp;

            return total;
            */

            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            Dictionary<char, int> romanIntegerMap = new Dictionary<char, int>();
            romanIntegerMap.Add('I', 1);
            romanIntegerMap.Add('V', 5);
            romanIntegerMap.Add('X', 10);
            romanIntegerMap.Add('L', 50);
            romanIntegerMap.Add('C', 100);
            romanIntegerMap.Add('D', 500);
            romanIntegerMap.Add('M', 1000);

            int sum = 0;

            s = s.ToUpper();

            for (int cursor = 0; cursor < s.Length; cursor++)
            {
                int currentValue = romanIntegerMap[s[cursor]];
                sum += currentValue;

                if (cursor + 1 < s.Length)
                {
                    if (romanIntegerMap[s[cursor + 1]] > currentValue)
                        sum -= (2 * currentValue);
                }
            }

            return sum;


        }
        private int RomanAlabet(char c)
        {
            int val = -1;
            switch (c)
            {
                case 'I':
                    val = 1;
                    break;
                case 'V':
                    val = 5;
                    break;
                case 'X':
                    val = 10;
                    break;
                case 'L':
                    val = 50;
                    break;
                case 'C':
                    val = 100;
                    break;
                case 'D':
                    val = 500;
                    break;
                case 'M':
                    val = 1000;
                    break;
            }
            return val;
        }

        #endregion



        #region | Longest Prefix | 

        [TestMethod]
        public void LongestPrefix()
        {
            Print(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
        }

        private string LongestCommonPrefix(String[] strs)
        {
            if (strs == null || strs.Length == 0) return "";
            else if (strs.Length == 1) return strs[0];

            return longestCommonPrefix(strs, 0, strs.Length - 1);
        }
        private String longestCommonPrefix(String[] strs, int l, int r)
        {
            if (l == r)
                return strs[l];
            else
            {
                int mid = (l + r) / 2;
                string lcpLeft = longestCommonPrefix(strs, l, mid);
                string lcpRight = longestCommonPrefix(strs, mid + 1, r);
                return GetPrefix(lcpLeft, lcpRight);
            }
        }
        private string GetPrefix(String left, String right)
        {
            int min = Math.Min(left.Length, right.Length);
            for (int i = 0; i < min; i++)
            {
                if (left[i] != right[i])
                    return left.Substring(0, i);
            }
            return left.Substring(0, min);
        }


        private string LongestCommonPrefix2(string[] strs)
        {
            
            string prefix = string.Empty;

            if( strs != null && strs.Length > 0)
            {
                if (strs.Length == 1)
                    prefix = strs[0];
                else
                {
                    int cursor = 0;
                    bool isEnd = false;
                    bool isUnmatched = false;
                    while (true)
                    {
                        char? c = null;
                        for (int i = 0; i < strs.Length; i++)
                        {
                            if (strs[i].Length <= cursor)
                            {
                                isEnd = true;
                                break;
                            }
                            else
                            {
                                if (c == null)
                                    c = strs[i][cursor];
                                else if (c != strs[i][cursor])
                                {
                                    isUnmatched = true;
                                    break;
                                }
                            }
                        }   //End For

                        if (isEnd == true || isUnmatched == true)
                            break;
                        else
                        {
                            prefix += c.Value;
                            cursor++;
                        }

                    }   //End While
                }
            }

            return prefix;
            
        }

        #endregion


        #region | Longest Palindromic Substring | 

        [TestMethod]
        public void LPalindrome()
        {
            Print(LongestPalindrome("babad"));
        }
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length == 1)
                return s;

            return string.Empty;
        }

        #endregion

    }

    //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
     }
}
