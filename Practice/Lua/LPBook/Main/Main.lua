-- 设定Main配置的Working Directory = ...\Computer-Course\Practice\Lua\LPBook

require("lfs")
path = lfs.currentdir()
package.path = package.path .. ";" .. path .. "/Logic/?.lua";


-- 类实现的测试
function PlayerTest()
    require("Player");
    require("SubPlayer");

    ---@type Player
    local pa = Player:create("A");
    local pb = Player:create("B");
    pa:Talk("\"I'm Player A\"");
    pb:Talk("\"I'm Player B\"");

    ---@type SubPlayer
    local subPlayer = SubPlayer:create("subPlayer", 10);
    subPlayer:Talk("\"I'm " .. subPlayer.name .. "  age = " .. subPlayer.age .. "\"");
    subPlayer:ReName("subPlayerB");
    subPlayer:Talk("\"I'm " .. subPlayer.name .. "  age = " .. subPlayer.age .. "\"");
end

-- 模块含 return luaTable 的测试
function ModuleTest()
    -- 错误：
    --ModuleTest01.AddNum_Static(1,2);
    --ModuleTest01:AddNum_Public(3,4);
    --print(ModuleTest01.myNum);

    require("ModuleTest01").AddNum_Static(1,2);
    require("ModuleTest01"):AddNum_Public(3,4);
    print("myNum = " .. require("ModuleTest01").myNum);
    require("ModuleTest01").myNum = 4;
    print("Then myNum = " .. require("ModuleTest01").myNum);

    print("----------------------------------------")

    local myMode = require("ModuleTest01");
    myMode.AddNum_Static(1,2);
    print("myNum = " .. myMode.myNum);
    myMode.myNum = 20;
    print("Then myNum = " .. myMode.myNum);
end

-- 模块无 return 的测试（类似全局Define.lua）
function ModuleTest2()
    require("ModuleTest02");

    MyModuleTest2Func();
    print(UIFormId.MainUI);
end

function ModuleTest3()
    require("ModuleTest03")
    MyGameUtils.AddNUm_Static(1,3);
end

function BookTest()
    print("-------------------- BookTest --------------------");
    require("BookTest");

    --myBookTest.C6.VarargExpFunc(1,2);
    --myBookTest.C6.VarargExpFunc(1,2,3.5);
    --myBookTest.C6.SelectFunc(1,2);
    --myBookTest.C6.SelectFunc(1,2,3.5);

    myBookTest.C10.StringFunc();

    print("-------------------- BookTest END--------------------");
end

do
    -- 类的实现、多态、继承
    -- PlayerTest();

    -- ModuleTest();
    -- ModuleTest2();
    -- ModuleTest3();

    -- BookTest()
end


