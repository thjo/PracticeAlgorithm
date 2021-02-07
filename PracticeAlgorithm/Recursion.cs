using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class Recursion
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
        void Print(int[] output, bool newLine = true)
        {
            foreach (int o in output)
            {
                Print(o, newLine);
            }
        }


        #region | Principle of Recursion | 

        [TestMethod]
        public void ReverseString()
        {
            ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
        }
        public void ReverseString(char[] s)
        {
            ReverseStringH(s, 0, s.Length-1);
        }
        public void ReverseStringH(char[] s, int iStart, int iEnd)
        {
            if (s == null || s.Length < 1 || iStart >= iEnd)
                return;

            char tmp = s[iStart];
            s[iStart++] = s[iEnd];
            s[iEnd--] = tmp;

            ReverseStringH(s, iStart, iEnd);
        }

        [TestMethod]
        public void SwapPairs()
        {
            ListNode ln1 = new ListNode(1, null);
            ListNode ln2 = new ListNode(2, null);
            ln1.next = ln2;
            ListNode ln3 = new ListNode(3, null);
            ln2.next = ln3;
            ListNode ln4 = new ListNode(4, null);
            ln3.next = ln4;
            SwapPairs(ln1);
        }
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            int tmp = head.next.val;
            head.next.val = head.val;
            head.val = tmp;

            SwapPairs(head.next.next);
            return head;
        }

        #endregion
    }
}
