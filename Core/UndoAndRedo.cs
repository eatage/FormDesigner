using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesinger
{
    /// <summary>
    /// 撤销与恢复
    /// </summary>
    public class UndoAndRedo
    {
        //撤销表
        private List<string> undoList = new List<string>();
        //重做表
        private List<string> redoList = new List<string>();
        //最大撤销/重做次数
        private int undoCount = -1;
        //记录是否为撤销的记录，因为在execute函数里会造成重复
        private bool und = false;
        //记录当前需要撤销或回复的字符串
        private string temp;
        /// <summary>
        /// 撤销与恢复
        /// </summary>
        /// <param name="_undoCount">撤销与恢复的最大次数</param>
        public UndoAndRedo(int _undoCount)
        {
            //校正最大撤销/重做次数
            undoCount = _undoCount + 1;
            //上一句的原因
            undoList.Add("");
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="command"></param>
        public void execute(string command)
        {
            temp = command;
            if (!und)
            {
                undoList.Add(command);
                if (undoCount != -1 && undoList.Count > undoCount)
                {
                    undoList.RemoveAt(0);
                }
            }
            else
            {
                und = false;
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        public void undo()
        {
            if (undoList.Count <= 1)
                return;
            und = true;
            redoList.Add(undoList[undoList.Count - 1]);
            undoList.RemoveAt(undoList.Count - 1);
            temp = undoList[undoList.Count - 1];
        }
        /// <summary>
        /// 恢复
        /// </summary>
        public void redo()
        {
            if (redoList.Count <= 0)
                return;
            temp = redoList[redoList.Count - 1];
            redoList.RemoveAt(redoList.Count - 1);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        public string Record
        {
            get { return temp; }
        }
    }
}
