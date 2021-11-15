using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudManage1.Models
{
        public class WebRollProvider : RoleProvider //to be used for type in  webconfig
        {
            public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override void AddUsersToRoles(string[] usernames, string[] roleNames)
            {
                throw new NotImplementedException();
            }

            public override void CreateRole(string roleName)
            {
                throw new NotImplementedException();
            }

            public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
            {
                throw new NotImplementedException();
            }

            public override string[] FindUsersInRole(string roleName, string usernameToMatch)
            {
                throw new NotImplementedException();
            }

            public override string[] GetAllRoles()
            {
                throw new NotImplementedException();
            }

            public override string[] GetRolesForUser(string username)
            {
            using (var context = new StudentManagement1Entities())
            {
                var result = (from user in context.signups
                              join map in context.userrollmaps on user.signid equals map.signupid
                              join role in context.rolls on map.rid equals role.id
                              where user.username == username
                              select role.roles).ToArray();

                return result;
            }

        }

        public override string[] GetUsersInRole(string roleName)
            {
                throw new NotImplementedException();
            }

            public override bool IsUserInRole(string username, string roleName)
            {
                throw new NotImplementedException();
            }

            public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
            {
                throw new NotImplementedException();
            }

            public override bool RoleExists(string roleName)
            {
                throw new NotImplementedException();
            }
        }
    }


