using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace FormBuilder.Data
{
    /// <summary>
    /// Provides certain methods to give access to the file repository
    /// </summary>
    public abstract class FileRepository : IFileRepository
    {
        #region - Methods -
        /// <summary>
        /// Loads data form file and converts to specified object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        public List<T> GetData<T>(string fileName)
        {
            var path = HttpContext.Current.Server.MapPath(String.Format("~/App_Data/{0}.data", fileName));

            if (!File.Exists(path))
                return new List<T>();

            try
            {
                var result = new List<T>();
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var data = (T)JsonConvert.DeserializeObject(line, typeof(T));
                    if (data != null)
                        result.Add(data);
                }
                return result;
            }
            catch
            {
                //log error
                return new List<T>();
            }
        }
        /// <summary>
        /// Adds serialized data to the file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="data">Serialized data</param>
        public bool SetData(string fileName, string data)
        {
            var path = HttpContext.Current.Server.MapPath(String.Format("~/App_Data/{0}.data", fileName));
            try
            {
                if (!File.Exists(path))
                    File.Create(path).Dispose();

                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine(data);
                }
                return true;
            }
            catch
            {
                //log error
                return false;
            }
        }
        #endregion
    }
}