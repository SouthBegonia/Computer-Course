using System;
using System.Collections.Generic;
using System.Text;

namespace Code018
{
    /// <summary>
    /// 018 二叉树的镜像
    /// </summary>
    class DataStructure_Tree_018
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
        /// 018 二叉树的镜像
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode Mirror(TreeNode root)
        {
            // 1. 合法性检验，源二叉树root必须非空
            if (root == null)
                return root;

            // 2. 遍历root的左右子树，最终取得左右子树的引用
            TreeNode r = Mirror(root.left);
            TreeNode l = Mirror(root.right);

            //3. 修改root的 左右子树的引用，实现左右节点交换
            root.left = l;
            root.right = r;

            return root;
        }
    }
}