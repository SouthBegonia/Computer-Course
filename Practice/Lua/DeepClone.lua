--[[
    Lua 深拷贝
--]]

function DeepCopy(originObj)
    local lookupTable = {}

    local _copy
    _copy = function(obj)
        -- 基础数据类型的属性进行简单赋值操作
        if type(obj) ~= "table" then
            return obj
        end

        -- 表类型的属性进行迭代拷贝
        -- 这里的查找表是为了避免重复拷贝
        if lookupTable[obj] then
            return lookupTable[obj]
        end

        local newTable = {}
        lookupTable[obj] = newTable

        for _k, _v in pairs(obj) do
            -- 要考虑key和value为表的情况
            newTable[_copy(_k)] = _copy(_v)
        end

        -- 不要忘记复制元表
        return setmetatable(newTable, getmetatable(obj))
    end

    return _copy(originObj)
end


---------------------- Test ----------------------

local PlayerInfoNode = {
    Pid = 9527,
    Bag = {
        [1] = "Currency",
        [2] = "Weapon",
    },

    LogInfo = function(self)
        local logStr = "Pid=" .. self.Pid;
        logStr = logStr .. "    Bag=[" .. self.Bag[1] .. ", " .. self.Bag[2] .. "]";
        print(logStr);
    end
};
PlayerInfoNode:LogInfo();
PlayerInfoNode.Bag[2] = "Diamond";

local PlayerInfoNodeClone = DeepCopy(PlayerInfoNode);
PlayerInfoNodeClone:LogInfo();

--[[
    OUTPUT:
    Pid=9527    Bag=[Currency, Weapon]
    Pid=9527    Bag=[Currency, Diamond]
--]]