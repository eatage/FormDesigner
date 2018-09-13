using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FormDesinger
{
    class Tools
    {

    }
    /// <summary>
    /// 对齐方式
    /// </summary>
    public enum AlginType
    {
        /// <summary>
        /// 左对齐
        /// </summary>
        Left,
        /// <summary>
        /// 右对齐
        /// </summary>
        Right,
        /// <summary>
        /// 上对齐
        /// </summary>
        Top,
        /// <summary>
        /// 下对齐
        /// </summary>
        Bottom,
        /// <summary>
        /// 居中（水平居中）
        /// </summary>
        Center,
        /// <summary>
        /// 居中（垂直居中）
        /// </summary>
        VerticalCenter,
        /// <summary>
        /// 等宽
        /// </summary>
        EqualWidth,
        /// <summary>
        /// 等高
        /// </summary>
        EqualHeight,
    }
}
