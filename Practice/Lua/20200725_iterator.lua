-- 迭代器 --

-- 泛型for迭代器 --
array = {"Hello", "World"}
for key, val in ipairs(array)
	do
	print(key, val)
end

-- 无状态的迭代器 --
function square(iteratorMaxCount,currentNumber)
   if currentNumber<iteratorMaxCount
   then
      currentNumber = currentNumber+1
   return currentNumber, currentNumber*currentNumber
   end
end

for i,n in square,3,0
do
   print(i,n)
end

-- 多状态的迭代器 --
function elementIterator( collection )
	local index = 0
	local count = #collection
	-- 闭包函数
	return function (  )
		index = index + 1
		if(index <= count) then
			return collection[index]
		end
	end
end
for element in elementIterator(array)
	do
	print(element)
end