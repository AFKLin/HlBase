using System;
using System.Collections.Generic;

namespace ECS.Domain
{
    [Serializable]
    public partial class ConfigArea : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ProvinceId
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// CityId
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// AreaCode
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// IsCashOnDelivery
        /// </summary>
        public bool IsCashOnDelivery { get; set; }
        /// <summary>
        /// IsEnable
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public System.DateTime LastUpdateTime { get; set; }
    }
}
