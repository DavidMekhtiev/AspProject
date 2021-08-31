using System;
using System.Collections.Generic;

namespace FirstProject.Models
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public DateTime Created { get; set; }

        public List<CenterUser> CenterUsers { get; set; }
    }
}
