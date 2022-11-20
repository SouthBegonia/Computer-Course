using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 144 二叉树的前序遍历  https://leetcode.cn/problems/binary-tree-preorder-traversal/submissions/
    /// </summary>
    public class _20221117_PreorderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        /*public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);
            TreeNode node;
            while (stack.Count > 0)
            {
                node = stack.Pop();
                if (node != null)
                {
                    result.Add(node.val);
                    if (node.right != null)
                        stack.Push(node.right);
                    if (node.left != null)
                        stack.Push(node.left);
                }
            }

            return result;
        }*/

        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode curNode = root;

            while (stack.Count > 0 || curNode != null)
            {
                //根节点及左侧全部节点入栈
                while (curNode != null)
                {
                    result.Add(curNode.val);
                    stack.Push(curNode);
                    curNode = curNode.left;
                }

                //此节点的左子树遍历完毕，切换到右节点
                curNode = stack.Pop().right;
            }

            return result;
        }
    }
}