using System.Collections.Generic;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/cong-shang-dao-xia-da-yin-er-cha-shu-iii-lcof/
    // 32_3 从上到下打印二叉树
    public class Offer_20220222_32_3
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
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<IList<int>> result = new List<IList<int>>();

            if (root != null)
                queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IList<int> list = new List<int>();
                for (int i = queue.Count; i > 0; i--)
                {
                    TreeNode node = queue.Dequeue();

                    if (result.Count % 2 != 0)
                        list.Insert(0, node.val); //逆序插入
                    else
                        list.Add(node.val);                  //顺序插入

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                result.Add(list);
            }

            return result;
        }
    }
}