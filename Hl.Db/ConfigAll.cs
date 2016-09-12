using System;
using System.Collections.Generic;

namespace ECS.Domain
{
    [Serializable]
    public partial class ConfigAll : IEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
