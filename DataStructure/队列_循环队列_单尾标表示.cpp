/*
�����ܣ������齨��ѭ�����У�ʵ�ֳ���ӣ�����βָ��Ͷ��г��ȱ��
����˼·��˳ʱ����ӣ�����βָ�� rear ˳ʱ��仯��ÿ������޸�rear�����г���length��
������ʱ������Ԫ�ؼ�Ϊ (rear-length+Maxsize)%Maxsize;
����ö���front��βrear�ı�ʾ�������ڲ��
*/
#include<isotream>
#define Maxsize 20
using namespace std;

typedef struct{
	int elems[Maxsize]; //���е�����
	int rear;   //��βָ�룬ָ��������ӵ�Ԫ��
	int length; //���еĳ���
}SqQueue;

/*��ӣ���Ԫ�� x ���*/
int EnQueue(SqQueue &q,int x)
{
	if(q.length==Maxsize)
		return 0;
	q.rear = (q.rear+1)%Maxsize;    //��βָ��ǰ�ƣ�
	e.elem[q.rear] = x;     //���
	++q.length;     //���г���+1
	return 1;
}

/*���ӣ�����Ԫ���� x ����*/
int DeQueue(SqQueue &q,int &x)
{
	if(q.length==0)
		return 0;

	x = q.elems[(q.rear-q.length+Maxsize)%Maxsize];   //��rear=4��len=2�������Ϊ 2
	--q.length;     //���г���-1
	return 1;
}

int main()
{
	return 0;
}
