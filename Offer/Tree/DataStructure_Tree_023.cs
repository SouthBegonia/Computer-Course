using System;
using System.Collections.Generic;
using System.Text;

namespace Code023
{
    /// <summary>
    /// 023 二叉搜索树的后序遍历序列
    /// </summary>
    class DataStructure_Tree_023
    {
        /// <summary>
        /// 023 二叉搜索树的后序遍历序列
        /// </summary>
        /// <param name="sequence">待检验是否为后序遍历的数组</param>
        /// <returns></returns>
        public bool VerifySquenceOfBST(int[] sequence)
        {
            // 1. 合法性检验：如果数组是空指针或者数组无元素，返回false
            if (sequence == null || sequence.Length < 1)
                return false;

            // 若合法，则检查是否满足后序遍历序列的条件
            return IsPostorder(sequence, 0, sequence.Length - 1);
        }

        /// <summary>
        /// 检测数组是否满足后序遍历的条件
        /// </summary>
        /// <param name="sequence">待检验数组</param>
        /// <param name="start">数组头元素</param>
        /// <param name="end">数组尾元素</param>
        /// <returns></returns>
        private bool IsPostorder(int[] sequence, int start, int end)
        {
            // 2.1 储存当前的根节点
            //     后序遍历特性：末尾节点为根结点
            int root = sequence[end];

            // 2.2 从start位置开始检索，直到遇到比根节点大的节点，在此节点之前的所有节点为该根节点的左子树
            int i = start;
            for (; i < end - 1; i++)
            {
                if (sequence[i] > root)
                    break;
            }

            // 3.1 从i（比根节点大的第一个数字）开始检索，是否存在小于根节点的节点。如果有，说明不是搜索二叉树
            int j = i;
            for (; j < end - 1; j++)
            {
                if (sequence[j] < root)
                    return false;
            }

            // 3.2 检查节点的左子树是否为二叉搜索树
            bool left = true;
            if (i > 0)
                left = IsPostorder(sequence, 0, i - 1);

            // 3.3 检查节点的右子树是否为二叉树搜索树
            bool right = true;
            if (i < end - 1)
                right = IsPostorder(sequence, i, end - 1);


            //4. 如果该节点的左右子树都是搜索二叉树，返回true，否则返回false
            return left && right;
        }
    }
}