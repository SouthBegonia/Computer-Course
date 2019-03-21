/*
程序功能：a，b为非递减顺序表，编写顺序表c将ab表归并升序排列，要求ab表内相同元素只保留一个
*/
#include<iostream>
using namespace std;
#define Maxsize 50

int Unions(int a[], int na, int b[], int nb, int c[], int &nc)
{
	int i=0;    //数组标记i,j
	int j=0;
	int k=0;    //归并顺序表标记
	
	if(na+nb>Maxsize)
		return -1;      //数组上溢
		
	while(i<na && j<nb)
	{
		if(a[i]<b[j])
		{
			if(k>0)         //对k为0时的处理，因为a，b表可能为空
			{
				if(c[k-1]!=a[i])    //过滤相同元素
					c[k++] = a[i++];
				else
					i++;
			}else
				c[k++] = a[i++];
		}else if(a[i]>b[j])
		{
			if(k>0)     //同上述处理
			{
				if(c[k-1]!=b[j])
					c[k++] = b[j++];
				else
					j++;
			}else
				c[k++] = b[j++];
		}
	}
	while(i<na)
	{
		if(k>0)
		{
			if(c[k-1]!=a[i])
				c[k++] = a[i++];
			else
				i++;
		}else
			c[k++] = a[i++];
	}

	while(j<nb)
	{
		if(k>0)
		{
			if(c[k-1]!=b[j])
				c[k++] = b[j++];
			else
				j++;
		}else
			c[k++] = b[j++];
	}
	
	nc = k;
	return nc;
}

int main()
{
	//function
	return 0;
}
