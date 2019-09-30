#include <cstdio>
#include <string>

char FirstNotRepeatingChar(const char* pString)
{
	//��ָ�����
	if(pString == nullptr)
		return '\0';

	//ģ���ϣ������ASCII���256���ַ�
	const int tableSize = 256;
	unsigned int hashTable[tableSize];
	for(unsigned int i = 0; i < tableSize; ++i)
		hashTable[i] = 0;

	//�����ֵΪ�ַ��ĳ��ִ���
	const char* pHashKey = pString;
	while(*(pHashKey) != '\0')
		hashTable[*(pHashKey++)] ++;

	//������
	pHashKey = pString;
	while(*pHashKey != '\0')
	{
		//���Ԫ�صļ�ֵΪ1������ʾ���ִ���Ϊ1�����ظ��ַ�
		if(hashTable[*pHashKey] == 1)
			return *pHashKey;
			
		//�����������
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
	//����ֻ����һ�ε��ַ� 'o'
	Test("wow", 'o');
	
	//������ֻ����һ�ε��ַ� 'c'
	Test("aabccdbd", 'c');
	
	//����ֻ����һ�ε��ַ� 'a'
	Test("abcdefg", 'a');
	
	//��ָ��
	Test(nullptr, '\0');

	getchar();
	return 0;
}

