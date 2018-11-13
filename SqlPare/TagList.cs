using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/**
* 命名空间: SqlPaser 
* 类 名： TagList
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：TagList  
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/13 11:52:17 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/13 11:52:17 
    /// </summary>
    public class TagList
    {
        TagTreeNode head = null;
        TagTreeNode tail = null;
        private static string defaultTag = "field";
        private static string child = "clause";
        public void Append(TagTreeNode node)
        {

            if (head == null)
            {
                head = node;
                tail = node;
                return;
            }
            //
            tail.NextNode = node;
            tail = node;
          
        }
       public List<Tag.Tag> GetTags()
        {
            List<Tag.Tag> tags=new List<Tag.Tag>();
         
            TagTreeNode next = head.NextNode;
            TagTreeNode last = null;
            TagTreeNode cur = null;
            TagTreeNode lastPre = null;
            Tag.Tag tag = new Tag.Tag();
            try
            {
                tag.TagType = (TagType)Enum.Parse(typeof(TagType), head.NodeKey);
            }
            catch
            {
                throw new Exception("SQL异常");
            }
            while (next != null)
            {
               if(TagFactory.defaultTag==next.NodeKey)
                {
                    //说明是数据
                    if(null==last)
                    {
                        cur = head;
                      
                    }
                    else
                    {
                        cur = last;
                    }
                    //
                    switch(cur.NodeKey)
                    {
                        case "select":
                            tag.Fields.AddRange(next.NodeData);
                            break;
                        case "from":
                        case "table":
                        case "into":
                        case "join":
                            tag.Table.AddRange(next.NodeData);
                            break;
                        case "l_clause":
                            {
                                if(lastPre!=null&&lastPre.NodeKey=="into")
                                {
                                    tag.Fields.AddRange(next.NodeData);
                                }
                            }
                            break;
                        case "as":
                            {
                                if (lastPre != null&&lastPre.NodeData.Count>0)
                                {
                                    tag.Alias[lastPre.NodeData[lastPre.NodeData.Count-1]] = next.NodeData[0];
                                }
                            }
                            break;
                        case "field":
                            {
                                if(cur.NodeData.Count>0)
                                tag.Alias[cur.NodeData[cur.NodeData.Count-1]] = next.NodeData[0];
                            }
                     
                            break;

                    }
                    //

                }
               else
                {
                    TagType tagType;
                    if (Enum.TryParse<TagType>(next.NodeKey, out tagType))
                    {
                        //说明是操作类关键词
                        tags.Add(tag);
                        tag = new Tag.Tag();
                        tag.TagType = tagType;
                      
                    }
                }
                lastPre = last;
                last = next;
                next = next.NextNode;
            }
            //
            tags.Add(tag);
            return tags;
        }
    }

}
