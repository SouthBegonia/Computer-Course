---@class RankData 排行数据
RankData = {
    ---@type number 分数
    Score = 0;
    ---@type number 玩家ID
    ID = 0;
    ---@type string 玩家名字
    Name = "";
};
RankData.__index = RankData;

---New
---@param name string
---@param id number
---@param score number
function RankData.New(name, id, score)
    ---@type RankData
    local t = {};
    setmetatable(t, RankData);

    t.Name = name;
    t.ID = id;
    t.Score = score;

    return t;
end


---RankSort_ID_Ascending
---@param dataA RankData
---@param dataB RankData
function RankSort_ID_Ascending(dataA, dataB)
    return dataA.ID < dataB.ID;
end

---RankSort_Score_Ascending
---@param dataA RankData
---@param dataB RankData
function RankSort_Score_Descending (dataA, dataB)
    return dataA.Score > dataB.Score;
end

---PrintRanks
---@param datas RankData[]
---@param tag string
function PrintRanks(tag, datas)
    local str = ""
    for i = 1, #datas do
        str = str .. datas[i].Name .. " ";
    end
    print(tag .. str);
end

---CloneTable
---@param targetTable table
---@return table
function CloneTable(targetTable)
    local t = {};

    for i = 1, #targetTable do
        t[i] = targetTable[i];
    end

    return t;
end


---------- MainLogic ----------
do
    ---@type RankData[]
    local rankDataTable = {
        RankData.New("A", 105,6000),
        RankData.New("B", 104,5000),
        RankData.New("C", 103,4000),
        RankData.New("D", 102,3000),
        RankData.New("E", 101,2000),
        RankData.New("F", 100,1000),
    };

    local tb1 = CloneTable(rankDataTable)
    table.sort(tb1, RankSort_ID_Ascending);
    PrintRanks("ID升序：", tb1);

    local tb2 = CloneTable(rankDataTable);
    table.sort(tb2, RankSort_Score_Descending);
    PrintRanks("Score降序：" ,tb2);
end
