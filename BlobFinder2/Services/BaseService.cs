/// <copyright file="BaseService.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Generic application service</summary>
/// 
namespace BlobFinder2.Services
{
    using Microsoft.Extensions.Logging;
    public class BaseService<T>
    {
        protected readonly ILogger<T> logger;

        public BaseService(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<T>();
        }
    }
}
