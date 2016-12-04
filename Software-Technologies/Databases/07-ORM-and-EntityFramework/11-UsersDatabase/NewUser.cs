namespace UsersDatabase
{
    using System;
    using System.Linq;
    using System.Transactions;

    /// <summary>
    /// 11. Create a database holding users and groups. Create a transactional EF based method that creates an user and 
    /// puts it in a group "Admins". In case the group "Admins" do not exist, create the group in the same transaction. 
    /// If some of the operations fail (e.g. the username already exist), cancel the entire transaction.
    /// </summary>
    public class NewUser
    {
        public static void Main()
        {
            UserGroupsEntities userGroupEntities = new UserGroupsEntities();

            string user = "Mona";
            string secondUser = "Pipi";

            Console.WriteLine("All groups:");
            var groups =
                (from g in userGroupEntities.Groups
                 select g.GroupName);

            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }

            AddUser(userGroupEntities, user, "Visitors");
            Console.WriteLine("New group created.");
            Console.WriteLine("User added successfully.");

            AddUser(userGroupEntities, secondUser, "Admins");
            Console.WriteLine("User added successfully.");

            //Test with existing user
            //AddUser(userGroupEntities, user, "Admins");     
        }

        public static void AddUser(UserGroupsEntities userGroupEntities, string userName, string groupName)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                var userExists = userGroupEntities.Users.Any(u => u.Username == userName);

                if (userExists)
                {
                    throw new ArgumentException("User already exists.");
                }

                User user = new User()
                {
                    Username = userName
                };

                var groupExists = userGroupEntities.Groups.Any(g => g.GroupName == groupName);

                if (!groupExists)
                {
                    Group newGroup = new Group()
                    {
                        GroupName = groupName
                    };

                    userGroupEntities.Groups.Add(newGroup);
                    userGroupEntities.SaveChanges();

                    user.GroupId = newGroup.GroupId;
                }
                else
                {
                    user.GroupId = userGroupEntities.Groups.FirstOrDefault(g => g.GroupName == groupName).GroupId;
                }

                userGroupEntities.Users.Add(user);
                userGroupEntities.SaveChanges();

                transaction.Complete();
                userGroupEntities.SaveChanges();
            }
        }
    }
}

