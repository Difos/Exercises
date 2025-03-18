
using System.ComponentModel;
using System.Runtime;
using ArraysStrings;
using BinaryTree;
using LinkedList;

namespace Exercicies 
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            // ListNode<int> list1 = new ListNode<int>(1);
            // list1.next = new ListNode<int>(2);
            // list1.next.next = new ListNode<int>(4);

            // // Lista 2: 1 -> 3 -> 4
            // ListNode<int> list2 = new ListNode<int>(1);
            // list2.next = new ListNode<int>(2);
            // list2.next.next = new ListNode<int>(3);

            // // Lista 3: 2 -> 6
            // // ListNode<int> list3 = new ListNode<int>(2);
            // // list3.next = new ListNode<int>(6);

            // //ListNode<int>[] lists = new ListNode<int>[] { list1, list2, list3 };

            // // Executar a solução
           
            // ListNode<int> mergedList = ProblemLikendList.MergeTwoLists(list1, list2);

            // var x = ProblemsArray.BestDishes(4,new int[][] {[512,3], [123,3], [987,4], [123,5]});

            // ListNode<int> l1 = new ListNode<int>(2);
            // l1.next = new ListNode<int>(4);
            // l1.next.next = new ListNode<int>(3);

            //  ListNode<int> l2 = new ListNode<int>(5);
            // l2.next = new ListNode<int>(6);
            // l2.next.next = new ListNode<int>(4);
            // var x = ProblemLikendList.AddTwoNumbers(l1, l2);

        //     Node<int> node1 = new Node<int>(3);
        // Node<int> node2 = new Node<int>(3);
        // Node<int> node3 = new Node<int>(3);

        // // Ligando os nós na sequência
        // node1.next = node2;
        // node2.next = node3;

        // // Definindo os ponteiros random
        // node1.random = null;
        // node2.random = node1;
        // node3.random = null;

        // // Chamando o método para copiar a lista
       
        // Node<int> copiedHead = ProblemLikendList.CopyRandomList(node1);


        //ProblemsArray.Trap(new int[] {0,1,0,2,1,0,1,3,2,1,2,1});

        // TreeNode<int> root = new TreeNode<int>(
        //     -10,
        //     new TreeNode<int>(9),
        //     new TreeNode<int>(20,
        //     new TreeNode<int>(15), new TreeNode<int>(7))
        // );

        // ProblemsBinaryTree.MaxPathSum(root);

        Console.WriteLine(ProblemsArray.Rob(new int[] {2,7,9,3,1}));
       
        }
    }
}
