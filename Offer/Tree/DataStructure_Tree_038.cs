using System;
using System.Collections.Generic;
using System.Text;

namespace Code038
{
    /// <summary>
    /// 038 二叉树的深度
    /// </summary>
    class DataStructure_Tree_038
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
        /// 038 二叉树的深度
        /// </summary>
        /// <param name="pRoot"></param>
        /// <returns></returns>
        public int TreeDepth(TreeNode pRoot)
        {
            // 若当前节点为空，返回
            if (pRoot == null)
                return 0;

            // 若不为空，求得其左右子树的深度
            int left = TreeDepth(pRoot.left);
            int right = TreeDepth(pRoot.right);

            // 返回当前子树的最大深度
            return Math.Max(left, right) + 1;
        }
    }
}
