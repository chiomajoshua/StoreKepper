using System;
using System.ComponentModel.DataAnnotations;

namespace StoreKeeper.Data.DbModel
{
    public class User
    {
        public Guid Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Role { get; set; }
        public DateTime DateAdded { get; set; }
    }
}