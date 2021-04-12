using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamous.Models
{
    public static class Policy
    {
        //Stuff that will get passed to the startup class to define the roles in each policy
        public static IEnumerable<string> GetWriteRoles(PolicyRolesDbContext context)
        {
            var contextRoles = context.WriteRoles;
            List<string> writeRoles = new List<string>();
            foreach (var role in contextRoles)
            {
                writeRoles.Add(role.Role);
            }
            return writeRoles;
        }

        public static IEnumerable<string> GetDeleteRoles(PolicyRolesDbContext context)
        {
            var contextRoles = context.DeleteRoles;
            List<string> deleteRoles = new List<string>();
            foreach (var role in contextRoles)
            {
                deleteRoles.Add(role.Role);
            }
            return deleteRoles;
        }

        public static bool IsInWriteRole(IList<string> roles, PolicyRolesDbContext context)
        {
            bool inList = false;
            IEnumerable<string> WriteRoles = GetWriteRoles(context);
            foreach(var role in roles)
            {
                var result = WriteRoles.Contains(role);
                if (result)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }

        public static bool IsInDeleteRole(IList<string> roles, PolicyRolesDbContext context)
        {
            bool inList = false;
            IEnumerable<string> DeleteRoles = GetDeleteRoles(context);
            foreach (var role in roles)
            {
                var result = DeleteRoles.Contains(role);
                if (result)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }
    }
}
