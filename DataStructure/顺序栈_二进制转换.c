/*
程序功能：十进制整数N转换成二进制格式打印
基本思路：Basetrans()函数转换成二进制有效数值，再由sprintf()格式化输出到字符串打印
int sprintf(char *str, const char *format, ...) 发送格式化输出到 str 所指向的字符串
详见：http://www.runoob.com/cprogramming/c-function-sprintf.html
*/
#include<stdio.h>
#define Maxsize 50

/*进制转换：将十进制整数 n 转换为二进制整数 result*/
int Basetrans(int n)
{
	int i,result = 0;
	int stack[Maxsize],top=-1;

	while(n!=0)
	{
		i = n%2;
		n = n/2;
		stack[++top] = i;
	}

	while(top!=-1)
	{
		i = stack[top];
		--top;
		result = result*10 +i;
	}
	return result;
}

int main()
{
	int num = 0;    //十进制带转换数字
	int ans = 0;    //二进制整数结果
	char str[Maxsize] = ""; //二进制补齐字符串

	printf("num = ");
	scanf("%d",&num);
	getchar();
	while(num>=0)
	{
		ans = Basetrans(num);
		sprintf(str, "%08d", ans);  //将ans补齐8位的格式化输出发送到 str， 0即为补齐
		printf("%s\n\n",str);   //打印补齐后的字符串

		printf("num = ");
		scanf("%d",&num);
		getchar();
	}
	printf("Done!");

	getchar();
	return 0;
}

