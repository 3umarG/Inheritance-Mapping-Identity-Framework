namespace TPH.DTOs
{
    public class StudentRegisterDto : LoginDto
    {
       

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

       
        public string ConfirmPassword { get; set; }

    }
}
