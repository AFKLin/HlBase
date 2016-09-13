using System;
using System.Collections.Generic;

namespace ECS.Domain
{
    [Serializable]
    public partial class Test : IEntity
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
        /// Age
        /// </summary>
        public int Age { get; set; }
    }
}
