/*
程序功能：稀疏矩阵的链式储存方法-十字链表表示
基本思路：
*/
#include<iostream>
#include<stdlib.h>
#define Maxsize 4
using namespace std;

/*普通结点*/
typedef struct OLNode{
	int row,col;        //行号和列号
	struct OLNode *right, *down;    //指向右边和下方结点的指针
	float val;
}OLNode;

/*头结点*/
typedef struct{
	OLNode *rhead, *chead;  //指向两头结点数组的指针
	int m,n,k;      //矩阵行列数及非0结点总数
}CrossList;

/*创建十字链*/
int CreateCrossListmat(float A[][Maxsize], int m,int n, int k, CrossList &M)
{
	if(M.rhead)
		free(M.rhead);
	if(M.chead)
		free(M.chead);
	M.m = m;
	M.n = n;
	M.k = k;

	if(!(M.chead=(OLNode *)malloc(sizeof(OLNode)*m)))   //申请头结点数组空间
		return 0;
	if(!(M.rhead=(OLNode *)malloc(sizeof(OLNode)*m)))
		return 0;

	for(int i=0;i<m;i++){       //头结点数组right和down置空
		M.chead[i].right = NULL;
		M.chead[i].down = NULL;
	}
	for(int i=0;i<n;i++){
		M.rhead[i].right = NULL;
		M.chead[i].down = NULL;
	}

	OLNode *temp_c[Maxsize];    //建立列链表的辅助指针数组
	for(int i=0;i<m;i++)
		temp_c[i] = &(M.rhead[i]);

	for(int i=0;i<m;i++){
		OLNode *r = &(M.chead[i]);
		for(int j=0;j<n;j++){
			if(A[i][j]!=0){
				OLNode *p = (OLNode *)malloc(sizeof(OLNode));
				p->row = i;
				p->col = j;
				p->val = A[i][j];
				p->down = NULL;
				p->right = NULL;
				r->right = p;
				r = p;
				temp_c[j]->down = p;
				temp_c[j] = p;
			}
		}
	}
	return 1;
}

int main()
{
	CrossList M;
	float A[4][4] ={
		{0,0,0,1},
		{0,0,3,2},
		{1,0,0,0},
		{0,2,0,0}};
	CreateCrossListmat(A,4,4,5,M);
	free(M.rhead);
	free(M.chead);
	
	return 0;
}

