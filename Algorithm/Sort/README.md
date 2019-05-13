# 排序算法

动画过程参考：[一像素 —— 十大经典排序算法](https://www.cnblogs.com/onepixel/articles/7674659.html)

* [1. 插入类排序](#1)
  * [1.1 直接插入排序](#1.1)
  * [1.2 折半插入排序](#1.2)
  * [1.3 希尔排序](#1.3)
* [2. 交换类排序](#2)
  * [2.1 冒泡排序](#2.1)
  * [2.2 快速排序](#2.2)

----------------

<h2 id="1">1. 插入类排序</h2>

- 插入类排序核心：在已经有序的序列中插入新的关键字。
- 默认都为升序排序

<h3 id="1.1">1.1 直接插入排序</h3>

1. 假定数组 arr 首位元素 arr[0] 为有序序列；
2. 把从2号元素 i=2 开始，逐一作为新的待插入关键字 temp，将 temp 与有序序列 **从后往前** 逐一比较，将大于 temp 的元素后移，最后找到合适位置后即插入 temp 元素，有序序列长度增加；
3. 对所有元素进行这种比较、移动，最终实现排序。

```
for(i = 1;i < n;i++)
{
	temp = arr[i];
	j = i-1;
	
	while(j>=0 && temp<arr[j])
	{
		arr[j+1] = arr[j];
		--j;
	}
	arr[j+1] = temp;
}
```
- [直接插入排序](https://github.com/SouthBegonia/Computer-Course/blob/master/Algorithm/Sort/%E6%8E%92%E5%BA%8F_%E6%8F%92%E5%85%A5%E7%B1%BB_%E7%9B%B4%E6%8E%A5%E6%8F%92%E5%85%A5%E6%8E%92%E5%BA%8F.cpp)

<h3 id="1.2">1.2 折半插入排序</h3>

1. 已知一个有序序列，例如 {1,4,8,10,15,20}，设左右端值 low 和 high ，待插入的关键字为 arr[i] ；
2. 每次选取一个**中间值 m=(low+high)/2** ，与关键字进行**比较**，若 arr[m]>arr[i] 说明关键字小于 m 的右半部分，那么修改右端值 high=m-1 (同理小于则修改low=m+1)；
3. 重复选取中间值比较的过程，直至 **low>high** ，待插入位置即为 **high+1** ;
4. 经过对所有元素的比较、归位，最终实现排序。

```
for(i=1;i<n;i++)
{
	x = arr[i];
	low = 0;
	high = i-1;     //已排序列 [0~i-1]

	while(low<=high)
	{
		m = (low+high)/2;	//折半

		if(x>arr[m])		//修改左或右端值
			low = m+1;
		else
			high = m-1;
	}
	for(j=i-1;j>high;j--) 	//移动数组留出待插位置
		arr[j+1] = arr[j];
	arr[j+1] = x;
}
```
- [折半插入](https://github.com/SouthBegonia/Computer-Course/blob/master/Algorithm/Sort/%E6%8E%92%E5%BA%8F_%E6%8F%92%E5%85%A5%E7%B1%BB_%E6%8A%98%E5%8D%8A%E6%8F%92%E5%85%A5%E6%8E%92%E5%BA%8F.cpp)

<h3 id="1.3">1.3 希尔排序</h3>
参考：[lchad - 希尔排序C语言实现](https://blog.csdn.net/lchad/article/details/43564001)

1. 将序列按照 **步长gap**(增量,初始 gap=length/2，后续 gap=gap/2) 分割为多个子序列,例如本例中的{49,38,65,97,76,13,27,49,55,04} 按照 gap=5 分割为：

```
子序列1：49             13
子序列2：   38             27
子序列3：      65             49
子序列4：         97             55
子序列5:             76             04
```

2. 对这5个子序列进行直接插入排序，结果为：

```
子序列1：13             49
子序列2：   27             38
子序列3：      49             65
子序列4：         55             97
子序列5:             04             76
```

3. 同理按照 **gap=gap/2** 再次**分割序列**，再次对子序列进行直接插入排序；
4. 最终唯一**必须进行 gap=1 的分割**，进行一趟直接插入排序完成操作。

```
for(gap=n/2;gap>0;gap=gap/2)      //分割序列
	for(i=0;i<n;i++)
		for(j=i+gap;j<n;j=j+gap)
			if(arr[j]<arr[j-gap])     //若同组内序列非有序，则需插入
			{
				temp = arr[j];
				k = j-gap;
				while(k>=0 && arr[k]>temp)  //移动至合适位置插入过程
				{
					arr[k+gap] = arr[k];
					k = k-gap;
				}
				arr[k+gap] = temp;
			}

```
- [希尔排序](https://github.com/SouthBegonia/Computer-Course/blob/master/Algorithm/Sort/%E6%8E%92%E5%BA%8F_%E6%8F%92%E5%85%A5%E7%B1%BB_%E5%B8%8C%E5%B0%94%E6%8E%92%E5%BA%8F.cpp)


<h2 id="2">2. 交换类排序</h2>
- 交换类排序核心：对原序列进行元素交换移动实现排序。
- 默认都为升序排序
- 
<h3 id="2.1">2.1 冒泡排序</h3>

已知一个序列，例如 arr[5]={9，7，5，3，1}；
1. 从左往右，对每对相邻元素比较     (arr[0]-arr[1],arr[1]-arr[2],...,arr[n-2]-arr[n-1]) ，**比较后将较大的元素后移**，经过一趟循环，会将当前序列内**最大元素移动至末尾**，即末尾元素有序;
2. 重复这种**相互比较、后移**的过程，使得有序序列长度持续增加，无序序列长度持续减短；
3. 最终当循环过程 **不发生任何元素交换移动时** ，标志冒泡排序结束。

```
for(i=n-1;i>=1;i--)         //每趟排序把最大元素移至后面
{
	flag = 0;
	for(j=1;j<=i;j++)       //从左往右，相邻元素比较
		if(arr[j-1]>arr[j]) //交换移动
        {
            temp = arr[j];
            arr[j] = arr[j-1];
            arr[j-1] = temp;
            flag = 1;
        }
    if(flag==0)         //若某趟排序中没有发生交换，标志排序完毕
        return;
    }
```
- [冒泡排序](https://github.com/SouthBegonia/Computer-Course/blob/master/Algorithm/Sort/%E6%8E%92%E5%BA%8F_%E4%BA%A4%E6%8D%A2%E7%B1%BB_%E5%86%92%E6%B3%A1%E6%8E%92%E5%BA%8F.cpp)


<h3 id="2.2">2.2 快速排序</h3>

基本思路在于设定一个**枢轴值**，将序列小于、大于它的元素分别 *置于其两侧* ，再对2子序列重复该过程：
已知序列 arr[8]={49,38,65,97,76,13,27,49}，序列左右标记为 i,j；
1. 默认选取最左边值 arr[low] 为 **枢轴**，**先右边标记 j 左移**，直到找到小于枢轴的元素 27；
2. 将小元素 27 赋给 arr[i]，**后左标记 i 右移**，直到找到大于枢轴的元素 65；
3. 将大元素 65 赋给 arr[j]，后右标记j左移，重复过程；
4. 最终 **i，j 相遇**，该序列循环结束，**本位置即为枢轴最终位置**，枢轴将序列**分割**为2个子序列；
5. 再分别对2个子序列重复这种找枢轴，移动标记，分割序列的过程，最终实现排序。

```
	int temp;       //枢轴
	int i = low,j = high;       //左右标记

    if(low<high)    //左右标记未相遇，可再进行排序时
    {
        temp = arr[low];    //取得枢轴

        while(i<j)
        {
            while(j>i && arr[j]>=temp)  //先右标左移，直到小于枢轴的数
                --j;
            if(i<j)
            {
                arr[i] = arr[j];    //小元素前赋值
                ++i;
            }

            while(i<j && arr[i]<temp)   //再左标右移，直到大于枢轴的数
                ++i;
            if(i<j)
            {
                arr[j] = arr[i];    //大元素后赋值
                --j;
            }
        }

        arr[i] = temp;      //枢轴归位
        QuickSort(arr,low,i-1);     //排左序列
        QuickSort(arr,i+1,high);    //排右序列
    }
```
- [快速排序](https://github.com/SouthBegonia/Computer-Course/blob/master/Algorithm/Sort/%E6%8E%92%E5%BA%8F_%E4%BA%A4%E6%8D%A2%E7%B1%BB_%E5%BF%AB%E9%80%9F%E6%8E%92%E5%BA%8F.cpp)