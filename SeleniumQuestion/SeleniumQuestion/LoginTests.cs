using NUnit.Framework;
using System;

namespace SeleniumQuestion
{
    public class LoginTests : Setup, IDisposable
    {
        // driver is a fully set up ChromeDriver with the correct URL.
        // This will reset each run to the home page of the AUT.

        [Test]
        public void Title_IsCorrect()
        {
            Assert.AreEqual(driver.Title, "Test Me");
        }
    }
}