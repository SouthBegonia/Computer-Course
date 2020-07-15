-- 数据类型 --

print(type("hello"))
print(type(10+1))
print(type(print))
print(type(type))
print(type(true))
print(type(nil))

print()

print(type(nil))

-- boolean -- 
if false or nil then
	print("至少有一个是true")
else
	print("false和nil都是false")
end

if 0 then
	print("数字0是true")
	else
		print("数字0是false")
	end

-- Number --
print()
print(type(1))
print(type(1.1))
print(type(1e+1))
print(type(0.1e-1))
print(type(3.1415926e-01))

-- string --
print()
str1 = "str01"
str2 = "str02"
html = [[z
zzz
w]]
print(str1 .. str2)	-- 连接字符串
print(#str1)		-- 计算字符串长度
print(html)			-- 字符串块
print()

print("1"+2)
print("2"+"2")
print("-2e2" * "6")