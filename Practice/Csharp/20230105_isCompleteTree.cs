using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 判断是否为完全二叉树  https://www.nowcoder.com/practice/8daa4dff9e36409abba2adbe413d6fae?tpId=295&tqId=2299105&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20230105_isCompleteTree
    {
        /*
         * 完全二叉树：若二叉树的深度为 h，除第 h 层外，其它各层的结点数都达到最大个数，第 h 层所有的叶子结点都连续集中在最左边，这就是完全二叉树
         */

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

        public bool isCompleteTree(TreeNode root)
        {
            //空树也为完全二叉树
            if (root == null)
                return true;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            bool emptyNodeTag = false;
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node == null)
                {
                    //记录首次遇到空节点，说明到了最下叶子层，且其后不应当再出现叶子节点
                    emptyNodeTag = true;
                    continue;
                }

                if (emptyNodeTag)
                    return false;

                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return true;
        }
    }
}