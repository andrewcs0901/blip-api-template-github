using System;
using System.Collections.Generic;
using GitHubIntegration.Services.Interfaces;
using GitHubIntegration.Models;
using RestEase;
using System.Threading.Tasks;
using System.Linq;

namespace GitHubIntegration.Services
{
    public class RepositoryService : IRepository<Repository>
    {
        private readonly string GitHubRepoAPI = "https://api.github.com";
        public string User { get; }
        ///users/takenet/repos

        public RepositoryService(string user)
        {
            User = user;
        }
        public Repository getRepositories()
        {
            throw new NotImplementedException();
        }

        [Header("User-Agent", "RestEase")]
        public interface IGitHubApi
        {
            // The [Get] attribute marks this method as a GET request
            // The "users" is a relative path the a base URL, which we'll provide later
            // "{userId}" is a placeholder in the URL: the value from the "userId" method parameter is used
            [Get("users/{userId}")]
            Task<Repository> GetUserAsync([Path] string userId);

            [Get("users/{userId}/repos")]
            Task<Repository[]> GetUserReposAsync([Path] string userId);
        }

        public Repository[] GetAll() => RestClient.For<IGitHubApi>(GitHubRepoAPI).GetUserReposAsync(User).Result;

        public Repository[] GetByLanguage(string language = "c#") =>
            GetAll()
            .Where(repo => language.Equals(repo.Language?.ToString(), StringComparison.OrdinalIgnoreCase))
            .ToArray();

    }
}
