-- 02 --
--注：module模块需要放在 \Lua\luaX.X.X\bin\lua 文件夹下才可寻找到
module.func3()
require("module")
print(module.constant)
module.func3()

local m = require("module")
print(m.constant)
m.func3()