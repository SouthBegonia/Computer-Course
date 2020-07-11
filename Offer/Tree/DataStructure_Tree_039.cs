using System;

namespace Code039
{
    /// <summary>
    /// 039 平衡二叉树
    /// </summary>
    class DataStructure_Tree_039
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

        // 平衡二叉树的左右子树也是平衡二叉树，那么所谓平衡就是左右子树的高度差不超过1

        /// <summary>
        /// 039 平衡二叉树
        /// </summary>
        /// <param name="pRoot"></param>
        /// <returns></returns>
        public bool IsBalanced_Solution(TreeNode pRoot)
        {
            return GetDepth(pRoot) != -1;
        }

        public int GetDepth(TreeNode root)
        {
            // 空树也为平衡树
            if (root == null)
                return 0;

            // 判断左右子树是否平衡
            int left = GetDepth(root.left);
            if (left == -1)
                return -1;

            int right = GetDepth(root.right);
            if (right == -1)
                return -1;

            // 如果左右子树的高度差大于1则不是平衡树
            //   否则返回当前子树的最大高度
            if (Math.Abs(left - right) > 1)
                return -1;
            else
                return 1 + Math.Max(left, right);
        }
    }
}