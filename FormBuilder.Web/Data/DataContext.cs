using System.Collections.Generic;
using Microsoft.Practices.Unity;
using FormBuilder.Models;

namespace FormBuilder.Data
{
    public sealed class DataContext
    {
        #region - Variables -
        readonly IRepository _repository;
        #endregion

        #region - Contructors -
        public DataContext(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region - Methods -
        public static List<FormModel> ListForms()
        {
            return Resolve().ListForms();
        }

        public static List<FormResultModel> ListFormData()
        {
            return Resolve().ListFormData();
        }

        public static bool SaveForm(FormModel form)
        {
            return Resolve().SaveForm(form);
        }

        public static bool SaveFormData(FormResultModel formData)
        {
            return Resolve().SaveFormData(formData);
        }

        private static IRepository Resolve()
        {
            return Configuration.Instance.Container.Resolve<DataContext>()._repository;
        }
        #endregion
    }
}