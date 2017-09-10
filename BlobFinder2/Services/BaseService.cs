using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder2.Services
{
    using Microsoft.Extensions.Logging;
    public class BaseService<T>
    {
        protected readonly ILogger<T> logger;

        public BaseService(ILoggerFactory loggerFactory) {
            this.logger = loggerFactory.CreateLogger<T>();
        }
    }
}
