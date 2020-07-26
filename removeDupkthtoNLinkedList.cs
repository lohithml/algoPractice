using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary
{
    class removeDupkthtoNLinkedList
    {
        //2 problems
        //1. remove duplicates in linked list
        //2. find the kth node from end of the linked list
        public void MainL()
        {
            LinkedList LL = new LinkedList();

            LL.Add(200);
            LL.Add(300);
            LL.Add(600);
            LL.Add(500);
            LL.Add(600);

            LL.DisplayAllItems();

            LinkedList.Node n = LL.kToLast(3);
            Console.WriteLine(n.data);
            //LL.deleteDup();
            //Console.WriteLine();
            //LL.DisplayAllItems();
            //Console.WriteLine();
            //LL.deleteDupNoBuffer();
            //LL.DisplayAllItems();
        }

        public class LinkedList
        {
            public class Node
            {
                // link to next Node in list
                public Node next;
                // value of this Node
                public object data;
            }

            private Node root = null;

            public Node First { get { return root; } }

            public Node Last
            {
                get
                {
                    Node curr = root;
                    if (curr == null)
                        return null;
                    while (curr.next != null)
                        curr = curr.next;
                    return curr;
                }
            }

            public void Add(object value)
            {
                Node n = new Node { data = value };
                if (root == null)
                    root = n;
                else
                    Last.next = n;
            }

            public void DisplayAllItems()
            {
                Node current = First;
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }

            public void deleteDup()
            {
                Node current = First;
                Node prev = null;
                Hashtable ht = new Hashtable();
                while (current != null)
                {
                    if (ht.Contains(current.data))
                        prev.next = current.next;
                    else
                    {
                        ht.Add(current.data, true);
                        prev = current;
                    }
                    current = current.next;
                }
            }

            public void deleteDupNoBuffer()
            {
                Node current = First;
                while (current != null)
                {
                    Node runner = current;
                    while (runner.next != null)
                    {
                        if (runner.next.data == current.data)
                            runner.next = runner.next.next;
                        else
                            runner = runner.next;
                    }
                    current = current.next;
                }
            }

            public Node kToLast(int k)
            {
                Node lead = First;
                Node lag = First;

                for (int i = 0; i < k; i++)
                    lead = lead.next;

                while (lead != null)
                {
                    lead = lead.next;
                    lag = lag.next;
                }

                return lag;
            }

        }
    }
}

