using BallastLane.Infrastructure.Models.Core;

namespace BallastLane.Infrastructure.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Note>? Notes { get; set; }
    }
}
