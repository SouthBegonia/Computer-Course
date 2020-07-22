-- 运算符 --

-- 关系运算符 --
a = 10
b = 10
c = 20
if(a == b) then
	print("1")
end
if(a ~= c) then
	print("2")
end

-- 逻辑运算符 --
a = true
b = false
if(a and b) then
	print("3")
end
if(a or b) then 
	print("4")
end
if(a and not(b)) then
	print("5")
end
print()

-- 其他运算符 --
a = "South"
b = "Begonia"
print(a .. b)
print(a, b)
print(#a, #b)
tab1 = {"1", "2", nil}
print(#tab1)

tab3={}
tab3[1]="1"
tab3[2]="2"
tab3[5]="5" -- 下标越位
print("tab3的长度",#tab3) --2

tab4 = {}
tab4[1] = "1"
tab4[2] = nil
tab4[3] = "2"
print("tab4的长度", #tab4) -- 1