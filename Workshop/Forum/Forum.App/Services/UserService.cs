using System.Linq;
using Forum.App.Controllers;
using Forum.Data;
using Forum.Models;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }
        public static User GetUser(string username)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Username == username);

            return user;
        }
        public static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();

            User user = forumData.Users.Find(u => u.Id == userId);

            return user;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumdata = new ForumData();

            bool userAlreadyExists = forumdata.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = forumdata.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password);
                forumdata.Users.Add(user);
                forumdata.SaveChanges();

                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }
    }
}