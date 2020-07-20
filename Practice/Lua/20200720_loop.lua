-- 循环 --

-- while --
a = 0
while(a < 5)
	do
	print("a的值为：", a)
	a = a + 1
end
print()

-- 数值for循环 --
for i=0, 10, 2 do
	print(i)
end
for i=10, 0, -5 do
	print(i)
end
print()

-- 泛型for循环 --
t = {"one", nil, "three", "four"}
for i,v in ipairs(t) do
	print(i,v)
end
print()

for i,v in pairs(t) do
	print(i,v)
end
print()
--[[
pairs可以遍历表中所有的key，并且除了迭代器本身以及遍历表本身还可以返回nil;
ipairs不能返回nil,只能返回数字0，如果遇到nil则退出。它只能遍历到表中出现的第一个不是整数的key
--]]


-- repeat...until 循环 --
b = 10
repeat
	print("b的值为：", b)
	b = b + 1
	until(b > 15)