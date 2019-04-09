/*
�����ܣ�ϡ��������ʽ���淽��-ʮ�������ʾ
����˼·��
*/
#include<iostream>
#include<stdlib.h>
#define Maxsize 4
using namespace std;

/*��ͨ���*/
typedef struct OLNode{
	int row,col;        //�кź��к�
	struct OLNode *right, *down;    //ָ���ұߺ��·�����ָ��
	float val;
}OLNode;

/*ͷ���*/
typedef struct{
	OLNode *rhead, *chead;  //ָ����ͷ��������ָ��
	int m,n,k;      //��������������0�������
}CrossList;

/*����ʮ����*/
int CreateCrossListmat(float A[][Maxsize], int m,int n, int k, CrossList &M)
{
	if(M.rhead)
		free(M.rhead);
	if(M.chead)
		free(M.chead);
	M.m = m;
	M.n = n;
	M.k = k;

	if(!(M.chead=(OLNode *)malloc(sizeof(OLNode)*m)))   //����ͷ�������ռ�
		return 0;
	if(!(M.rhead=(OLNode *)malloc(sizeof(OLNode)*m)))
		return 0;

	for(int i=0;i<m;i++){       //ͷ�������right��down�ÿ�
		M.chead[i].right = NULL;
		M.chead[i].down = NULL;
	}
	for(int i=0;i<n;i++){
		M.rhead[i].right = NULL;
		M.chead[i].down = NULL;
	}

	OLNode *temp_c[Maxsize];    //����������ĸ���ָ������
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

