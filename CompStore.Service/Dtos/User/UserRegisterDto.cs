﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{
    public class UserRegisterDto
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        

    }
}
