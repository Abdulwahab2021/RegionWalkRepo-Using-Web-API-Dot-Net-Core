﻿using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
