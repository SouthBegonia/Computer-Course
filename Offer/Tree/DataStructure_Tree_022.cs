using System.Collections.Generic;

namespace Code022
{
    /// <summary>
    /// 022 从上往下打印二叉树
    /// </summary>
    class DataStructure_Tree_022
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
        /// 022 从上往下打印二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> PrintFromTopToBottom(TreeNode root)
        {
            // 1.1 存储打印结果的表
            List<int> resultList = new List<int>();

            // 1.2 节点的队列：用于将BFS、从左向右遍历的结点入队
            List<TreeNode> allNodes = new List<TreeNode>();
            int i = 0;

            // 2. 二叉树根节点入队
            if (root != null)
                allNodes.Add(root);

            // 如果当前表还没遍历完
            while (i < allNodes.Count)
            {
                // 3.1 把当前遍历的节点 从队列中入表
                TreeNode curNode = allNodes[i];
                resultList.Add(curNode.val);

                // 3.2 如果当前节点存在左孩子，将其入队
                if (curNode.left != null)
                    allNodes.Add(curNode.left);

                // 3.3 如果当前节点存在右孩子，也将其入队
                if (curNode.right != null)
                    allNodes.Add(curNode.right);

                i++;
            }
            return resultList;
        }
    }
}