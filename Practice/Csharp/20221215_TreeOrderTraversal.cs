using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 二叉树的遍历
    /// </summary>
    public class _20221215_TreeOrderTraversal
    {
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

        #region 前序排列

        public static List<int> preorderTraversal(TreeNode root)
        {
            if (root == null)
                return null;

            List<int> ret = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode temp = stack.Pop();

                ret.Add(temp.val);

                if (temp.right != null)
                    stack.Push(temp.right);
                if (temp.left != null)
                    stack.Push(temp.left);
            }

            return ret;
        }

        #endregion

        #region 中序遍历

        public static List<int> inorderTraversal(TreeNode root)
        {
            if (root == null)
                return null;

            List<int> ret = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode indexNode = root;
            while (stack.Count > 0 || indexNode != null)
            {
                while (indexNode != null)
                {
                    stack.Push(indexNode);
                    indexNode = indexNode.left;
                }

                indexNode = stack.Pop();
                ret.Add(indexNode.val);

                indexNode = indexNode.right;
            }

            return ret;
        }

        #endregion

        #region 后序遍历

        public static List<int> postorderTraversal(TreeNode root)
        {
            if (root == null)
                return null;

            List<int> ret = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode temp = stack.Pop();

                ret.Add(temp.val);

                if (temp.left != null)
                    stack.Push(temp.left);
                if (temp.right != null)
                    stack.Push(temp.right);
            }

            ret.Reverse();
            return ret;
        }

        #endregion

        #region 层序遍历

        public List<List<int>> levelOrder(TreeNode root)
        {
            List<List<int>> ret = new List<List<int>>();

            if (root == null)
                return ret;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> curRowRet = new List<int>(count);
                for (int i = 0; i < count; i++)
                {
                    TreeNode temp = queue.Dequeue();
                    curRowRet.Add(temp.val);

                    if (temp.left != null)
                        queue.Enqueue(temp.left);
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }

                ret.Add(curRowRet);
            }

            return ret;
        }

        #endregion
    }
}