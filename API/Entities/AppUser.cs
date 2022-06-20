namespace API.Entities
{
    public class AppUser
    {
        //When we return appUser we are returning all including passwords that's why we use DTOs to hide some of em
        public int Id { get; set; }
        public String UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //Propfull
        // private int myVar;
        // public int MyProperty
        // {
        //     get { return myVar; }
        //     set { myVar = value; }
        // }
        
    }
}