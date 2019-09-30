# 树

- **结点**：包含数据元素及指向子树分支的点
	- 结点的度：结点拥有子树个数或者分支的个数
	- 结点的深度：从根结点到该结点路径上的结点个数
	- 结点的高度：从某结点开始向下延申路径最长的长度即为结点的高度
- **叶子结点**：又称终端结点，指度为0的结点
- **分支结点**：又称非终端结点，指度不为0的结点


- **树**：非线性结构
	- 树的度：树中各结点度的最大值
	- 树的高度(深度)：树中结点的最大层次
- **层次**： 从根开始，根为第1层，其孩子为第2层，依次类推


- **孩子**：结点的子树的根
- **双亲**：与孩子的定义相对应
- **兄弟**：同一双亲的孩子之间互为兄弟
- **祖先**：从根到某结点的路径上的所有结点，都是该结点的祖先
- **子孙**：以某结点为根的子树中的所有结点，都是该结点的子孙

## 二叉树的遍历算法

二叉树的遍历算法有：
- 先序遍历
- 中序遍历
- 后序遍历
- 层次遍历

```
/* 条件内3个不同位置访问根节点由此分为先、中、后序遍历 */
void order(BTNode *p)
{
    if(p!=NULL)
    {
        // Visit(p);   先序遍历
        preorder(p->lchild);
		// Visit(p);   中序遍历
        preorder(p->rchild);
		// Visit(p);   后序遍历
    }
}
```