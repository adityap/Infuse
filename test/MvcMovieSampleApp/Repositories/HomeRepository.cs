using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovieSampleApp.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private string CacheMessage = string.Empty;
        public string GetAboutMessage()
        {
            if (string.IsNullOrEmpty(CacheMessage))
                CacheMessage = $"This is a sample application showing the implementation of Infuse IoC Container." +
                    $" The {this.GetType().FullName} just auto resolved from the container!" +
                    $" Also, since it was registered as Singleton type (Controller is Transient type), it will return this message from the cache!" +
                    $" And, note that the time does not change here from the first load: {DateTime.Now.ToLongTimeString()}.";

            return CacheMessage;
        }
    }
}