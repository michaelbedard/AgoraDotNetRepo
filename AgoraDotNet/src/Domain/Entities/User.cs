namespace AgoraDotNet.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        private string PasswordHash { get; set; }
        
        protected User() { }
        
        public User(int id, string username, string passwordHash)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
        }
        
        public bool ValidatePassword(string password)
        {
            // Example validation logic (hashing done elsewhere)
            return PasswordHash == HashPassword(password);
        }
        
        private string HashPassword(string password)
        {
            // Example hash logic; replace with real hash function.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}