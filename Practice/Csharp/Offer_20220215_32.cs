using System.Collections.Generic;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/cong-shang-dao-xia-da-yin-er-cha-shu-ii-lcof/
    // 32 从上到下打印二叉树
    public class Offer_20220215_32
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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> nodeValList = new List<int>();

                for (int i = queue.Count; i > 0; i--)    //精华
                {
                    TreeNode node = queue.Dequeue();
                    nodeValList.Add(node.val);

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(nodeValList);
            }

            return result;
        }
    }
}