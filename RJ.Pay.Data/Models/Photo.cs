using System.ComponentModel.DataAnnotations;

namespace RJ.Pay.Data.Models
{
    public class Photo : BaseEntity<string>
    {
        public Photo()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
        [Required]
        public string Url { get; set; }
        public string Description { get; set; }
        public string Alt { get; set; }
        [Required]
        public bool IsMain { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}