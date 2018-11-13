using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser 
* 类 名： TagFactory
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：TagFactory  
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/13 10:48:39 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/13 10:48:39 
    /// </summary>
   internal class TagFactory
    {
        public static string[] allTag = { "select", "insert", "update", "drop", "table", "truncate", "delete", "join", "on", "from", "clause","into","as","where","in" };
        public static string defaultTag = "field";
        public static string child = "clause";
        public  static TagTreeNode Create(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            string key = value.Trim().ToLower();
            TagTreeNode node = new TagTreeNode();
            node.NodeKey = defaultTag;
            if (key == "(")
            {
                node.NodeKey = "l_" + child;
            }
            else if (key == ")")
            {
                node.NodeKey = "r_" + child;
            }
            else
            {
                foreach (string k in allTag)
                {
                    if (k == key)
                    {
                        node.NodeKey = k;
                        break;
                    }
                }
            }
            if(node.NodeKey==defaultTag)
            {
                node.NodeData =new List<string>(key.Split(','));
            }
            return node;
        }


    }
}
