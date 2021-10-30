
using System.ComponentModel.DataAnnotations;

namespace LoginPage.Models
{
    public class Table
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Gsm { get; set; }
        private string Adress { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Status { get; set; }

        public Table() { }
        public Table(string _name, string _surname, string _gsm, string _adress, 
                    string _username, string _password, string _status)
        {
            Name = _name;
            Surname = _surname;
            Gsm = _gsm;
            Adress = _adress;
            Username = _username;
            Password = _password;
            Status = _status;
        }


        public string name { get { return Name; } set { Name = value; } }
        public string surname { get { return Surname; } set { Surname = value; } }
        public string gsm { get { return Gsm; } set { Gsm = value; } }
        public string adress { get { return Adress; } set { Adress = value; } }
        [Key]
        public string username { get { return Username; } set { Username = value; } }
        public string password { get { return Password; } set { Password = value; } }
        public string status { get { return Status; } set { Status = value; } }
    }
}