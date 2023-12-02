// User.cs in the Data folder

using System.Collections.Generic;

namespace FinalFN.Data
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<int> OwnedSkinIds { get; set; }
    }
}