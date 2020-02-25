using CodilityLogin.Models;
using CodilityLogin.Services;
using FluentAssertions;
using Xunit;

namespace CodilityLogin.Tests.Services
{
    public sealed class LoginServiceTests
    {
        [Theory]
        [InlineData("", "", "alert-danger", "Please provide both username and password")]
        [InlineData(null, null, "alert-danger", "Please provide both username and password")]
        [InlineData("sfafa", "Test123", "alert-danger", "Email is not in a valid format")]
        [InlineData("jhfgjk.hf@test.com", "Test123", "alert-danger", "Invalid username/password")]
        [InlineData("interviewee@bjss.com", "Test1234", "alert-danger", "Invalid username/password")]
        [InlineData("interviewee@bjss.com", "Test123", "alert-success", "Welcome to BJSS")]
        public void CheckCredentials(string email, string password, string expectedClass, string expectedMessage)
        {
            var user = new User { Email = email, Password = password };
            var loginService = new LoginService();

            var result = loginService.CheckCredentials(user);

            result.Should().Be((expectedClass, expectedMessage));
        }
    }
}
