#include<bits/stdc++.h>
using namespace std;

int main()
{
	int T;
	long long n,m;
	long long black,white;
	long long a,b,c,d,e;
	long long x[8],y[8];
	
	scanf("%d",&T);
	
	while(T--)
	{
		scanf("%lld%lld",&n,&m);

		black = n*m / 2;
		white = n*m - black;
		
		for(int i=0;i<=3;i++)
			scanf("%lld%lld",&x[i],&y[i]);
			
		if((x[0]+y[0]) & 1)
			d = ((x[1]-x[0]+1) * (y[1]-y[0]+1)+1) / 2;
		else
			d = (x[1]-x[0]+1) * (y[1]-y[0]+1) / 2;
			
		white += d; black -=d;
		
		if((x[2]+y[2]) & 1)
			d = (x[3]-x[2]+1) * (y[3]-y[2]+1) / 2;
		else
			d = ((x[3]-x[2]+1) * (y[3]-y[2]+1)+1) / 2;
			
		white -=d; black+=d;
		
		a = max(x[0],x[2]);
		b = max(y[0],y[2]);
		c = min(x[1],x[3]);
		d = min(y[1],y[3]);
		
		if(c<a || d<b)
			e = 0LL;
		else
		{
			if((a+b) & 1)
				e = ((c-a+1) * (d-b+1)+1) / 2;
			else
				e = (c-a+1) * (d-b+1) / 2;
		}
		
		white -= e; black+=e;
		printf("%lld %lld\n",white,black);
	}
	

	while(1){
		if(getchar()=='q')
		break;
	}

	return 0;
}
