using System;
using System.Collections.Generic;
using FormBuilder.Models;

namespace FormBuilder.Biz
{
    /// <summary>
    /// Represents methods for form builder
    /// </summary>
    public interface IFormProvider
    {
        List<FormModel> LoadForms();

        FormModel LoadForm(Guid id);

        List<FormResultModel> LoadAllResults();

        List<FormResultModel> LoadFormResults(Guid id);

        Guid SaveForm(FormModel form);

        void SaveFormData(FormResultModel formData);
    }
}
