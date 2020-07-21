-- 函数 --
function max( num1, num2 )
	if(num1 > num2) then
		result = num1
	else
		result = num2
	end
	return result
end
print(max(1,2))
print(max(1,-1))
print()

-- 函数作为参数传递 -- 
myPrint = function ( param )
	print("这是打印的函数 - ##", param, "##")
end
function add( num1, num2, functionPrint )
	result = num1 + num2
	functionPrint(result)
end
myPrint(10)
add(4,5,myPrint)
print()

-- 函数的多返回值 --
function maxinum( a )
	local mi = 1
	local m = a[mi]
	for i,v in ipairs(a) do
		if(v > m) then
			mi = i
			m = v
		end
	end
	return m, mi
end
print(maxinum({0,9,5,2,1}))
print()

-- 函数的可变参数 --
function add2( ... )
	local s = 1
	local arg = {...}
	for i,v in ipairs{...} do
		s = s +v
	end
	print("总共传入 " .. #arg .. " 个参数")
	return s
end
print("总和为 " .. add2(1,2,3,4,5))
print()

-- 获取参数信息 --
do
	function foo( ... )
		for i = 1, select('#', ...) do
			local arg = select(i, ...);
			print("arg", arg);
		end
	end
	foo(1,2,3,4)
end