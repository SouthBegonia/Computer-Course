using System;
using System.Collections.Generic;

//责任链模式
namespace ChainOfResponsibilityPattern
{
    public interface ITask
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="taskChain"></param>
        void Execute(TaskChain taskChain);
    }

    #region 具体ITask

    public class PVETask : ITask
    {
        public void Execute(TaskChain taskChain)
        {
            Console.WriteLine("任务 刷PVE副本 完毕.");
            taskChain.Execute(taskChain);
        }
    }

    public class UpgrdeEquipmentTask : ITask
    {
        public void Execute(TaskChain taskChain)
        {
            Console.WriteLine("任务 升级装备 完毕.");
            taskChain.Execute(taskChain);
        }
    }

    public class WorldBossTask : ITask
    {
        public void Execute(TaskChain taskChain)
        {
            Console.WriteLine("任务 世界Boss 完毕.");
            taskChain.Execute(taskChain);
        }
    }

    #endregion

    /// <summary>
    /// 具体责任链 - 任务责任链
    /// </summary>
    public class TaskChain : ITask
    {
        /// <summary>
        /// 责任链已执行任务数
        /// </summary>
        private int finishedTaskCount = 0;

        /// <summary>
        /// 责任链上的全部任务
        /// </summary>
        private List<ITask> tasks = new List<ITask>();

        /// <summary>
        /// 责任链完成回调
        /// </summary>
        private Action taskFinishedCallBack = null;


        public TaskChain(Action taskFinishedCallBack)
        {
            this.taskFinishedCallBack = taskFinishedCallBack;
        }

        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }

        public void AddTask(List<ITask> taskList)
        {
            foreach (var task in taskList)
                this.tasks.Add(task);
        }

        public void Execute(TaskChain taskChain)
        {
            if (finishedTaskCount == tasks.Count)
            {
                //责任链执行完毕
                taskFinishedCallBack?.Invoke();
                return;
            }

            //执行责任链
            ITask curTask = tasks[finishedTaskCount++];
            curTask.Execute(taskChain);
        }
    }


    public class Client
    {
        static void Main()
        {
            //构造任务链
            TaskChain dailyTaskChain = new TaskChain(
                () => Console.WriteLine("日常任务 完成.")
            );
            var dailyTaskList = TaskListGenerator.GenDailyTaskList();
            dailyTaskChain.AddTask(dailyTaskList);

            //开始执行任务链
            dailyTaskChain.Execute(dailyTaskChain);


            Console.WriteLine();


            TaskChain weeklyTaskChain = new TaskChain(
                () => Console.WriteLine("周常任务 完成.")
            );
            weeklyTaskChain.AddTask(TaskListGenerator.GenWeeklyTaskList());
            weeklyTaskChain.Execute(weeklyTaskChain);
        }
    }

    public static class TaskListGenerator
    {
        /// <summary>
        /// 生成 日常任务列表
        /// </summary>
        /// <returns></returns>
        public static List<ITask> GenDailyTaskList()
        {
            var taskList = new List<ITask>
            {
                new PVETask(),
                new UpgrdeEquipmentTask()
            };

            return taskList;
        }

        /// <summary>
        /// 生成 周常任务列表
        /// </summary>
        /// <returns></returns>
        public static List<ITask> GenWeeklyTaskList()
        {
            var taskList = new List<ITask>
            {
                new UpgrdeEquipmentTask(),
                new WorldBossTask(),
            };

            return taskList;
        }
    }
}