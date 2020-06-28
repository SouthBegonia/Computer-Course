using System.Collections.Generic;

namespace Code024
{
    /// <summary>
    /// 024 二叉树中和为某一值的路径
    /// </summary>
    class DataStructure_Tree_024
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

        // 结果路径表：全部 和为某值 的路径
        List<List<int>> pathList = new List<List<int>>();
        // 当前路径表：记录当前遍历的路径
        List<int> path = new List<int>();

        /// <summary>
        /// 024 二叉树中和为某一值的路径
        /// </summary>
        /// <param name="root">根节点</param>
        /// <param name="expectNumber">目标整数</param>
        /// <returns></returns>
        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            // 1. 合法性检测
            if (root == null)
                return pathList;

            // 2. 记入根节点
            path.Add(root.val);
            expectNumber -= root.val;

            // 3.1 当某路径上的所有值的和 等于 目标值（注意：必须抵达叶子节点
            //     说明该路径即为所求，当前路径表入结果路径表
            if (expectNumber == 0 && root.left == null && root.right == null)
                pathList.Add(new List<int>(path));

            // 3.2 否则遍历其左右子树
            FindPath(root.left, expectNumber);
            FindPath(root.right, expectNumber);

            // 4. DFS遍历一个分支后，回退一层
            path.RemoveAt(path.Count - 1);

            // 5. 返回结果的表
            return pathList;

            // 示例：expectNumber = 6
            //         1
            //       /   \
            //      2     3
            //    /  \   /  \
            //   2   3  2    4
            //  /
            // 1
            //
            // DFS先遍历完 1-2-2-1，后回退2次到第二层，遍历1-2-3
            // 同理，后遍历1-3-2，1-3-4
            // 所谓遍历的过程，实质是path表的增减
        }
    }
}
