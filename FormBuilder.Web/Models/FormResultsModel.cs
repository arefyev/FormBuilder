using System.Collections.Generic;

namespace FormBuilder.Models
{
    /// <summary>
    /// Represents data for results
    /// </summary>
    public sealed class FormResultsModel
    {
        /// <summary>
        /// Certain form data
        /// </summary>
        public FormModel Form { get; set; }
        /// <summary>
        /// REsults for form
        /// </summary>
        public List<string> Results { get; set; }
    }
}