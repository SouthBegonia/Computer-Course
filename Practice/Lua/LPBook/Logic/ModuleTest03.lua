---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by zhaozhengwei.
--- DateTime: 2021/11/8 11:50
---

local MyUtils = {};

function MyUtils.AddNUm_Static(num1, num2)
    print("AddNUm_Static= " .. (num1+num2));
    -- printStrForModuleTest03()
end

local function printStrForModuleTest03()

end

_G.MyGameUtils = MyUtils;