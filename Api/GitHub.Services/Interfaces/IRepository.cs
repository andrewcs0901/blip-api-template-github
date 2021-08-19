using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubIntegration.Services.Interfaces
{
    interface IRepository<T>
    {
        T getRepositories();
    }
}
