﻿namespace Services.Dtos
{
    public class UserDto
    {
        public Guid ID_User { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;

        
    }
}
