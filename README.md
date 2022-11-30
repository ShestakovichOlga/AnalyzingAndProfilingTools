# AnalyzingAndProfilingTools
Description
Task 1

Here is an example of a method for generating password hash:

public string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{

var iterate = 10000;
var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
byte[] hash = pbkdf2.GetBytes(20);

byte[] hashBytes = new byte[36];
Array.Copy(salt, 0, hashBytes, 0, 16);
Array.Copy(hash, 0, hashBytes, 16, 20);

var passwordHash = Convert.ToBase64String(hashBytes);

return passwordHash;

}

Try to review and optimize the code to improve the performance of the method. Do not reduce iterations’ number.
