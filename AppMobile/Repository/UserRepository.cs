using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMobile.Repository
{
    internal class UserRepository
    {
        static string webAPIKey = "AIzaSyAzM30432YXtdTyqPQ-aruuiNtGuCkWwCA";
        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));

        public async Task<bool> Register(string email, string name, string password)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }

        public async Task<string> SingIn(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";

        }
        public async Task<bool> ResetPassword(string email)
        {
            await authProvider.SendPasswordResetEmailAsync(email);

            return true;

        }
    }
}
