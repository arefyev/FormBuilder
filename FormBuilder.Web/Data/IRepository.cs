using System.Collections.Generic;
using FormBuilder.Models;

namespace FormBuilder.Data
{
    /// <summary>
    /// Represents methods for concrete repository
    /// </summary>
    public interface IRepository
    {
        List<FormModel> ListForms();

        List<FormResultModel> ListFormData();

        bool SaveForm(FormModel form);

        bool SaveFormData(FormResultModel formModel);
    }
}
