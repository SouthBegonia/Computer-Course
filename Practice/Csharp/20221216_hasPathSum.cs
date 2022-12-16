namespace CsharpExam
{
    /// <summary>
    /// 二叉树中和为某一值的路径  https://www.nowcoder.com/practice/508378c0823c423baa723ce448cbfd0c?tpId=295&tqId=634&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221216_hasPathSum
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

        public bool hasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            return DFS(root, sum);
        }

        public bool DFS(TreeNode node, int target)
        {
            if (node == null)
                return false;

            //扣除当前节点值的
            target -= node.val;

            //查验当前节点是否符合
            if (target == 0)
            {
                //叶子节点 且 最终等于sum值，符合
                if (node.left == null && node.right == null)
                    return true;

                //注意：节点值可能为负数，因此不可忽略直接忽略子树部分
                //else
                //    return false;
            }

            //否则回溯深度遍历此节点的左右分支
            return DFS(node.left, target) || DFS(node.right, target);
        }
    }
}