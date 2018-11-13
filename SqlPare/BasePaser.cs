using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/**
* 命名空间: SqlPaser 
* 类 名： BasePaser
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：BasePaser  
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/11 11:13:14 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/11 11:13:14 
    /// </summary>
 public abstract  class BasePaser
    {
        TagList tags = null;
        TablePermission tablePermission = null;
        //匹配空格或者*+空格或者字母+)或者字母+(
        protected static Regex find = new Regex(@"\w{0,}\s{1,}|\*\s{1,}|\w+\)|\w{0,}\(|\S+\s{1,}", RegexOptions.IgnoreCase);

        public TablePermission Permission { get { return tablePermission; } }

        public BasePaser()
        {
            tags = new TagList();
            tablePermission = new TablePermission();
        }


        private void FindTag(string sql,int position)
        {
            
            if(position>=sql.Length)
            {
                return;
            }
             Match match= find.Match(sql, position);
            if (match.Success)
            {
                string value = match.Value.Trim();
                if (value.EndsWith(")") || value.EndsWith("("))
                {
                    string field = value.Substring(0, value.Length - 1);
                    if (field.Length > 0)
                    {
                        TagTreeNode node1 = TagFactory.Create(field);
                        tags.Append(node1);
                    }
                    TagTreeNode node2 = TagFactory.Create(value.Substring(value.Length - 1));
                    tags.Append(node2);
                }
                else
                {
                    TagTreeNode node = TagFactory.Create(value);
                    tags.Append(node);
                }
                position = match.Index + match.Value.Length;
                FindTag(sql, position);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public   void   Paser(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return ;
            }
            Regex replaceSpace = new Regex(@"\s{1,}", RegexOptions.IgnoreCase);
            text= replaceSpace.Replace(text, " ").Trim();
            string sql = text.Trim().ToLower()+" ";
            FindTag(sql, 0);
            GetTags();
        }

        private void  GetTags()
        {
            tablePermission.AddRange(tags.GetTags());
        }

      
    }
}
