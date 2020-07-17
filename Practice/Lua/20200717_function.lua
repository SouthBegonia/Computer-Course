-- 函数 --
function factorial_1( n )
	if n==0 then
		return 1
	else
		return n * factorial_1(n-1)
	end
end
print(factorial_1(5))
factorial_2 = factorial_1
print(factorial_2(5))
print()


function testFun( tab, fun )
	for k,v in pairs(tab) do
		print(fun(k,v))
	end
end
tab = {key1 = "val1", key2 = "val2"}
testFun(tab,
	function ( key,val )		-- 匿名函数
		return key .. "=" .. val
	end);