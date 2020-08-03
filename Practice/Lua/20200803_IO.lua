-- IO --
file = io.open("20200803_IO_Test.lua", "r") -- 只读打开
io.input(file)	-- 设置默认输入文件
print(io.read(),"\n") -- 输出文件第一行

file:seek("set",30) -- 从文件头的第30个位置读取
print(file:read("*a")) -- 读取整个文件

io.close(file)  -- 关闭打开的文件
print("----------")

file = io.open("20200803_IO_Test.lua", "a") -- 读写方式
io.output(file)  -- 设置默认输出文件
io.write("-- 20200803_IO.lua") --写入内容
io.close()