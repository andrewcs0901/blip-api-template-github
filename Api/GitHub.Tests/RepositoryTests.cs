using System;
using Xunit;
using GitHubIntegration.Services;

namespace GitHubIntegration.Tests
{
    public class RepositoryTests
    {
        readonly string username = "takenet";
        [Fact]
        public void Instatiate_Repository()
        {
            var repo = new RepositoryService(username);
            Assert.Equal(repo.User, username);
        }

        [Fact]
        public void Get_AllRepositoriesFromUser()
        {
            var repo = new RepositoryService(username);
            Assert.Equal(30, repo.GetAll().Length);
        }

        [Fact]
        public void Get_AllRepositoriesByDefaultLanguage()
        {
            var repo = new RepositoryService(username);
            Assert.Equal(5, repo.GetByLanguage().Length);
        }

        [Fact]
        public void Get_AllRepositoriesByLanguage()
        {
            var repo = new RepositoryService(username);
            var language = "JavaScript";
            Assert.Equal(10, repo.GetByLanguage(language).Length);
        }

        [Fact]
        public void Get_AllRepositoriesByLanguageUpperCase()
        {
            var repo = new RepositoryService(username);
            var language = "JAVASCRIPT";
            Assert.Equal(10, repo.GetByLanguage(language).Length);
        }
    }
}
