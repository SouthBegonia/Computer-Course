using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 104 二叉树的层序遍历  https://leetcode.cn/problems/binary-tree-level-order-traversal/
    /// </summary>
    public class _20221121_LevelOrder
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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> curOrderList = new List<int>(count);
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    curOrderList.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                result.Add(curOrderList);
            }

            return result;
        }
    }
}