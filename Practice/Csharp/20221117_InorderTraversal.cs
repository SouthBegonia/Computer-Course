﻿using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 94 二叉树的中序遍历  https://leetcode.cn/problems/binary-tree-inorder-traversal/
    /// </summary>
    public class _20221117_InorderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        /*public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            DFS(result, root);
            return result;
        }

        private void DFS(IList<int> result, TreeNode node)
        {
            if (node == null)
                return;

            DFS(result, node.left);
            result.Add(node.val);
            DFS(result, node.right);
        }*/

        /*
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode node;
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    node = stack.Pop();
                    result.Add(node.val);
                    root = node.right;
                }
            }

            return result;
        }
        */

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode curNode = root;

            while (stack.Count > 0 || curNode != null)
            {
                //根节点及左侧全部节点入栈
                while (curNode != null)
                {
                    stack.Push(curNode);
                    curNode = curNode.left;
                }

                //此节点的左子树遍历完毕，弹出记录，切换到右节点
                TreeNode temp = stack.Pop();
                result.Add(temp.val);
                curNode = temp.right;
            }

            return result;
        }
    }
}