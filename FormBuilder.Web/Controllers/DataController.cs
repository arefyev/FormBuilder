using System;
using System.Collections.Generic;
using System.Linq;
using FormBuilder.Biz;
using FormBuilder.Common;
using FormBuilder.Models;
using FormBuilder.Web;

namespace FormBuilder.Controllers
{
    public class DataController : DataApiController
    {
        private readonly IFormProvider _formProvider;

        public DataController()
        {
            _formProvider = new FormProvider(AppCache);
        }

        public List<ListItem> LoadFormList()
        {
            return _formProvider.LoadForms().Select(x => new ListItem { Text = x.Name, Value = x.FormId.ToString() }).ToList();
        }

        public FormModel LoadForm(FormFilter filter)
        {
            return !filter.Id.HasValue ? null : _formProvider.LoadForm(filter.Id.Value);
        }

        public FormResultsModel LoadFormResults(FormFilter filter)
        {
            if (!filter.Id.HasValue)
                return null;

            var form = _formProvider.LoadForm(filter.Id.Value);
            var results = _formProvider.LoadFormResults(filter.Id.Value).Select(x => x.FormData).ToList();
            return new FormResultsModel {Form = form, Results = results};
        }

        public Guid SaveBuilderForm(FormModel form)
        {
            return _formProvider.SaveForm(form);
        }

        public void SaveFormData(FormResultModel form)
        {
            _formProvider.SaveFormData(form);
        }
    }
}