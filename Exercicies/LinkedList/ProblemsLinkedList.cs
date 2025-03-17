using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinkedList
{

    public class ListNode<T>
    {
        public T val;
        public ListNode<T> next;
        public ListNode(T val, ListNode<T> next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Node<T>
    {
        public T val;
        public Node<T> next;
        public Node<T> random;

        public Node(T val)
        {
            this.val = val;
            this.next = null;
            this.random = null;
        }
    }
    public static class ProblemLikendList
    {
        public static ListNode<int> ReverseList(ListNode<int> head)
        {
            // O(n)

            ListNode<int> new_node = null;

            while(head != null)
            {
                var next_node = head.next;
                head.next = new_node;
                new_node = head;
                head = next_node;
            }

            return new_node;
        }

        public static ListNode<int> MergeTwoLists(ListNode<int> list1, ListNode<int> list2) {
        ListNode<int> dummy = new ListNode<int>(0);
        ListNode<int> current = dummy;
        
        while(list1 != null && list2 != null)
        {
            if(list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else{
                current.next = list2;
                list2 = list2.next;
            }
            
            current = current.next;
        }
        
        if(list1 != null) current.next = list1;
        if(list2 != null) current.next = list2;
        
        return dummy.next;
    }
        public static ListNode<int> MergeKList(ListNode<int>[] lists)
        {
            // O(N log K)
            if(lists == null || lists.Length == 0) return null;

            //cria uma fila de prioridade ordenada pelo valor do no
            var priorityQueue = new PriorityQueue<ListNode<int>, int>();

            // adiciona os primeiros nos de cada lista nao vazia na fila
            foreach(var list in lists)
            {
                if(list != null)
                {
                    priorityQueue.Enqueue(list, list.val);
                }
            
            }

            ListNode<int> dummy = new ListNode<int>(0);
            ListNode<int> current = dummy;

            while(priorityQueue.Count > 0)
            {
                // extrai o no com menor valor
                var node = priorityQueue.Dequeue();

                //adiciona o no a lista resultante
                current.next = node;
                current = current.next;

                if(node.next != null)
                {
                    priorityQueue.Enqueue(node.next, node.next.val);
                }

            }

            return dummy.next;

        }

        public static ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            //O(n)
            ListNode<int> dummy = new ListNode<int>(0);
            ListNode<int> current = dummy;
            int carry = 0;

            while(l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;

                if(l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if(l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;

                }

                carry = sum / 10;

                current.next = new ListNode<int>(sum % 10);
                current = current.next;
            }
            return dummy.next;
        }
    
        public static Node<int> CopyRandomList(Node<int> head)
        {
            //O(n)
            if(head == null) return null;
            // criar um mapeamento entre os nos originais e os novos
            Dictionary<Node<int>,Node<int>> oldToNew = new Dictionary<Node<int>, Node<int>>();

            Node<int> current = head;

            while(current != null)
            {
                oldToNew[current] = new Node<int>(current.val);
                current = current.next;
            }

            // ajusar os ponteiros next e random

            current = head;
            while(current != null)
            {
                oldToNew[current].next = current.next != null ? oldToNew[current.next]: null;
                oldToNew[current].random = current.random != null ? oldToNew[current.random] : null;
                current = current.next;
            }

            return oldToNew[head];
        }       
    }
}