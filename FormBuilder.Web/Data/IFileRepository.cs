using System.Collections.Generic;

namespace FormBuilder.Data
{
    /// <summary>
    /// Represents interfate for a file repository
    /// </summary>
    interface IFileRepository
    {
        List<T> GetData<T>(string fileName);

        bool SetData(string fileName, string data);
    }
}
