using System.Collections.Generic;

namespace Code058
{
    /// <summary>
    /// 058 对称的二叉树
    /// </summary>
    class DataStructure_Tree_058
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

        // 递归方法
        public bool isSymmetrical(TreeNode pRoot)
        {
            if (pRoot == null)
                return true;
            return isSymmetrical(pRoot.left, pRoot.right);
        }


        private bool isSymmetrical(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            // 为镜像的条件：左右节点值相等,且对称的子树也是镜像
            return left.val == right.val
                    && isSymmetrical(left.left, right.right)
                    && isSymmetrical(left.right, right.left);
        }

        // 非递归方法 DFS
        private bool isSymmetricalDFS(TreeNode pRoot)
        {
            if (pRoot == null) return true;

            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(pRoot.left);
            s.Push(pRoot.right);

            while (s.Count != 0)
            {
                // 成对取出
                TreeNode right = s.Pop();
                TreeNode left = s.Pop();

                if (left == null && right == null) continue;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;

                // 成对插入
                s.Push(left.left);
                s.Push(right.right);
                s.Push(left.right);
                s.Push(right.left);
            }
            return true;
        }

        // 非递归方法 BFS
        private bool isSymmetricalBFS(TreeNode pRoot)
        {
            if (pRoot == null) return true;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(pRoot.left);
            q.Enqueue(pRoot.right);

            while (q.Count != 0)
            {
                // 成对取出
                TreeNode left = q.Dequeue();
                TreeNode right = q.Dequeue();

                if (left == null && right == null) continue;
                if (left == null || right == null) return false;
                if (left.val != right.val) return false;

                // 成对插入
                q.Enqueue(left.left);
                q.Enqueue(right.right);
                q.Enqueue(left.right);
                q.Enqueue(right.left);
            }
            return true;
        }
    }
}
