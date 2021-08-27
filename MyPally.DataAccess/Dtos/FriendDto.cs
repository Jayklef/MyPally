using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPally.DataAccess.Dtos
{
    public class FriendDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string CurrentLocation { get; set; }
        public string Tribe { get; set; }
        public string Relationship { get; set; }
    }
}