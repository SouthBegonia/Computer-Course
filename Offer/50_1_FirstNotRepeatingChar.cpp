#include <cstdio>
#include <string>

char FirstNotRepeatingChar(const char* pString)
{
	//空指针情况
	if(pString == nullptr)
		return '\0';

	//模拟哈希表，完整ASCII码表共256个字符
	const int tableSize = 256;
	unsigned int hashTable[tableSize];
	for(unsigned int i = 0; i < tableSize; ++i)
		hashTable[i] = 0;

	//入表：键值为字符的出现次数
	const char* pHashKey = pString;
	while(*(pHashKey) != '\0')
		hashTable[*(pHashKey++)] ++;

	//遍历表
	pHashKey = pString;
	while(*pHashKey != '\0')
	{
		//如果元素的键值为1，即表示出现次数为1，返回该字符
		if(hashTable[*pHashKey] == 1)
			return *pHashKey;
			
		//否则继续遍历
		pHashKey++;
	}
	return '\0';
}

void Test(const char* pString, char expected)
{
	if(FirstNotRepeatingChar(pString) == expected)
		printf("Test passed.\n");
	else
		printf("Test failed.\n");
}

int main(int argc, char* argv[])
{
	//存在只出现一次的字符 'o'
	Test("wow", 'o');
	
	//不存在只出现一次的字符 'c'
	Test("aabccdbd", 'c');
	
	//存在只出现一次的字符 'a'
	Test("abcdefg", 'a');
	
	//空指针
	Test(nullptr, '\0');

	getchar();
	return 0;
}

