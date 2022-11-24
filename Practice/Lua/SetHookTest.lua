--[[
    使用 debug.sethook 方法排查代码执行情况
    参考：https://www.cnblogs.com/lijiajia/p/10817407.html
--]]

debug.sethook(
        function (event, line)
            local debugInfo = debug.getinfo(2);
            local logStr = "[LOG] file=" .. debugInfo.short_src;
            logStr = logStr .. "   currentline = " .. debugInfo.currentline;
            print(logStr)
        end
, "l")


local addNumFunc = function(a, b)
    return a + b;
end

local cur = 0;
local result = 0;
local data = { 1, 2, 3};


print("---------- Start pairs ----------");
for _, val in pairs(data) do
    result = addNumFunc(cur, val);
    print("result = " .. result);
end

--[[
    OUTPUT:
    [LOG] file=SetHookTest.lua   currentline = 18
    [LOG] file=SetHookTest.lua   currentline = 20
    [LOG] file=SetHookTest.lua   currentline = 21
    [LOG] file=SetHookTest.lua   currentline = 22
    [LOG] file=SetHookTest.lua   currentline = 25
    ---------- Start pairs ----------
    [LOG] file=SetHookTest.lua   currentline = 26
    [LOG] file=SetHookTest.lua   currentline = 27
    [LOG] file=SetHookTest.lua   currentline = 17
    [LOG] file=SetHookTest.lua   currentline = 28
    result = 1
    [LOG] file=SetHookTest.lua   currentline = 26
    [LOG] file=SetHookTest.lua   currentline = 27
    [LOG] file=SetHookTest.lua   currentline = 17
    [LOG] file=SetHookTest.lua   currentline = 28
    result = 2
    [LOG] file=SetHookTest.lua   currentline = 26
    [LOG] file=SetHookTest.lua   currentline = 27
    [LOG] file=SetHookTest.lua   currentline = 17
    [LOG] file=SetHookTest.lua   currentline = 28
    result = 3
    [LOG] file=SetHookTest.lua   currentline = 26
    [LOG] file=SetHookTest.lua   currentline = 29

--]]