/*二叉树结点构造*/
typedef struct BTNode
{
    char data;
    struct BTNode *lchild;
    struct BTNode *rchild;
}BTNode;

/*访问根结点*/
void Visit(BTNode *p)
{
}

/*先序遍历*/
void preorder(BTNode *p)
{
    if(p!=NULL)
    {
        Visit(p);
        preorder(p->lchild);
        preorder(p->rchild);
    }
}

/*中序遍历*/
void inorder(BTNode *p)
{
    if(p!=NULL)
    {
        inorder(p->lchild);
        Visit(p);
        inorder(p->rchild);
    }
}

/*后序遍历*/
void postorder(BTNode *p)
{
    if(p!=NULL)
    {
        postorder(p->lchild);
        postorder(p->rchild);
        Visit(p);
    }
}
