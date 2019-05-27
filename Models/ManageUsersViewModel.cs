using System.Collections.Generic;

namespace Todo_List.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }

        public ApplicationUser[] Everyone { get; set;}
    }
}
