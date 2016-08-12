using System;
using System.Collections.Generic;
using System.Linq;
using FormBuilder.Common;
using FormBuilder.Data;
using FormBuilder.Models;

namespace FormBuilder.Biz
{
    /// <summary>
    /// Represents methods to get/set data
    /// </summary>
    public class FormProvider : IProvider, IFormProvider
    {
        #region - Variables -
        /// <summary>
        /// Cache for the performance
        /// </summary>
        public ICacheService CacheService { get; }
        #endregion

        #region - Contructors -
        public FormProvider(ICacheService cacheService)
        {
            CacheService = cacheService;
        }
        #endregion

        #region - Methods -
        /// <summary>
        /// Returns all form from storage
        /// </summary>
        /// <returns></returns>
        public List<FormModel> LoadForms()
        {
            return CacheService.Get("forms", DataContext.ListForms);
        }

        public FormModel LoadForm(Guid id)
        {
            return LoadForms().FirstOrDefault(x => x.FormId == id);
        }
        /// <summary>
        /// Returns all data
        /// </summary>
        /// <returns></returns>
        public List<FormResultModel> LoadAllResults()
        {
            return CacheService.Get("formdata", DataContext.ListFormData);
        }
        /// <summary>
        /// Returns data for a specified form
        /// </summary>
        /// <returns></returns>
        public List<FormResultModel> LoadFormResults(Guid id)
        {
            var data = LoadAllResults();
            return data.Where(x => x.Id == id).ToList();
        }
        /// <summary>
        /// Saves form to a storage
        /// </summary>
        /// <param name="form"></param>
        public Guid SaveForm(FormModel form)
        {
            if (!form.FormId.HasValue)
            {
                form.FormId = Guid.NewGuid();
            }

            if (DataContext.SaveForm(form))
                CacheService.Update("forms", form);

            return form.FormId.Value;
        }
        /// <summary>
        /// Saves data form
        /// </summary>
        /// <param name="formData"></param>
        public void SaveFormData(FormResultModel formData)
        {
            if (DataContext.SaveFormData(formData))
                CacheService.Update("formdata", formData);
        }
        #endregion
    }
}