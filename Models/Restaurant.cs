using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set;}
        [Required]
        [MaxLength(100)]
        public string Name { get; set;}
        [Required]
        [MaxLength(100)]
        public string Location { get; set;}

        public virtual List<Rating> Ratings { get; set;} = new List<Rating>();

        public double AverageScore
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }
                double total = 0.0;
                foreach (Rating score in Ratings)
                {
                    total+= score.Score;
                }
                return total / Ratings.Count;
            }
        }
    }
}