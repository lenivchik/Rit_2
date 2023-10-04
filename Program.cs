using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{

    public class TreeNode
    {
        public int Value { get; }
        public int Count;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = Right = null;
            Count = 1;
        }
    }


    public class BinaryTree
    {
        public TreeNode Root;

        public void Fill()
        {
            Console.WriteLine("Введите кол-во элементов");
            int n = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                Insert(rnd.Next(0, 100));
        }



        private TreeNode InsertRecursive(TreeNode Root, int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                return Root;
            }
            if (value == Root.Value)
                Root.Count++;
            if (value < Root.Value)
                Root.Left = InsertRecursive(Root.Left, value);
            else if (value > Root.Value)
                Root.Right = InsertRecursive(Root.Right, value);

            return Root;
        }

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private void Preorder(TreeNode node)
        {
            if (node == null)
                return;

            Console.Write($"{node.Value}({node.Count}) "); ;
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public void Preorder()
        {
            Preorder(Root);
        }
        public void BFS()
        {
            if (Root == null)
                return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.WriteLine($"{node.Value}({node.Count}");

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

    }
    internal class Program
    {

        static public void Menu(BinaryTree tree)
        {
            while (true)
            {
                Console.WriteLine("\n1. Добавить элемент");
                Console.WriteLine("2. Обход в глубину");
                Console.WriteLine("3. Обход в ширину");
                Console.WriteLine("4. Exit");

                char ch = char.Parse(Console.ReadLine()); 
                switch (ch)
                {
                    case '1':
                        Console.WriteLine("Введите число для вставки");
                        int n = Convert.ToInt32(Console.ReadLine());
                        tree.Insert(n);
                        break;
                    case '2':
                        tree.Preorder();
                        break;
                    case '3':
                        tree.BFS();
                        break;
                    case '4':
                        return;
                }
            }

        }


        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Fill();
            Menu(tree);
            Console.ReadLine();
        }
    }
}
