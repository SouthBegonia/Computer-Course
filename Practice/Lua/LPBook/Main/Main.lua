--m = {}
--m.__index = function(table, key)    -- 定义元表的__index方法
--    return "zzw - undefined";
--end
--
--pos = {
--    x = 1,
--    y = 2
--}
--print(pos.z);   -- pos为普通表，没有z成员
--
--setmetatable(pos, m);   -- 设定m为pos的元表
--
--print(pos.z);   -- pos无z成员，


require("lfs")
path = lfs.currentdir()
package.path = package.path .. ";" .. path .. "/Logic/?.lua";



-- 类的测试
function PersonTest()
    require("Player");

    local pa = Person:create("A");
    local pb = Person:create("B");
    pa:Talk("I'm A");
    pb:Talk("I'm B");
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
    -- PersonTest();
    -- ModuleTest();
    -- ModuleTest2();
    -- ModuleTest3();

    BookTest()
end


