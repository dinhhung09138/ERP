
namespace Core.Services.Interfaces
{
    /// <summary>
    /// Logger service interface.
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ILoggerService"/> class.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="listObject"></param>
        /// <returns>true/false.</returns>
        bool AddErrorLog(string className, string methodName, params object[] listObject);
    }
}
