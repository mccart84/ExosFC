using System;
using System.Collections.Generic;

namespace ExosFC.Models
{
    public partial class RequestedItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public bool HqOnly { get; set; }
        public int Quantity { get; set; }
        public int FkJobRequest { get; set; }

        public JobRequest FkJobRequestNavigation { get; set; }
    }
}
