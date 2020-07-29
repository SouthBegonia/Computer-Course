-- 元表 --
NormalTable = {}	--普通表
mymetatable = {}	--元表

setmetatable(NormalTable,mymetatable) --把mymetatable设定为NormalTable的元表

-- _index元方法 --
--[[
若在元表中找到key1则返回，否则继续
若在元表中找到key2则返回“metatableValue”，否则继续
若元表含有 __index方法且它为函数，则调用
--]]
mytable1 = setmetatable(
	{key1 = "value1"},
	{
		__index = function ( mytable1,key )
			if(key == "key2") then
				return "metatableValue"
			else
				return nil
			end
		end
	})
print(mytable1.key1,mytable1.key2,mytable1.key3)
