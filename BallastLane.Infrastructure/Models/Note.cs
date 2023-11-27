using BallastLane.Infrastructure.Models.Core;

namespace BallastLane.Infrastructure.Models
{
    public class Note : BaseModel
    {

        /// <summary>
        /// The user id to which this note belongs.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The title of the Note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The Text.
        /// </summary>
        public string Text { get; set; }
    }
}
