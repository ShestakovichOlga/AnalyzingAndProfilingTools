using System.Security.Cryptography;
using System.Text;

var password = "1234ty";
var salt = "000n84ekur000efh";
var saltBytes = Encoding.Default.GetBytes(salt);

//Diagnostic tool: Breakpoints + Event and Duration
var hash = GeneratePasswordHashUsingSaltOptimized(password, saltBytes);
var hash2 = GeneratePasswordHashUsingSalt(password, saltBytes);

// Method BlockCopy in Buffer class works faster, because copies memory not by bytes, but by blocks. 
string GeneratePasswordHashUsingSaltOptimized(string passwordText, byte[] salt)
{
    var iterate = 10000;
    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
    Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);

    return Convert.ToBase64String(hashBytes);
}

string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{
    var iterate = 10000;
    var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    Array.Copy(salt, 0, hashBytes, 0, 16);
    Array.Copy(hash, 0, hashBytes, 16, 20);

    return Convert.ToBase64String(hashBytes);
}
