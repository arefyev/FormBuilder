using System;

namespace FormBuilder.Models
{
    public sealed class FormModel
    {
        /// <summary>
        /// Person name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Contact phone number
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? FormId { get; set; }
        /// <summary>
        /// Form data
        /// </summary>
        public string Form { get; set; }
    }
}