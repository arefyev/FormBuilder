using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FormBuilder.Data
{
    /// <summary>
    /// Configures DI
    /// </summary>
    public sealed class Configuration
    {
        #region - Variables -
        private static volatile Configuration _instance;
        private static readonly object SyncRoot = new Object();
        #endregion

        #region - Contructors -
        private Configuration()
        {
            Container = new UnityContainer();
            Container.LoadConfiguration();
        }
        #endregion

        #region - Properties -
        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Configuration();
                    }
                }
                return _instance;
            }
        }

        public UnityContainer Container { get; private set; }
        #endregion
    }
}