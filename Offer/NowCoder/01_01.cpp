#include<bits/stdc++.h>
using namespace std;

int main()
{
	int p[10005];       //�����i������ʱ�䣬���ҵ����i��ķ�ʽ����
	int t[10005];       //�����i������ʱ�䣬���ҵ����i��ķ�ʽ����
	int n,m,x;

	cin>>n;
	for(int i=1;i<=n;i++)
	{
		cin>>x;
		
		//����Ҫ��ʱ
		p[i] = min(p[i-1],t[i-1]) + x;
		
		//��һ�㲻������
		if(i==1)
			continue;
			
		//������ʱ
		t[i] = min(p[i-1],p[i-2]);
		
		printf("p[%d] = %d, t[%d] = %d\n",i,p[i],i,t[i]);
		/*
		IN >> 5   3 5 1 8 4
		p[1] = 3, t[1] = 0  
		p[2] = 5, t[2] = 0
		p[3] = 1, t[3] = 3
		p[4] = 9, t[4] = 1
		p[5] = 5, t[5] = 1
		OUT << 1 ��2��1��2
		*/
	}
	cout<<min(p[n],t[n])<<endl;
	
	while(1){
		if(getchar()=='q')
		break;
	}
	
	return 0;
}
