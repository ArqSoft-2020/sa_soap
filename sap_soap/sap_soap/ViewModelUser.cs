using System;

namespace sap_soap
{
    public class ViewModelUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Country { get; set; }
        public string Picture { get; set; }
        public byte[] ImageBytes { get; set; }
        public int TotalGames { get; set; }
        public int WonGames { get; set; }
        public int LostGames { get; set; }
    }
}