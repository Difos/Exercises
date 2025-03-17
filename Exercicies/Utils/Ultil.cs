using System.ComponentModel.DataAnnotations;
using BinaryTree;

namespace Utils
{
    public static class Util
    {
        public static int Compare(Tuple<string, string ,string> a, Tuple<string, string,string> b)
        {
            if(b == null) return 1;
            int cmp = a.Item1.CompareTo(b.Item1);
            if(cmp != 0) return cmp;
            return cmp !=0 ? cmp : a.Item3.CompareTo(b.Item3);
        }
        
        public static void DFS(char[][] grid, int i, int j)
        {
            if(i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != '1')
            {
                return;
            }

            grid[i][j] = '0'; //marca como visitado
            DFS(grid, i+1, j);
            DFS(grid, i -1, j);
            DFS(grid, i, j +1);
            DFS(grid, i, j-1);
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

    }
}