using System;
using System.Collections.Generic;
using System.Linq;
using FormBuilder.Common;
using FormBuilder.Models;

namespace FormBuilder.Providers
{
    public sealed class StaffProvider : IStaffProvider
    {
        #region - Properties -
        /// <summary>
        /// Cache for the performance
        /// </summary>
        private readonly ICacheService _cacheService;
       
        #endregion

        #region - Contructors -
        public StaffProvider(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        #endregion

        #region - Methods -

        #endregion
    }
}