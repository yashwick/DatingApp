using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        //When we return appUser we are returning all including passwords that's why we use DTOs to hide some of em
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }         
        public string Introduction { get; set; }    
        public string LookingFor { get; set; }  
        public string Interests { get; set; }   
        public string City { get; set; }
        public string Country { get; set; } 
        public  ICollection<Photo>Photos { get; set; }
        public int GetAge(){
            return DateOfBirth.CalculateAge();
        }

        //Propfull
        // private int myVar;
        // public int MyProperty
        // {
        //     get { return myVar; }
        //     set { myVar = value; }
        // }

    }
}