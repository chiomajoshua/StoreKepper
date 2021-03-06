﻿using System;

namespace StoreKeeper.Data.DataTransferObject
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Role { get; set; }
        public DateTime DateAdded { get; set; }
    }
}