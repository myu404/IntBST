using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntBST
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class IntSearchTree
    {
        // Field
        public IntTreeNode root { get; private set; };

        // Constructor
        public IntSearchTree() { root = null; }

        // Instance Methods
        public void Add(int value)
        {
            root = Add(root, value);
        }

        private IntTreeNode Add(IntTreeNode root, int value)
        {
            if (root == null) root = new IntTreeNode(value);

            else if (value <= root.data) root.left = Add(root.left, value);

            else root.right = Add(root.right, value);

            return root;
        }

        public static IntSearchTree BuildBSTFromList(List<int> list) { return BuildBSTFromList(new IntSearchTree(), list); }

        private static IntSearchTree BuildBSTFromList(IntSearchTree treeInt, List<int> list)
        {
            if (list.Count == 0) return null;
            List<int> auxList = new List<int>();
            for (int index = 0; index < list.Count; index++)
            {
                if (auxList.Contains(list[index])) continue;
                auxList.Add(list[index]);
                treeInt.Add(list[index]);
            }
            return treeInt;
        }

        public static string ToStringInOrder(IntSearchTree treeInt)
        {
            return ToStringInOrder(treeInt.root);
        }
        public static string ToStringInOrder (IntTreeNode clientRoot)
        {
            string str = "";
            if(clientRoot != null) { str += ToStringInOrder(clientRoot.left) + " " + clientRoot.data + " " + ToStringInOrder(clientRoot.right) + " "; }
            return str;
        }

        public static string ToStringPreOrder(IntSearchTree treeInt)
        {
            return ToStringPreOrder(treeInt.root);
        }
        public static string ToStringPreOrder(IntTreeNode clientRoot)
        {
            string str = "";
            if (clientRoot != null) { str += clientRoot.data + " " + ToStringPreOrder(clientRoot.left) + " " + ToStringPreOrder(clientRoot.right) + " "; }
            return str;
        }

        public static string ToStringPostOrder(IntSearchTree treeInt)
        {
            return ToStringPostOrder(treeInt.root);
        }
        public static string ToStringPostOrder(IntTreeNode clientRoot)
        {
            string str = "";
            if (clientRoot != null) { str += ToStringPostOrder(clientRoot.left) + " " + ToStringPostOrder(clientRoot.right) + " " + clientRoot.data; }
            return str;
        }

        public static int Height(IntSearchTree treeInt) { return Height(treeInt.root); }

        public static int Height(IntTreeNode clientRoot)
        {
            if (clientRoot == null) return 0;

            return 1 + Math.Max(Height(clientRoot.left), Height(clientRoot.right));
        }

        public static int Sum(IntSearchTree treeInt) { return Sum(treeInt.root); }

        public static int Sum(IntTreeNode clientRoot)
        {
            if (clientRoot == null) return 0;

            return clientRoot.data + Sum(clientRoot.left) + Sum(clientRoot.right);
        }

        public static bool Exists(IntSearchTree treeInt, int value) { return Exists(treeInt.root, value); }

        public static bool Exists(IntTreeNode clientRoot, int value)
        {
            if (clientRoot == null) return false;
            else if (clientRoot.data == value) return true;
            else if (clientRoot.data > value) return Exists(clientRoot.left, value);
            else return Exists(clientRoot.right, value);
        }

        public static bool ExistsST(IntSearchTree treeInt, int value) { return ExistsST(treeInt.root, value); }

        public static bool ExistsST(IntTreeNode clientRoot, int value)
        {
            if (clientRoot == null) return false;
            if (clientRoot.data == value) return true;
            return Exists(clientRoot.left, value) || Exists(clientRoot.right, value);
        }
    }

    class IntTreeNode
    {
        public int data;
        public IntTreeNode left;
        public IntTreeNode right;

        public IntTreeNode(int data, IntTreeNode left, IntTreeNode right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        public IntTreeNode(int data) : this(data, null, null) { }
    }
}
