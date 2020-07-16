-- 表 --

local tbl1 = {}
local tbl2 = {"Hello", "World", "South", "Begonia"}

a = {}
a["Key"] = "value"
key = 10
a[key] = 22
for k,v in pairs(a) do
	print(k .. " : " .. v)
end

print()
for key,val in pairs(tbl2) do
	print(key,val)
end
print()

a2 = {}
for i=0,10 do
	a2[i] = i
end
a2["key"] = "val"
print(a2["key"])
print(a2["none"])