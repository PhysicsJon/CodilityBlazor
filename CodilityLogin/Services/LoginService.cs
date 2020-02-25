using CodilityLogin.Interfaces;
using CodilityLogin.Models;
using System;
using System.Text.RegularExpressions;

namespace CodilityLogin.Services
{
    public class LoginService : ILoginService
    {
        public (string ClassNames, string AlertText) CheckCredentials(User user)
        {
            string ClassNames;
            string AlertText;

            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                ClassNames = "alert-danger";
                AlertText = "Please provide both username and password";
            }
            else if (!VerifyEmail(user.Email))
            {
                ClassNames = "alert-danger";
                AlertText = "Email is not in a valid format";
            }
            else if (user.Email != "interviewee@bjss.com" || user.Password != "Test123")
            {
                ClassNames = "alert-danger";
                AlertText = "Invalid username/password";
            }
            else
            {
                ClassNames = "alert-success";
                AlertText = "Welcome to BJSS";
            }

            return (ClassNames, AlertText);
        }

        private bool VerifyEmail(string emailToCheck)
        {
            return Regex.IsMatch(emailToCheck,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
