/*
�����ܣ�ʮ��������Nת���ɶ����Ƹ�ʽ��ӡ
����˼·��Basetrans()����ת���ɶ�������Ч��ֵ������sprintf()��ʽ��������ַ�����ӡ
int sprintf(char *str, const char *format, ...) ���͸�ʽ������� str ��ָ����ַ���
�����http://www.runoob.com/cprogramming/c-function-sprintf.html
*/
#include<stdio.h>
#define Maxsize 50

/*����ת������ʮ�������� n ת��Ϊ���������� result*/
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
	int num = 0;    //ʮ���ƴ�ת������
	int ans = 0;    //�������������
	char str[Maxsize] = ""; //�����Ʋ����ַ���

	printf("num = ");
	scanf("%d",&num);
	getchar();
	while(num>=0)
	{
		ans = Basetrans(num);
		sprintf(str, "%08d", ans);  //��ans����8λ�ĸ�ʽ��������͵� str�� 0��Ϊ����
		printf("%s\n\n",str);   //��ӡ�������ַ���

		printf("num = ");
		scanf("%d",&num);
		getchar();
	}
	printf("Done!");

	getchar();
	return 0;
}

