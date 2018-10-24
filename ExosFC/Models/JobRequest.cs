using System;
using System.Collections.Generic;

namespace ExosFC.Models
{
    public partial class JobRequest
    {
        public JobRequest()
        {
            JobBid = new HashSet<JobBid>();
            RequestedItem = new HashSet<RequestedItem>();
        }

        public int Id { get; set; }
        public int FkUserPosted { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public bool? IsActive { get; set; }
        public bool IsPending { get; set; }
        public int? FkBidAccepted { get; set; }

        public JobBid FkBidAcceptedNavigation { get; set; }
        public User FkUserPostedNavigation { get; set; }
        public ICollection<JobBid> JobBid { get; set; }
        public ICollection<RequestedItem> RequestedItem { get; set; }
    }
}
