using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser 
* 类 名： TagTree
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：TagTree  
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/13 0:40:11 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/13 0:40:11 
    /// </summary>
    public class TagTreeNode
    {
      

        /// <summary>
        /// 本节点关键字
        /// </summary>
        public string NodeKey { get; set; }

       /// <summary>
       /// 节点护具
       /// </summary>
        public List<string> NodeData { get; set; }

        /// <summary>
        /// 下一个节点
        /// </summary>
        public TagTreeNode NextNode { get; set; }

     

    }
}
