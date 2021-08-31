using System;
using System.Collections.Generic;


namespace FirstProject.Models
{
    public class CenterUser
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
