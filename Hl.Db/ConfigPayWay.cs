//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECS.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConfigPayWay
    {
        public int Id { get; set; }
        public string PayType { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string MerchantAccount { get; set; }
        public string MerchantId { get; set; }
        public string MerchanKey { get; set; }
        public string PayKey { get; set; }
        public decimal Fee { get; set; }
        public string Remark { get; set; }
        public bool IsEnable { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
    }
}