using System;
using System.Collections.Generic;
using System.Text;

/**
* 命名空间: SqlPaser 
* 类 名： PermissionType
* CLR版本： 4.0.30319.42000
* 版本 ：v1.0
* Copyright (c) jinyu  
*/

namespace SqlPaser
{
    /// <summary>
    /// 功能描述    ：PermissionType    权限类别，内容与TagType一致
    /// 创 建 者    ：jinyu
    /// 创建日期    ：2018/11/13 23:56:37 
    /// 最后修改者  ：jinyu
    /// 最后修改日期：2018/11/13 23:56:37 
    /// </summary>
    public enum PermissionType
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
