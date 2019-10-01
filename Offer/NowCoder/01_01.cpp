#include<bits/stdc++.h>
using namespace std;

int main()
{
	int p[10005];       //到达第i层的最短时间，并且到达第i层的方式是爬
	int t[10005];       //到达第i层的最短时间，并且到达第i层的方式是跳
	int n,m,x;

	cin>>n;
	for(int i=1;i<=n;i++)
	{
		cin>>x;
		
		//爬需要用时
		p[i] = min(p[i-1],t[i-1]) + x;
		
		//第一层不可以跳
		if(i==1)
			continue;
			
		//跳不用时
		t[i] = min(p[i-1],p[i-2]);
		
		printf("p[%d] = %d, t[%d] = %d\n",i,p[i],i,t[i]);
		/*
		IN >> 5   3 5 1 8 4
		p[1] = 3, t[1] = 0  
		p[2] = 5, t[2] = 0
		p[3] = 1, t[3] = 3
		p[4] = 9, t[4] = 1
		p[5] = 5, t[5] = 1
		OUT << 1 跳2爬1跳2
		*/
	}
	cout<<min(p[n],t[n])<<endl;
	
	while(1){
		if(getchar()=='q')
		break;
	}
	
	return 0;
}
