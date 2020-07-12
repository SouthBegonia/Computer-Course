namespace Code057
{
    /// <summary>
    /// 057 二叉树的下一个节点
    /// </summary>
    class DataStructure_Tree_057
    {
        public class TreeLinkNode
        {
            public int val;
            public TreeLinkNode left;
            public TreeLinkNode right;
            public TreeLinkNode next;       //指向父结点
            public TreeLinkNode(int x)
            {
                val = x;
            }
        }

        //分析二叉树的下一个节点，一共有以下情况：
        //1.二叉树为空，则返回空；
        //2.节点右孩子存在，则设置一个指针从该节点的右孩子出发，一直沿着指向左子结点的指针找到的叶子节点即为下一个节点；
        //3.节点不是根节点。如果该节点是其父节点的左孩子，则返回父节点；否则继续向上遍历其父节点的父节点，重复之前的判断，返回结果。

        /// <summary>
        /// 057 二叉树的下一个结点
        /// </summary>
        /// <param name="pNode"></param>
        /// <returns></returns>
        public TreeLinkNode GetNext(TreeLinkNode pNode)
        {
            // 1.
            if (pNode == null)
                return null;

            // 2.
            if (pNode.right != null)
            {
                pNode = pNode.right;
                while (pNode.left != null)
                    pNode = pNode.left;
                return pNode;
            }

            // 3. 
            while (pNode.next != null)
            {
                TreeLinkNode pRoot = pNode.next;
                if (pRoot.left == pNode)
                    return pRoot;
                pNode = pNode.next;
            }
            return null;
        }
    }
}
