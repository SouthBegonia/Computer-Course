using System;
using System.Text;

namespace CsharpExam
{
    /// <summary>
    /// 序列化二叉树  https://www.nowcoder.com/practice/cf7e25aa97c04cc1a68c8f040e71fb84?tpId=295&tqId=23455&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221228_TreeSerialize
    {
        static void Main()
        {
            TreeNode root = new TreeNode(19);

            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            string serializedTreeStr = Serialize(root);
            Console.WriteLine($"serializedTreeStr = {serializedTreeStr}");

            TreeNode deSerializedTree = Deserialize(serializedTreeStr);
            Console.WriteLine(IsSameTree(root, deSerializedTree).ToString());
        }

        public static string Serialize(TreeNode root)
        {
            if (root == null)
                return "#";

            StringBuilder sb = new StringBuilder();
            InternalSerialize(root, ref sb);

            return sb.ToString();
        }

        private static void InternalSerialize(TreeNode root, ref StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("#");
                return;
            }

            //前序递归遍历
            sb.Append(root.val).Append("!");

            InternalSerialize(root.left, ref sb);
            InternalSerialize(root.right, ref sb);
        }


        public static TreeNode Deserialize(string str)
        {
            if (str == "#")
                return null;

            int index = 0;
            TreeNode root = InternalDeserialize(str, ref index);
            return root;
        }

        private static TreeNode InternalDeserialize(string str, ref int index)
        {
            //空节点
            if (str[index] == '#')
            {
                index++;
                return null;
            }

            int val = 0;
            while (str[index] != '!' && index != str.Length)
            {
                val = val * 10 + (str[index] - '0');
                index++;
            }

            TreeNode root = new TreeNode(val);

            if (index == str.Length)
                return root;
            else
                index++;

            root.left = InternalDeserialize(str, ref index);
            root.right = InternalDeserialize(str, ref index);

            return root;
        }

        private static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if ((p == null && q != null) || (p != null && q == null))
                return false;

            if (p.val != q.val)
                return false;
            else
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}