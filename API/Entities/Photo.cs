using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    { 
        public int Id { get; set; } 
        public string Url { get; set; } 
        public bool IsMain { get; set; }    
        public string PublicId { get; set; }    
        //since the migration gonna create this Appuser column automatically we are adding a prop here just after the deletion of the migration as below
        //This is known as fully defining
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}