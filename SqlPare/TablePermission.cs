using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser 
* 类 名： TablePermission
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：TablePermission 
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/13 22:08:15 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/13 22:08:15 
    /// </summary>
    public class TablePermission
    {
        private Dictionary<PermissionType, List<string>> dicTable = new Dictionary<PermissionType, List<string>>();
        private Dictionary<string, string> dicA = new Dictionary<string, string>();

        /// <summary>
        /// 别名信息
        /// </summary>
        public Dictionary<string,string> Alias { get { return dicA; } }
        internal void Process(Tag.Tag tag)
        {
            List<string> list = null;
            PermissionType pType;
            Enum.TryParse<PermissionType>(tag.TagType.ToString(), out pType);
            if (dicTable.TryGetValue(pType, out list))
            {
                list.AddRange(tag.Table);
            }
            else
            {
                list = new List<string>(tag.Table);
                dicTable[pType] = list;
            }
            if(tag.Alias.Count>0)
            {
               foreach(KeyValuePair<string,string> kv in tag.Alias)
                {
                    dicA[kv.Key] = kv.Value;
                }
            }
        }

        internal void AddRange(List<Tag.Tag> tags)
        {
            foreach(Tag.Tag tag in tags)
            {
                Process(tag);
            }
        }

        /// <summary>
        /// 获取权限表
        /// </summary>
        /// <param name="tagType"></param>
        /// <returns></returns>
        public List<string> GetTables(PermissionType tagType)
        {
            List<string> list = null;
            dicTable.TryGetValue(tagType, out list);
            return list;
        }

        /// <summary>
        /// 权限
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public List<string> GetTables(string tagName)
        {
            if(string.IsNullOrWhiteSpace(tagName))
            {
                return null;
            }
            List<string> list = null;

            PermissionType tagType;
            if (Enum.TryParse<PermissionType>(tagName.Trim().ToLower(), out tagType))
            {
                dicTable.TryGetValue(tagType, out list);
              
            }
            return list;
        }
    }
}
