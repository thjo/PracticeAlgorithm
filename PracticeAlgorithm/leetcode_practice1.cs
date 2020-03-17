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
    }

    //Definition for singly-linked list.
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
     }
}
