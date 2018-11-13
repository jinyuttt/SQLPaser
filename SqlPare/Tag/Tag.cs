using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser.Tag 
* 类 名： Tag
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser.Tag
{
    /// <summary>
    /// 功能描述    ：Tag  
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/11 11:05:30 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/11 11:05:30 
    /// </summary>
  public  class Tag
    {
       public Tag()
        {
            Table = new List<string>();
            Fields = new List<string>();
            Alias = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        internal TagType TagType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string TagName { get; set; }

       /// <summary>
       /// 表
       /// </summary>
        public List<string> Table { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public Dictionary<string,string> Alias { get; set; }


    }
}
