using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    public class MyLinkedList
    {
        public int Val;
        public MyLinkedList Next;

        public MyLinkedList()
        {
            this.Val = -1;
            this.Next = null;
        }
        public MyLinkedList(int val)
        {
            this.Val = val;
        }
        public MyLinkedList(int val, MyLinkedList next)
        {
            this.Val = val;
            this.Next = next;
        }

        public MyLinkedList GetNode(int index)
        {
            if (index < 0)
                return this;
            int i = 0;
            MyLinkedList currNode = this.Next;
            while (i < index)
            {
                if (currNode != null)
                    currNode = currNode.Next;
                else
                    break;
                i++;
            }

            return currNode;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            int retVal = -1;
            MyLinkedList node = GetNode(index);

            return node != null ? node.Val : retVal;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            MyLinkedList newNode = new MyLinkedList(val);

            MyLinkedList tmp = this.Next;
            this.Next = newNode;
            newNode.Next = tmp;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            MyLinkedList newNode = new MyLinkedList(val);

            MyLinkedList currNode = this;
            while (currNode.Next != null)
                currNode = currNode.Next;
            currNode.Next = newNode;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            MyLinkedList currNode = GetNode(index-1);
            if (currNode != null)
            {
                MyLinkedList newNode = new MyLinkedList(val);
                MyLinkedList tmp = currNode.Next;
                currNode.Next = newNode;
                newNode.Next = tmp;
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            MyLinkedList prevNode = GetNode(index -1);
            if (prevNode != null)
            {
                MyLinkedList delNde = prevNode.Next;
                if(delNde != null)
                    prevNode.Next = delNde.Next;
            }
        }
    }
}
