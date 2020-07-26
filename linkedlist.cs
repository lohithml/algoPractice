using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class linkedlist
    {
        internal class Node
        {
            internal int data;
            internal Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        internal class SingleLinkedList
        {
            internal Node head;
        }

        internal void InsertFront(SingleLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = singlyList.head;
            singlyList.head = new_node;
        }

        internal void InsertLast(SingleLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            if (singlyList.head == null)
            {
                singlyList.head = new_node;
                return;
            }
            Node lastNode = GetLastNode(singlyList);
            lastNode.next = new_node;
        }

        internal Node GetLastNode(SingleLinkedList singlyList)
        {
            Node tmp = singlyList.head;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            return tmp;
        }

        internal void InsertAfter(Node prevNode, int d) {
            if (prevNode == null) {
                Console.WriteLine("The given previous node Cannot be null");
                return;
            }
            Node newNode = new Node(d);
            newNode.next = prevNode.next;
            prevNode.next = newNode;
        }

        internal void deleteWithkey(SingleLinkedList singleList, int key) {
            Node tmp=singleList.head;
            Node prev = null;

            if (tmp != null && tmp.data == key) {
                singleList.head = tmp.next;
                return;
            }

            while (tmp != null && tmp.data != key) {
                prev = tmp;
                tmp = tmp.next;
            }
            if (tmp == null) {
                return;
            }
            prev.next = tmp.next;

        }

        internal void reverseLinkedList(SingleLinkedList singleList) {
            Node prev=null;
            Node cur = singleList.head;
            Node tmp=null;
            while (cur != null) {
                tmp = cur.next;
                cur.next = prev;
                prev = cur;
                cur=tmp;
            }
            singleList.head = prev;
        }

        internal class DNode
        {
            internal int data;
            internal DNode prev;
            internal DNode next;
            public DNode(int d)
            {
                data = d;
                prev = null;
                next = null;
            }
        }

        internal class DoubleLinkedList
        {
            internal DNode head;
        }

        internal void InsertFront(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            newNode.next = doubleLinkedList.head;
            newNode.prev = null;
            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }

        internal void InsertLast(DoubleLinkedList doubleLinkedList, int data)
        {
            DNode newNode = new DNode(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            DNode lastNode = GetLastNode(doubleLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        internal DNode GetLastNode(DoubleLinkedList doubleList) {
            DNode tmp = doubleList.head;
            while (tmp.next != null) {
                tmp = tmp.next;
            }
            return tmp;
        }

        internal void InsertAfter(DNode prev_node, int data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            DNode newNode = new DNode(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }

    }
}
