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
print()


-- __newindex元方法 --
--[[
当对表内不存在的索引赋值时，会调用__newindex方法
--]]
mymetatable2 = {}
mytable2 = setmetatable(
	{key1 = "value1"},
	{__newindex = mymetatable2})
print(mytable2.key1)

mytable2.newkey = "新值2"	--对不存在的键赋值
print(mytable2.newkey, mymetatable2.newkey)

mytable2.key1 = "新值1"
print(mytable2.key1, mymetatable2.key1)
--[[
mymetatable2 = {}
mytable2 = setmetatable(
	{key1 = "value1"},
	{__newindex = function (  )
		print("测试")
	end})
mytable2.newkey = "新值2"	--对不存在的键赋值
--]]
