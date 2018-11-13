using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser 
* 类 名： TagType
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：TagType  实体类型
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/11 11:09:19 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/11 11:09:19 
    /// </summary>
    internal enum TagType
    {
        unknow,
        select,
        insert,
        update,
        delete,
        drop,
        truncate

    }
}
