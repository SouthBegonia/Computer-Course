namespace CsharpExam
{
    /// <summary>
    /// 二叉树的镜像  https://www.nowcoder.com/practice/a9d0ecbacef9410ca97463e4a5c83be7?tpId=295&tqId=1374963&ru=/exam/oj&qru=/ta/format-top101/question-ranking&sourceUrl=%2Fexam%2Foj
    /// </summary>
    public class _20221228_TreeMirror
    {
        public TreeNode Mirror (TreeNode pRoot)
        {
            if (pRoot == null)
                return pRoot;

            TreeNode tempLeft = pRoot.left;
            pRoot.left = pRoot.right;
            pRoot.right = tempLeft;

            Mirror(pRoot.left);
            Mirror(pRoot.right);
            return pRoot;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode (int x)
            {
                val = x;
            }
        }
    }
}