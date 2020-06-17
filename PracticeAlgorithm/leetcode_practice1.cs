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

        #region | ZigZag Conversion | 

        [TestMethod]
        public void ZigZagCon()
        {
            Print(ZigZagConvert("PAYPALISHIRING", 3));
        }
        private string ZigZagConvert(string s, int numRows)
        {
            StringBuilder retStr = null;

            if (string.IsNullOrWhiteSpace(s) || numRows <= 1 )
                return s;

            retStr = new StringBuilder();
            string[] matrixStr = new string[numRows];
            for (int r = 0; r < numRows; r++)
                matrixStr[r] = "";

            int startRow = 0;
            int currCursor = 0;
            while(s.Length > currCursor)
            {
                if (startRow == numRows)
                    startRow += -2;
                else if( startRow > 0)
                    startRow--;

                if (startRow == 0)
                {
                    for (; startRow < numRows; startRow++)
                    {
                        if (s.Length > currCursor)
                        {
                            matrixStr[startRow] += s[currCursor];
                            currCursor++;
                        }
                        else
                            break;
                    }
                }
                else
                {
                    matrixStr[startRow] += s[currCursor];
                    currCursor++;
                }
            }       //End While

            for (int r = 0; r < numRows; r++)
                retStr.Append(matrixStr[r]);

            return retStr.ToString();
        }


        #endregion

        #region | Longest Palindromic Substring | 

        [TestMethod]
        public void LongestPalindrome()
        {
            //Print(LongestPalindrome("abb"));
            //Print(LongestPalindrome("babad"));
            //Print(LongestPalindrome("cbbd"));
        }
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return "";

            int len = 0, start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int oddLen = GetPalidromeLength(s, i, i);
                int evenLen = GetPalidromeLength(s, i, i + 1);
                int maxLen = Math.Max(oddLen, evenLen);

                if (maxLen > len )
                {
                    len = maxLen;
                    start = i - (len - 1) / 2;
                }
            }

            return s.Substring(start, len);
        }
        private int GetPalidromeLength(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }


        private string AddSeperator(string s)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
                str.AppendFormat("#{0}", s[i]);
            str.Append("#");

            return str.ToString();
        }

        #endregion

        #region | String to Integer (atoi) | 
        [TestMethod]
        public void Atoi()
        {
            //Print(MyAtoi("42"));
            //Print(MyAtoi("   -42"));
            //Print(MyAtoi("4193 with words"));
            //Print(MyAtoi("words and 987"));
            //Print(MyAtoi("-91283472332"));
            Print(MyAtoi("-2147483647"));
            
        }
        private int MyAtoi(string str)
        {
            //first discards as many whitespace characters as necessary until the first non-whitespace character is found
            //starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible
            //interprets them as a numerical value.
            //The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
            //If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

            int? result = null;
            bool isCheckedFirstChar = false;
            int isPositive = 1;
            bool isOverflow = false;
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            if (IsIgnoredChar(str[0]) == false
                && IsNumeric(str[0]) == false)
                return 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (result == null && isCheckedFirstChar == false && (str[i] == ' ' || str[i] == '+' || str[i] == '-'))
                {
                    if (str[i] == ' ')
                        continue;
                    if (isCheckedFirstChar == false)
                    {
                        if (str[i] == '-')
                            isPositive = -1;
                        isCheckedFirstChar = true;
                    }
                    else
                    {
                        result = 0;
                        break;
                    }
                }
                else if (IsNumeric(str[i]))
                {
                    if (result == null)
                        result = 0;
                    double tmp = (result.Value * 10L + GetNum(str[i]));
                    if ((tmp * isPositive) <= Int32.MinValue)
                    {
                        result = Int32.MinValue;
                        isOverflow = true;
                        break;
                    }
                    else if ((tmp * isPositive) >= Int32.MaxValue)
                    {
                        result = Int32.MaxValue;
                        isOverflow = true;
                        break;
                    }
                    result = (int)tmp;
                }
                else
                {
                    if ((isCheckedFirstChar == true || result != null)
                       || (result == null && isCheckedFirstChar == false))
                        break;
                }
            }

            if (result != null && isOverflow != true)
                result = result * isPositive;

            return result == null ? 0 : result.Value;
        }
        private bool IsIgnoredChar(char c)
        {
            bool retVal = true;
            if (c == ' ' || c == '+' || c == '-')
            {
                retVal = true;
            }
            else
                retVal = false;

            return retVal;
        }
        private bool IsNumeric(char c)
        {
            return (c >= '0' && c <= '9') ? true : false;
        }
        private int GetNum(char c)
        {
            return c - '0';
        }

        #endregion

        #region | Integer to Roman | 

        [TestMethod]
        public void IntToRoman()
        {
            Print(IntToRoman(1994));
        }
        public string IntToRoman(int num)
        {
            string romanNum = string.Empty;
            if (num >= 5000 || num <= 0)
                return romanNum;
            int decPos = 1;
            do
            {
                int rest = num % 10;
                romanNum = GetRomanSymbols(rest, decPos) + romanNum;
                num = num / 10;
                decPos++;
            }
            while (num != 0);

            return romanNum;
        }
        private string GetRomanSymbols(int n, int decPos)
        {
            string retRoman = string.Empty;
            if (n == 0)
                return retRoman;

            if (decPos == 1)
            {
                retRoman = GetSymbols("I", "V", "X", n);
            }
            else if (decPos == 2)
            {
                //10
                retRoman = GetSymbols("X", "L", "C", n);
            }
            else if (decPos == 3)
            {
                //100
                retRoman = GetSymbols("C", "D", "M", n);
            }
            else if (decPos == 4)
            {
                //1000
                retRoman = GetSymbols("M", "", "", n);
            }

            return retRoman;
        }
        private string GetSymbols(string one, string five, string ten, int n)
        {
            string retRoman = string.Empty;
            if (n >= 4)
                retRoman = five;

            if (n % 5 <= 3)
            {
                for (int i = 0; i < n % 5; i++)
                    retRoman += one;
            }
            else if (n % 5 == 4)
            {
                if (n - 5 > 0)
                    retRoman = one + ten;
                else
                    retRoman = one + retRoman;
            }

            return retRoman;
        }


        #endregion


        #region | Container With Most Water  |

        [TestMethod]
        public void MaxArea()
        {
            Print(MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }
        private int MaxArea(int[] height)
        {
            int maxContainedWater = 0;

            if (height == null || height.Length < 2)
                return maxContainedWater;

            int startP = 0, endP = height.Length - 1;
            while(startP < endP)
            {
                maxContainedWater = Math.Max(maxContainedWater, Math.Min(height[startP],height[endP]) * (endP - startP));
                if (height[startP] < height[endP])
                    startP++;
                else
                    endP--;
            }

            return maxContainedWater;

            //for (int i = 0; i < height.Length; i++)
            //{

            //}
        }

        #endregion

        #region | 3Sum | 

        [TestMethod]
        public void ThreeSum()
        {
            //https://en.wikipedia.org/wiki/3SUM
            IList<IList<int>> results = ThreeNumsSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //IList<IList<int>> results = ThreeNumsSum(new int[] { 0, 0, 0 });

            foreach (var list in results)
            {
                string s = string.Empty;
                foreach (var i in list)
                    s += i.ToString() + ", ";
                Print(s);
            }
        }
        private IList<IList<int>> ThreeNumsSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
                return result;

            Array.Sort(nums);
            int a, b, c;
            a = nums[0];
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if( i != 0)
                {
                    while (i < nums.Length -2 && a == nums[i])
                        i++;

                    if (i >= (nums.Length-2))
                        break;
                }

                a = nums[i];
                if (a > 0)  // 0, 0, 0
                    break;
                int start = i + 1;
                int end = nums.Length - 1;
                if (start >= (nums.Length-1) || start >= end)
                    break;

                while (start < end)
                {
                    b = nums[start];
                    c = nums[end];
                    if (a + b + c == 0)
                    {
                        int[] tmp = new int[] { a, b, c };
                        result.Add(tmp.ToList<int>());
                        
                        while (start + 1 <= end && nums[start] == nums[start + 1]) start++;
                        start++; end--;
                    }
                    else if (a + b + c > 0)
                        end--;
                    else
                        start++;
                }       //End While
            }

            return result;
        }

        #endregion

        #region | 3Sum Closest | 

        [TestMethod]
        public void ThreeSumClosest()
        {
            Print(ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
            Print(ThreeSumClosest(new int[] { 0, 0, 0 }, 1));
        }
        private int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int? closest = null;

            for (int i = 0; i < nums.Length; i++)
            {
                int low = i + 1;
                int high = nums.Length - 1;

                while(low < high)
                {
                    int sum = nums[i] + nums[low] + nums[high];
                    if (closest == null || Math.Abs(target - sum) < Math.Abs(target - closest.Value))
                        closest = sum;

                    if (sum == target)
                        return sum;
                    else if (sum > target)
                    {
                        high--;
                    }
                    else
                        low++;
                }
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                    i++;
            }
            
            return closest != null ? closest.Value : int.MaxValue;
        }
        #endregion

        #region | 4Sum | 

        [TestMethod]
        public void FourSum()
        {
            IList<IList<int>> results = FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            foreach (var list in results)
            {
                string s = string.Empty;
                foreach (var i in list)
                    s += i.ToString() + ", ";
                Print(s);
            }
        }
        private IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            int idxFirst = 0;
            int len = nums.Length;
            IList<IList<int>> result = null;
            result = new List<IList<int>>();
            while (idxFirst < len - 3)
            {
                if ((target - nums[idxFirst]) < 3 * nums[idxFirst + 1])
                    break;

                while (idxFirst + 3 < len && (target - nums[idxFirst]) > 3 * nums[len - 1])
                    idxFirst++;

                int idxSec = idxFirst + 1;
                while(idxSec < len - 2)
                {
                    if ((target - nums[idxFirst] - nums[idxSec]) < 2 * nums[idxSec + 1])
                        break;

                    while (idxSec + 2 < len && (target - nums[idxFirst] - nums[idxSec]) > 2 * nums[len - 1])
                        idxSec++;

                    int left = idxSec + 1;
                    int right = len - 1;
                    int newTarget = target - nums[idxFirst] - nums[idxSec];
                    while( left < right)
                    {
                        if (nums[left] + nums[right] > newTarget)
                            right--;
                        else if (nums[left] + nums[right] < newTarget)
                            left++;
                        else
                        {
                            IList<int> tr = new List<int>();
                            tr.Add(nums[idxFirst]); tr.Add(nums[idxSec]); tr.Add(nums[left]); tr.Add(nums[right]);
                            result.Add(tr);
                            while (left < len && left < right && nums[left] == nums[left + 1])
                                left++;
                            while (right >= 0 && left < right && nums[right] == nums[right - 1])
                                right--;
                            left++; right--;
                        }
                    }

                    while (idxSec < len - 3 && nums[idxSec] == nums[idxSec + 1])
                        idxSec++;
                    idxSec++;
                }   //End while idx second

                while (idxFirst < len - 4 && nums[idxFirst] == nums[idxFirst + 1])
                    idxFirst++;
                idxFirst++;
            }   //End while idx first

            return result;
        }

        #endregion

        #region | Regular Expression Matching | 

        [TestMethod]
        public void IsMatch()
        {
            Print(IsMatch("aaa", "ab*a*c*a"));
            Print(IsMatch("ab", ".*"));
            Print(IsMatch("aab", "c*a*b"));
            Print(IsMatch("mississippi", "mis*is*p*"));
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=l3hda49XcDE&list=PLrmLmBdmIlpuE5GEMDXWf0PWbBD9Ga1lO
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            bool[][] dp = new bool[s.Length + 1][];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i] = new bool[p.Length + 1];
                dp[i][0] = false;
            }

            dp[0][0] = true;
            for (int i = 1; i <= p.Length; i++)
            {
                if (p[i - 1] == '*')
                    dp[0][i] = dp[0][i - 2];
            }


            for (int i = 1; i <=s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                        dp[i][j] = dp[i - 1][j - 1];
                    else if (p[j - 1] == '*')
                    {
                        dp[i][j] = dp[i][j - 2];
                        if (dp[i][j] == false && (p[j - 2] == '.' || p[j - 2] == s[i - 1]))
                            dp[i][j] = dp[i-1][j];
                    }
                    else
                        dp[i][j] = false;
                }
            }

            return dp[s.Length][p.Length];
        }
        #endregion


        #region | LetterCombinations |

        [TestMethod]
        public void LetterCombinations()
        {
            LetterCombinations("23");
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> combinations = new List<string>();

            if (string.IsNullOrWhiteSpace(digits))
                return combinations;

            digits = digits.Replace("1", "");
            if (string.IsNullOrWhiteSpace(digits))
                return combinations;

            Dictionary<char, string> letters = new Dictionary<char, string>();
            letters.Add('2', "abc");
            letters.Add('3', "def");
            letters.Add('4', "ghi");
            letters.Add('5', "jkl");
            letters.Add('6', "mno");
            letters.Add('7', "pqrs");
            letters.Add('8', "tuv");
            letters.Add('9', "wxyz");

            combinations.Add("");
            foreach (char c in digits)
            {
                //if (letters.ContainsKey(c) == false || string.IsNullOrWhiteSpace(letters[c]))
                //    continue;

                combinations = CombineLetter(combinations, letters[c]);
            }

            return combinations;
        }
        private IList<string> CombineLetter(IList<string> combinations, string letters)
        {
            IList<string> next = new List<string>();

            foreach(string ori in combinations)
            {
                foreach(char c in letters)
                {
                    next.Add(ori + c);
                }
            }

            return next;
        }


        #endregion

        #region | ArrayPractice | 

        [TestMethod]
        public void ArrayPractice()
        {
            Print(FindMaxConsecutiveOnes(new int[] { 1,0,1,1,0,1 }));
            Print(FindNumbers(new int[] { 555, 901, 482, 1771 }));
            Print(SortedSquares(new int[] { -4, -1, 0, 3, 10 }));
        }
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int len = 0;
            int maxLen = 0;
            foreach (int i in nums)
            {
                if (i == 1)
                    len++;
                else
                {
                    maxLen = Math.Max(maxLen, len);
                    len = 0;
                }
            }
            maxLen = Math.Max(maxLen, len);

            return maxLen;
        }

        public int FindNumbers(int[] nums)
        {
            int cntEvenNum = 0;

            if (nums == null || nums.Length < 1)
                return cntEvenNum;

            foreach(int num in nums)
            {
                if (numOfDigits(num) % 2 == 0)
                    cntEvenNum++;
            }

            return cntEvenNum;
        }
        private int numOfDigits(int n)
        {
            int ret = 1;

            while ((n = n / 10) != 0)
            {
                ret++;
            }

            return ret;
        }

        public int[] SortedSquares(int[] A)
        {
            if (A == null || A.Length == 0)
                return null;

            int[] retArray = new int[A.Length];

            for(int i = 0; i < A.Length; i++)
            {
                retArray[i] = A[i] * A[i];
            }

            Array.Sort(retArray);
            return retArray;
        }

        #endregion


        #region | Remove Nth Node From End of List | 

        [TestMethod]
        public void RemoveNthFromEnd()
        {
            ListNode node = new ListNode(1);
            node.next = new ListNode(2);
            node.next.next = new ListNode(3);
            node.next.next.next = new ListNode(4);
            node.next.next.next.next = new ListNode(5);
            RemoveNthFromEnd(node, 2);
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (n == 0 || head == null || head.next == null)
                return null;

            Dictionary<int, ListNode> buff = new Dictionary<int, ListNode>();

            int i = 0;
            ListNode first = new ListNode(0);
            buff.Add(i++, first);
            first.next = head;
            while (first.next != null)
            {
                buff.Add(i++, first.next);
                first = first.next;
            }

            int newNext = buff.Count - n + 1;
            if (buff.Count - 1  == n )
                return head.next;
            else if (newNext == buff.Count)
                buff[buff.Count - n - 1].next = null;
            else
                buff[buff.Count - n - 1].next = buff[newNext];

            return head;
        }
        #endregion


        #region | Valid Parentheses | 

        [TestMethod]
        public void IsValid()
        {
            Print(IsValid("()"));
            Print(IsValid("()[]{}"));
            Print(IsValid("([)]"));
        }

        public bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;
            else if (s.Length % 2 != 0)
                return false;

            bool isValid = true;

            //Stack
            Stack<char> sBuff = new Stack<char>();
            for(int i = 0; i < s.Length; i++)
            {
                int val = convertParentheses(s[i]);
                if (val == 0)
                {
                    isValid = false;
                    break;
                }
                if ( val < 10)
                    sBuff.Push(s[i]);
                else
                {
                    if (sBuff.Count > 0)
                    {
                        if (convertParentheses(sBuff.Pop()) == val % 10)
                            continue;
                    }

                    isValid = false;
                    break;
                }
            }
            if (isValid == true)
                isValid = (sBuff.Count == 0);
            

            return isValid;
        }
        int convertParentheses(char c)
        {
            if (c == '(')
                return 1;
            else if (c == '[')
                return 2;
            else if (c == '{')
                return 3;
            else if (c == ')')
                return 11;
            else if (c == ']')
                return 12;
            else if (c == '}')
                return 13;
            else
                return 0;
        }


        #endregion




        #region | Merge Two Lists | 

        [TestMethod]
        public void MergeTwoLists()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            MergeTwoLists(l1, l2);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode(0);
            ListNode next = root;

            while (l1 != null && l2 != null)
            {
                if( (l1.val > l2.val))
                {
                    next.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    next.next = l1;
                    l1 = l1.next;
                }
                next = next.next;
            }

            if (l1 != null)
                next.next = l1;
            else if (l2 != null)
                next.next = l2;

            return root != null ? root.next : null;
        }

        #endregion


        #region | Generate Parenthesis | 

        [TestMethod]
        public void GenerateParenthesis()
        {
            GenerateParenthesis(7);
        }

        public IList<string> GenerateParenthesis(int n)
        {

            //TODO
            return null;
        }

        #endregion


        #region | Remove Duplicates from Sorted Array |

        [TestMethod]
        public void RemoveDuplicates()
        {
            Print(RemoveDuplicates(new int[] { }));
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int len = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    nums[len] = nums[i];
                    len++;
                }
            }

            return len;
        }

        #endregion

        #region | Remove Element |

        [TestMethod]
        public void RemoveElement()
        {
            Print(RemoveElement(new int[] { 3, 2, 2, 3 }, 3));
        }

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            if (nums == null || nums.Length < 1)
                return i;

            for(int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                    nums[i++] = nums[j];
            }

            return i;
        }

        #endregion

        #region | Implement strStr() |

        [TestMethod]
        public void StrStr()
        {
            Print(StrStr("mississippi", "mississippi"));
        }

        public int StrStr(string haystack, string needle)
        {
            int startIdx = -1;

            if (string.IsNullOrWhiteSpace(haystack) && string.IsNullOrWhiteSpace(needle))
                return 0;
            else if (string.IsNullOrWhiteSpace(needle))
                return 0;
            else if (string.IsNullOrWhiteSpace(haystack))
                return startIdx;

            for(int i = 0; i < haystack.Length; i++)
            {
                int n = 0;
                if ( (haystack.Length - i) < needle.Length )
                    break;
                for (int j = i; j < haystack.Length; j++)
                {
                    if (haystack[j] == needle[n])
                    {
                        if (n == (needle.Length - 1))
                            return j - n;

                        n++;
                    }
                    else
                        break;
                }
            }
            return startIdx;
        }

        #endregion


        #region | Search Insert Position | 

        [TestMethod]
        public void SearchInsert()
        {
            Print(SearchInsert(new int[] {1,3,5,6 }, 5));
        }
        public int SearchInsert(int[] nums, int target)
        {
            int idxInserted = 0;

            if (nums == null || nums.Length < 1)
                return idxInserted;

            idxInserted = nums.Length;
            for (int i = 0; i < idxInserted; i++)
            {
                if (nums[i] >= target)
                {
                    idxInserted = i;
                    break;
                }
            }

            return idxInserted;
        }
        #endregion

        #region | Count And Say | 

        [TestMethod]
        public void CountAndSay()
        {
            Print(CountAndSay(4));
        }
        public string CountAndSay(int n)
        {
            string startSTr = "1";
            if (n == 1)
                return startSTr;

            for (int i = 0; i < n-1; i++)
            {
                startSTr = SayStr(startSTr);
            }

            return startSTr;
        }
        public string SayStr(string countStr)
        {
            StringBuilder sbRet = new StringBuilder();

            char previousNum = countStr[0];
            int count = 1;
            for (int i = 1; i < countStr.Length; i++)
            {
                if(previousNum != countStr[i])
                {
                    sbRet.AppendFormat("{0}{1}", count, previousNum);
                    previousNum = countStr[i];
                    count = 1;
                }
                else
                    count++;
            }
            if (count > 0)
                sbRet.AppendFormat("{0}{1}", count, previousNum);

            return sbRet.ToString();
        }
        #endregion


        #region | Maximum Subarray - Kadane's aglorithm(Dynamic Programming) |
        //https://medium.com/@rsinghal757/kadanes-algorithm-dynamic-programming-how-and-why-does-it-work-3fd8849ed73d#:~:text=Kadane's%20algorithm%20is%20able%20to,runtime%20of%20O(n).
        [TestMethod]
        public void MaxSubArray()
        {
            Print(MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
        private int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int sum = nums[0], max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], sum + nums[i]);
                max = Math.Max(sum, max);
            }

            return max;
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
