using System.Collections.Generic;

namespace CsharpExam
{
    /// <summary>
    /// 判断是否为二叉搜索树  https://www.nowcoder.com/practice/a69242b39baf45dea217815c7dedb52b?tpId=295&tqId=2288088&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20230105_isValidBST
    {
        /*
         * 二叉搜索树：满足每个节点的左子树上的所有节点均小于当前节点且右子树上的所有节点均大于当前节点。
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

        public bool isValidBST(TreeNode root)
        {
            //若是二叉搜索树，则满足中序遍历一定为升序的

            List<int> inOrderValList = new List<int>();

            TreeNode node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (stack.Count > 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                inOrderValList.Add(node.val);

                node = node.right;
            }

            for (int i = 1; i < inOrderValList.Count; i++)
            {
                if (inOrderValList[i] < inOrderValList[i - 1])
                    return false;
            }

            return true;
        }
    }
}