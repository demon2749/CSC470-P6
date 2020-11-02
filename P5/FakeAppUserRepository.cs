﻿using System.Collections.Generic;

namespace P6
{
    public class FakeAppUserRepository : IAppUserRepository
    {
        private static Dictionary<string, AppUser> _AppUsers;

        public FakeAppUserRepository()
        {
            // A temporary dictionary to fake a database
            _AppUsers = new Dictionary<string, AppUser>();
            _AppUsers.Add("DSU", new AppUser
            {
                UserName = "DSU",
                Password = "Password1!",
                FirstName = "Dakota State",
                LastName = "University",
                EmailAddress = "email@dsu.edu",
                IsAuthenticated = false
            });
        }
        public bool Login(string UserName, string givenPassword)
        {
            bool match = false;
            AppUser appUser;
            if (_AppUsers.TryGetValue(UserName,out appUser))
            {
                match = appUser.Password == givenPassword;
            }
            return match;
        }
        public void SetAuthentication(string UserName, bool IsAuthenticated)
        {
            _AppUsers[UserName].IsAuthenticated = IsAuthenticated;
        }
        public List<AppUser> GetAll()
        {
            List<AppUser> appUsers = new List<AppUser>();
            foreach (AppUser appUser in _AppUsers.Values)
            {
                appUsers.Add(appUser);
            }
            return appUsers;
        }
        public AppUser GetByUserName(string UserName)
        {
            AppUser curUser;
            try
            {
                curUser = _AppUsers[UserName];
            }
            catch
            {
                curUser = null;
            }
            return curUser;
        }
    }
}
