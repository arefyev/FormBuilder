using System;

namespace FormBuilder.Models
{
    /// <summary>
    /// Represents data to save
    /// </summary>
    public sealed class FormResultModel
    {
        /// <summary>
        /// Certain formn id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Form data
        /// </summary>
        public string FormData { get; set; }
    }
}