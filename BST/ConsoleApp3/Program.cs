using System;

namespace ConsoleApp3
{
    public class Node
    {
        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int value, Node left = null, Node right= null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }
    class BST
    {
        public Node root { get; set; }
        public void AddNode(Node toAdd)
        {
            Node temp = this.root;
            Node pNode = null;
            while (temp != null)
            {
                pNode = temp;
                if (temp.value > toAdd.value)
                    temp = temp.left;
                else
                    temp = temp.right;
            }
            if (pNode.value > toAdd.value)
                pNode.left = toAdd;
            else
                pNode.right = toAdd;
        }
        public void Inorder(Node start)
        {
            if (start != null)
            {
                Inorder(start.left);
                Console.WriteLine(start.value);
                Inorder(start.right);
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Node start = new Node(5);
            BST bs = new BST();
            bs.root = start;
            bs.AddNode(new Node(7));
            bs.AddNode(new Node(3));
            bs.AddNode(new Node(4));
            bs.AddNode(new Node(8));
            bs.AddNode(new Node(6));
            bs.Inorder(bs.root);
        }
    }
}
