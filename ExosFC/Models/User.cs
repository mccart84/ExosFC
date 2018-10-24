using System;
using System.Collections.Generic;

namespace ExosFC.Models
{
    public partial class User
    {
        public User()
        {
            JobBid = new HashSet<JobBid>();
            JobRequest = new HashSet<JobRequest>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsVerified { get; set; }
        public bool IsAuthorized { get; set; }

        public ICollection<JobBid> JobBid { get; set; }
        public ICollection<JobRequest> JobRequest { get; set; }
    }
}
