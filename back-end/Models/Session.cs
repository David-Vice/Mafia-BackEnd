﻿using System;
using System.Collections.Generic;

#nullable disable

namespace back_end.Models
{
    public partial class Session
    {
        public Session()
        {
            GameSessionUsers = new HashSet<GameSessionUser>();
        }

        public int Id { get; set; }
        public string SessionDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<GameSessionUser> GameSessionUsers { get; set; }
    }
}
