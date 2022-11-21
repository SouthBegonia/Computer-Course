using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 145 二叉树的后序遍历  https://leetcode.cn/problems/binary-tree-postorder-traversal/submissions/
    /// </summary>
    public class _20221120_PostorderTraversal
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

        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode curNode = root;

            while (stack.Count > 0 || curNode != null)
            {
                //根节点及右侧全部节点入栈
                while (curNode != null)
                {
                    result.Add(curNode.val);
                    stack.Push(curNode);
                    curNode = curNode.right;
                }

                //此节点的右边子树遍历完毕，切换到左节点
                curNode = stack.Pop().left;
            }

            //结果由 根右左 反转为 左右根（后序遍历）
            result.Reverse(0, result.Count);

            return result;
        }
    }
}