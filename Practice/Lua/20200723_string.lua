-- 字符串 --

print("\"AAA\"")
print([["BBB\/"]])

print(string.upper("abcde"))
print(string.lower("ABCDE"))

print(string.gsub("aaaaab","a","c",2))

print(string.find("South Begonia", "Begonia",1))

print(string.reverse("Lua"))

print(string.format("time is %d:%d",12,21))

print(string.len("Hello"))

local sourceStr = "hello--Im--Fine"
local firstSub = string.sub(sourceStr, 1,5)
local secondSub = string.sub(sourceStr,8,9)
print(firstSub,secondSub)

print(string.find("Hello World", "World"))

print(string.byte("A"), string.byte("a"))