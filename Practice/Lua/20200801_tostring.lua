-- tostring 元方法 --
--[[
修改表的输出行为
--]]
mytable = setmetatable(
	{10,20,30},
	{
		__tostring = function ( mytable )
			sum = 0
		for k,v in pairs(mytable) do
			sum = sum + v
		end
		return "表内元素和为: " .. sum
	end
	})
print(mytable)