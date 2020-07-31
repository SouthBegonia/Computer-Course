-- 自定义计算表中最大键值函数 table_maxn，即计算表的元素个数
function table_maxn(t)
    local mn = 0
    for k, v in pairs(t) do
        if mn < k then
            mn = k
        end
    end
    return mn
end

-- __call元方法 --
mytable = setmetatable({10},
	{ __call = function ( mytable,newtable )
		sum = 0
		for i=1, table_maxn(mytable) do
			sum = sum + mytable[i]
		end
		for i=1, table_maxn(newtable) do
			sum = sum + newtable[i]
		end
		return sum
	end})
newtable = {10,20,30}
print(mytable(newtable))