using FormBuilder.Common;

namespace FormBuilder.Biz
{
    /// <summary>
    /// Represents general structure for providers
    /// </summary>
    public interface IProvider
    {
        ICacheService CacheService { get;  }
    }
}
