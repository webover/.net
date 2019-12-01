namespace LinqAndLamdaExpressions
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.

            /*foreach (User user in allUsers)
            {
                var CountPost = (from post in allPosts where post.UserId == user.Id select post).Count();

                Console.WriteLine($"{user.Name} has  {CountPost} number of post");
            }*/

            var results = allPosts.GroupBy(p => p.UserId).Select(g => new { UserId = g.Key, NumberOfPost = g.Count() });

            foreach (var result in results)
            {
                Console.WriteLine($"{result.UserId} has  {result.NumberOfPost} number of post");
            }

            // 4 - find all users that have lat and long negative.

            List<User> listUsers = (from user in allUsers where user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0 select user).ToList();

            // 5 - find the post with longest body.

            Post longestBodyPost = allPosts.OrderByDescending(post => post.Body.Length).First();

            // 6 - print the name of the employee that have post with longest body.

            User userEmployee = allUsers.Where(u => u.Id == longestBodyPost.UserId).First();

            Console.WriteLine($"Employee {userEmployee.Name} has the longest post");

            // 7 - select all addresses in a new List<Address>. print the list.

            List<Address> addressesList = allUsers.Select(u => u.Address).ToList();

            // 8 - print the user with min lat

            var lowestLatValue = allUsers.Min(u => u.Address.Geo.Lat);
            User userMinLat = allUsers.Where(u => u.Address.Geo.Lat == lowestLatValue).First();

            Console.WriteLine($"User {userMinLat.Name} has the Address with the lowest latitude");

            // 9 - print the user with max long

            var highestLongValue = allUsers.Max(u => u.Address.Geo.Lng);
            User userMaxLong = allUsers.Where(u => u.Address.Geo.Lng == highestLongValue).First();

            Console.WriteLine($"User {userMinLat.Name} has the Address with the lowest latitude");

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only

            List<UserPosts> userPosts = new List<UserPosts>();

            foreach (User user in allUsers)
            {
                userPosts.Add(new UserPosts() { User = user, Posts = allPosts.Where(p => p.UserId == user.Id).ToList() });
            }

            // 11 - order users by zip code

            Console.WriteLine($"Before Ordering");

            foreach (User user in allUsers)
            {
                Console.WriteLine($"---- {user.Username} {user.Address.Zipcode}");
            }

            Console.WriteLine($"Ordering by ZIP");

            List<User> usersOrderedByZip = allUsers.OrderBy(u => u.Address.Zipcode).ToList();

            foreach (User user in usersOrderedByZip)
            {
                Console.WriteLine($"++++ {user.Username} {user.Address.Zipcode}");
            }

            // 12 - order users by number of posts

            Console.WriteLine($"Ordering Descending by Number of Posts");

            List<User> usersOrderedByPost = allUsers.OrderByDescending(u => allPosts.Where(p => p.UserId == u.Id).Count()).ToList();

            foreach (User user in usersOrderedByPost)
            {
                Console.WriteLine($"**** {user.Username} {allPosts.Where(p => p.UserId == user.Id).Count()}");
            }
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
