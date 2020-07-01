using System.Collections.Generic;

namespace Code026
{
    /// <summary>
    /// 026 二叉搜索树与双向链表
    /// </summary>
    class DataStructure_Tree_026
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

        /// <summary>
        /// 026 二叉搜索树与双向链表
        /// </summary>
        /// <param name="pRootOfTree"></param>
        /// <returns></returns>
        public TreeNode Convert(TreeNode pRootOfTree)
        {
            if (pRootOfTree == null)
                return null;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = pRootOfTree, pre = null;
            bool isHead = true;

            while (cur != null || stack.Count != 0)
            {
                // 遍历到某分支的叶子节点
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();

                if (isHead)
                {
                    // 首次遍历到双向链表头节点
                    pRootOfTree = cur;
                    pre = cur;
                    isHead = false;
                }
                else
                {
                    // 调整节点的指向
                    pre.right = cur;
                    cur.left = pre;
                    pre = cur;
                }
                cur = cur.right;
            }

            return pRootOfTree;
        }
    }
}