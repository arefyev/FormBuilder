using System.Collections.Generic;
using Newtonsoft.Json;
using FormBuilder.Models;

namespace FormBuilder.Data
{
    /// <summary>
    /// Provides certain methods to wotk with form repository
    /// </summary>
    public class DataRepository : FileRepository, IRepository
    {
        #region - Methods -
        /// <summary>
        /// Loads all forms from storage
        /// </summary>
        /// <returns></returns>
        public List<FormModel> ListForms()
        {
            return GetData<FormModel>("FormList");
        }
        /// <summary>
        /// Loads all data for all forms from storage
        /// </summary>
        /// <returns></returns>
        public List<FormResultModel> ListFormData()
        {
            return GetData<FormResultModel>("FormResults");
        }
        /// <summary>
        /// Saves new form into storage
        /// </summary>
        /// <param name="form">Form data</param>
        /// <returns></returns>
        public bool SaveForm(FormModel form)
        {
            return SetData("FormList", JsonConvert.SerializeObject(form));
        }
        /// <summary>
        /// Saves filed form data into storage
        /// </summary>
        /// <param name="formModel">Form data</param>
        /// <returns></returns>
        public bool SaveFormData(FormResultModel formModel)
        {
            return SetData("FormResults", JsonConvert.SerializeObject(formModel));
        }
        #endregion
    }
}