using System;
using System.Collections.Generic;
using System.Text;

namespace Code017
{
    /// <summary>
    /// 017 树的子结构
    /// </summary>
    class DataStructure_Tree_017
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
        /// 017 树的子结构
        /// </summary>
        /// <param name="pRoot1">目标二叉树 A</param>
        /// <param name="pRoot2">待检验二叉树 B</param>
        /// <returns></returns>
        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            bool result = false;

            // 1. 合法性检验：两树非空才可进行检验
            if (pRoot1 != null && pRoot2 != null)
            {
                // 2.1 如果A中root与B的root一致，则进行 剩余子树判断
                if (pRoot1.val == pRoot2.val)
                    result = Tree1HasTree2(pRoot1, pRoot2);

                // 2.2 如果找不到，则把root的左儿子当作起点，去判断时候包含B
                if (!result)
                    result = HasSubtree(pRoot1.left, pRoot2);

                // 2.3 如果还找不到，则把root的右儿子当作起点，去判断时候包含B
                if (!result)
                    result = HasSubtree(pRoot1.right, pRoot2);
            }

            // 3. 返回结果：true/false
            return result;
        }

        /// <summary>
        /// 剩余子树判断：判断A子树中是否包含B子树
        /// </summary>
        /// <param name="pRoot1">目标二叉树 A</param>
        /// <param name="pRoot2">待检验二叉树 B</param>
        /// <returns></returns>
        public bool Tree1HasTree2(TreeNode pRoot1, TreeNode pRoot2)
        {
            // 如果 B 已经遍历完了，说明都能对应的上。返回true
            if (pRoot2 == null)
                return true;
            // 如果 B 还没有遍历完，A 却遍历完了。返回false
            if (pRoot1 == null)
                return false;
            // 如果其中有一个节点没有对应上，返回false
            if (pRoot1.val != pRoot2.val)
                return false;


            // 如果当前root节点对应的上，再分别去左右子节点里面匹配
            return Tree1HasTree2(pRoot1.left, pRoot2.left) && Tree1HasTree2(pRoot1.right, pRoot2.right);
        }
    }
}