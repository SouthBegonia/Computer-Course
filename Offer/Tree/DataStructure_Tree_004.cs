using System;
using System.Collections.Generic;
using System.Text;

namespace Code004
{
    /// <summary>
    /// 004 重建二叉树
    /// </summary>
    class DataStructure_Tree_004
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

        public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            TreeNode root = reConstructBinaryTree(pre, 0, pre.Length - 1, tin, 0, tin.Length - 1);
            return root;
        }

        /// <summary>
        /// 004 重建二叉树
        /// </summary>
        /// <param name="pre">前序遍历的数组</param>
        /// <param name="pBegin">前序遍历数组的前标记</param>
        /// <param name="pEnd">前序遍历数组的后标记</param>
        /// <param name="tin">中序遍历的数组</param>
        /// <param name="iBegin">中序遍历数组的前标记</param>
        /// <param name="iEnd">中序遍历数组的后标记</param>
        /// <returns>二叉树的根节点</returns>
        private TreeNode reConstructBinaryTree(int[] pre, int pBegin, int pEnd, int[] tin, int iBegin, int iEnd)
        {
            //1. 合法性检验：若前后标记相遇，说明已经重构完成，返回叶子null
            //   注意：相等说明还剩余一个结点；也例如pre、tin仅有一个元素的情况
            if ((pBegin > pEnd) || (iBegin > iEnd))
            {
                return null;
            }

            //2. 构建当前子树的根结点root（前序遍历特性：根结点最先遍历
            TreeNode root = new TreeNode(pre[pBegin]);

            //3.1 对照遍历
            for (int i = iBegin; i <= iEnd; i++)
            {
                //3.2 若在tin[]中找到root，说明可再细分子树（首个为1
                if (tin[i] == pre[pBegin])
                {
                    // 中序遍历特性：root前面的都为左子树{4,7,2}，后面的都为右子树{5,3,8,6}
                    //3.3 调整前后标记，分割数组，重构当前root的左右子树:
                    root.left = reConstructBinaryTree(pre, pBegin + 1, pBegin + i - iBegin, tin, iBegin, i - 1);
                    root.right = reConstructBinaryTree(pre, pBegin + i - iBegin + 1, pEnd, tin, i + 1, iEnd);
                    break;
                }
            }
            //4. 返回当前构建的根结点
            return root;
        }
    }
}
