using System.Collections.Generic;

namespace FormBuilder.Models
{
    public sealed class FormResultsModel
    {
        public FormModel Form { get; set; }

        public List<string> Results { get; set; }
    }
}