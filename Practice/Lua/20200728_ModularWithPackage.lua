-- 01 --
module = {}
module.constant = "常量"

function module.func1(  )
	io.write("这是公有函数")
end

local function func2(  )
	print("这是私有函数")
end

function module.func3(  )
	func2()
end

return module