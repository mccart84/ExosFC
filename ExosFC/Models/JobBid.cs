using System;
using System.Collections.Generic;

namespace ExosFC.Models
{
    public partial class JobBid
    {
        public JobBid()
        {
            JobRequest = new HashSet<JobRequest>();
        }

        public int Id { get; set; }
        public int FkUserBid { get; set; }
        public decimal PaymentRequested { get; set; }
        public int DaysToComplete { get; set; }
        public int FkJobRequest { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }

        public JobRequest FkJobRequestNavigation { get; set; }
        public User FkUserB { get; set; }
        public ICollection<JobRequest> JobRequest { get; set; }
    }
}
