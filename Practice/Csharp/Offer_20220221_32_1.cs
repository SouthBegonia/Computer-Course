using System.Collections.Generic;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/cong-shang-dao-xia-da-yin-er-cha-shu-lcof/
    // 32_1 从上到下打印二叉树
    public class Offer_20220221_32_1
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

        public int[] LevelOrder(TreeNode root)
        {
            List<int> list = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }

            return list.ToArray();
        }
    }
}