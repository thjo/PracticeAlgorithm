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
            int comb = 0;
            if (amount < 1)
                return 0;

            int[][] dp = new int[coins.Length][];
            for (int i = 0; i < coins.Length; i++)
            {
                dp[i] = new int[amount + 1];
                dp[i][0] = 1;
                for (int a = 1; a <= amount; a++)
                    dp[i][a] = 0;
            }

            Array.Sort(coins);
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] == 0)
                    continue;

                for (int a = 1; a <= amount; a++)
                {
                    if (coins[i] <= a)
                    {
                        if (a % coins[i] == 0)
                            dp[i][a] = dp[i][a] + 1;

                        if (dp[i][a - coins[i]] > 0)
                            dp[i][a] += dp[i][a - coins[i]];
                    }
                }
            } //End for - coins
            for(int c = 0; c < coins.Length; c++)
                comb += dp[c][amount];

            return comb;
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
    }

    //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
     }
}
