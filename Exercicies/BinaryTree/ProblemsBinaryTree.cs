using System.IO.Pipelines;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using LinkedList;
using Utils;

namespace BinaryTree
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }
    public class TreeNode<T>
    {
        public T val;
        public TreeNode<T> left;
        public TreeNode<T> right;
        public TreeNode(T val, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T value)
        {
            if (this.root == null)
                this.root = new TreeNode<T>(value);
            else
            {
                _Insert(value, this.root);
            }
        }

        public void _Insert(T value, TreeNode<T> node)
        {
            if (value.CompareTo(node.val) < 0)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode<T>(value);
                }
                else
                {
                    _Insert(value, node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new TreeNode<T>(value);
                }
                else
                {
                    _Insert(value, node.right);
                }
            }
        }

        public bool Search(T value)
        {
            return _Search(value, this.root);
        }

        public bool _Search(T value, TreeNode<T> node)
        {
            if (node == null)
            {
                return false;
            }
            if (value.CompareTo(node.val) == 0)
            {
                return true;
            }
            else if (value.CompareTo(node.val) < 0)
            {
                return _Search(value, node.left);
            }
            else
            {
                return _Search(value, node.right);
            }
        }

        public IList<T> PreorderTraversals()
        {
            IList<T> result = new List<T>();

            _PreorderTraversals(this.root, result);

            return result;
        }

        public void _PreorderTraversals(TreeNode<T> node, IList<T> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.val);
            _PreorderTraversals(node.left, result);
            _PreorderTraversals(node.right, result);
        }

        public IList<T> InorderTraversals()
        {
            IList<T> result = new List<T>();

            _InorderTraversals(this.root, result);

            return result;
        }

        public void _InorderTraversals(TreeNode<T> node, IList<T> result)
        {
            if (node == null)
            {
                return;
            }

            _InorderTraversals(node.left, result);
            result.Add(node.val);
            _InorderTraversals(node.right, result);
        }

        public IList<T> PostorderTraversals()
        {
            IList<T> result = new List<T>();

            _PostorderTraversals(this.root, result);

            return result;
        }

        public void _PostorderTraversals(TreeNode<T> node, IList<T> result)
        {
            if (node == null)
            {
                return;
            }

            _PostorderTraversals(node.left, result);
            _PostorderTraversals(node.right, result);
            result.Add(node.val);
        }
    }
    public static class ProblemsBinaryTree
    {
        public static int MaxPathSum(TreeNode<int> root)
        {
            if (root == null) return 0;

            DFSb(root);

            return Util.maxSum;
        }

        public static int maxSum = int.MinValue;

        public static int DFSb(TreeNode<int> root)
        {

            if(root ==null) return 0;
            //calcula o maximo caminho na esquerda e na direita, ignorando
            //valores negativos
            int leftSum = Math.Max(DFSb(root.left),0);
            int rightSum = Math.Max(DFSb(root.right),0);

            //Atualiza a soma maxima globasl considerando o no atual como ponto de juncao
            maxSum = Math.Max(maxSum, leftSum + rightSum + root.val);
            //return o maior caminho unico para a chamada anteriro(nao pode dividir em 2)
            return root.val + Math.Max(leftSum, rightSum);

            
        }
        public static int MaxDepth(TreeNode<int> root)
        {
            if (root == null) return 0;
            int max = 0;

            return DFSMaxDepth(root);


        }

        public static int DFSMaxDepth(TreeNode<int> root)
        {
            if (root == null) return 0;

            return 1 + Math.Max(DFSMaxDepth(root.left), DFSMaxDepth(root.right));
        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode<int> root)
        {
            // Lista para armazenar os resultados finais
            IList<IList<int>> result = new List<IList<int>>();

            //Case whe tree has empty, will return empty list
            if (root == null) return result;

            //Row to make a travel level to level
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);
            //variable to swich the direction of reading the node
            bool leftToRight = true;

            //where have nodes in row
            while (queue.Count > 0)
            {
                // row to keep values to high level
                int levelSize = queue.Count;
                List<int> level = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode<int> node = queue.Dequeue();

                    if (leftToRight)
                    {
                        level.Add(node.val);
                    }
                    else
                    {
                        // inserir no inicio para inverter a direcao
                        level.Insert(0, node.val);
                    }
                    //adiciona os filhos a fila para o proximo nivel
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);

                }

                result.Add(level);

                leftToRight = !leftToRight;
            }

            return result;
        }

        public static TreeNode<int> BuildTree(int[] inorder, int[] postorder)
        {
            // Função recursiva Build que recebe duas fatias (subarrays) dos arrays inorder e postorder
            TreeNode<int>? Build(Span<int> inorder, Span<int> postorder)
            {
                // Caso base: se algum dos arrays estiver vazio, não há mais nós a serem construídos
                if (inorder.Length == 0 || postorder.Length == 0)
                {
                    return null;
                }

                // A raiz da árvore/subárvore é o último elemento do postorder
                // postorder[^1] pega o último elemento do array postorder
                var pos = inorder.IndexOf(postorder[^1]);

                // Criar o nó da raiz com o valor do último elemento de postorder
                // Aqui estamos montando o nó raiz da árvore/subárvore
                return new TreeNode<int>(postorder[^1])
                {
                    // A subárvore esquerda é construída recursivamente
                    left = Build(inorder[..pos], postorder[..pos]),

                    // A subárvore direita é construída recursivamente
                    right = Build(inorder[(pos + 1)..], postorder[pos..^1])
                };
            }

            // Chama a função Build com o array completo inorder e postorder
            return Build(inorder, postorder);

        }

        public static int SearchBinaryTree(int[] nums, int target)
        {
            int lenArr = nums.Length;
            int lowPos = 0;
            int highPos = lenArr;

            while (lowPos < highPos)
            {
                int middle = (int)((lowPos + highPos) / 2);

                if (nums[middle] == target)
                {
                    return middle;
                }

                if (nums[middle] < target)
                {
                    lowPos = middle + 1;
                }
                else
                {
                    highPos = middle;
                }
            }

            return -1;
        }

        public static Node LowestCommonAncestor(Node p, Node q)
        {
            var pNodes = GetAncestors(p);
            var qNodes = GetAncestors(q);
            return pNodes.Intersect(qNodes).First();
        }

        private static IEnumerable<Node> GetAncestors(Node node)
        {
            while (node != null)
            {
                yield return node;
                node = node.parent;
            }
        }

        public static TreeNode<int> LowestCommonAncestor(TreeNode<int> root, TreeNode<int> p, TreeNode<int> q) {
        if(root == null || root == p || root == q) return root;
        
        TreeNode<int> left = LowestCommonAncestor(root.left , p, q);
        TreeNode<int> right = LowestCommonAncestor(root.right, p, q);
        
        if(left != null && right != null)
        {
            return root;
        }
        
        return left ?? right;
    }
    }
}