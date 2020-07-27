-- 表 --
table1  = {}
print("table1的类型是：",type(table1))
table1[1] = "hello"
table1["index"] = "index"
print(table1[1], table1["index"])

table2 = table1
print(table2[1], table2["index"])

table2["index"] = nil
print(table1[1], table1["index"])
print()

-- table 连接 --
fruits = {"Apple", "Origin", "Peach"}
print(table.concat(fruits))
print(table.concat(fruits,", "))
print(table.concat(fruits,", ",2,3))
print()

-- table 插入和移除 --
table.insert(fruits,"Mango")
print(fruits[4])
table.insert(fruits,2,"Grapes")
print(fruits[2])
table.remove(fruits)
print(fruits[4], fruits[5])
print()

-- table 排序 --
fruits = nil
fruits = {"banana","orange","apple","grapes"}
for k,v in ipairs(fruits) do
	print(k,v)
end
table.sort(fruits)
for k,v in ipairs(fruits) do
	print(k,v)
end