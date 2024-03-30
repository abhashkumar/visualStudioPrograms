using System.Diagnostics.Tracing;

public  class Program
{

    class Node
    {
        public int value { get; set; }
        public Node? next { get; set; }

        public Node(int value, Node? next = null)
        {
            this.value = value;
            this.next = next;   
        }

    }

    class LinkedList
    {

        private Node? head { get; set; }

        public LinkedList()
        {
            head = null;
        }

        public void AddNode(Node? n)
        {
            Node? temp = head;
            if(temp == null)
            {
                head = n;
            }
            else
            {
                while (temp.next != null)
                    temp = temp.next;

                temp.next = n;
            }
        }

        public void printAll()
        {
            Node? temp = head;
            while(temp != null)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
        }

        public void deleteNode(Node? node)
        {

            if(node == head)
            {
                head = head.next;
            }
            else
            {

                 //1 2 3 4  6 7 8 

                Node? temp = head;
                Node? prev = null;
                while(temp != null && temp != node)
                {
                    prev = temp;
                    temp = temp.next;

                }

                if (temp != null)
                {
                    prev.next = temp.next;
                }

            }
        }
    }





    public static void Main(string[] args)
    {

        LinkedList l = new LinkedList();

        Node head = new Node(1);
       
        l.AddNode(head);
        l.AddNode(new Node(2));
        l.AddNode(new Node(3));
        l.AddNode(new Node(4));
        


        l.printAll();

        Node x = new Node(5);
        l.AddNode(x);
        l.AddNode(new Node(6));

        Console.WriteLine("deleting node 5");

        l.deleteNode(x);

        l.AddNode(new Node(10));
        //l.deleteNode(head);

        l.printAll();

    }
}