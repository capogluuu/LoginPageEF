﻿using System.ComponentModel.DataAnnotations;


namespace LoginPage.Models
{
    public class Login
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gsm { get; set; }
        public string adress { get; set; }
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public string status { get; set; }
    }
}
