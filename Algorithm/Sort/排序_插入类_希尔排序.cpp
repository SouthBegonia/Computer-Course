/*
程序功能：希尔排序(缩小增量排序)
基本思路：
首先将序列按照 步长gap(增量,初始gap=length/2，后续gap=gap/2) 分割为多个子序列；
  本例中的{49,38,65,97,76,13,27,49,55,04} 按照gap=5分割为：
  子序列1：49             13
  子序列2：   38             27
  子序列3：      65             49
  子序列4：         97             55
  子序列5:             76             04
对这5个子序列进行直接插入排序，结果为：
  子序列1：13             49
  子序列2：   27             38
  子序列3：      49             65
  子序列4：         55             97
  子序列5:             04             76
同理按照gap=gap/2再次分割序列，再次对子序列进行直接插入排序；

最终唯一必须进行 gap=1的分割，进行一趟直接插入排序；
结果{04,13,27,38,49,49,55,65,76,97}

时间复杂度：
最坏情况：O(N^2)
最好情况：O(N)
平均：O(N^1.3)

空间复杂度：O(1)
*/
#include<iostream>
using namespace std;

void ShellSort(int R[], int n)
{
	int gap;            //分组的步长(增量)
	int i,j,k;
	int temp;           //交换中间值
	
	for(gap=n/2;gap>0;gap=gap/2)        //分割序列的循环(5 2 1)
		for(i=0;i<n;i++)
			for(j=i+gap;j<n;j=j+gap)
				if(R[j]<R[j-gap])       //若同组内序列非有序，则需插入
				{
					temp = R[j];
					k = j-gap;
					while(k>=0 && R[k]>temp)    //移动至合适位置插入过程
					{
						R[k+gap] = R[k];
						k = k-gap;
					}
					R[k+gap] = temp;
				}
}

int main()
{
	int arr[10] = {49,38,65,97,76,13,27,49,55,04};
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;

	ShellSort(arr,10);
	for(int i=0;i<10;i++)
		cout<<arr[i]<<" ";
	cout<<endl;
	return 0;
}

