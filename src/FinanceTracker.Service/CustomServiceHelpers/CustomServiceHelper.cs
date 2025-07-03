using System;
using System.Security.Cryptography;
using System.Text;

namespace FinanceTracker.Service.CustomServiceHelpers;

public class CustomServiceHelper
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 10000;
    private const char Delimiter = ';';

    public static string GetHash(int fromLength, int toLength)
    {
        const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^*_-";
        var random = new Random();

        var length = random.Next(fromLength, toLength);
        var chars = new char[length];

        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }

        foreach (char c in chars)
        {
            chars[c] = validChars[random.Next(0, validChars.Length)];
        }

        return new string(chars);
    }

    public static string GenerateOtp(int length = 6)
    {
        var random = new Random();
        var otp = new StringBuilder();
        for (int i = 0; i < length; i++)
            otp.Append(random.Next(0, 10));
        return otp.ToString();
    }

    public static string HashPass (string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: salt,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: KeySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public static bool VerifyPassword(string hashPassword, string inputPassword)
    {
        var elements = inputPassword.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashInput = Rfc2898DeriveBytes.Pbkdf2(
            password: inputPassword,
            salt:  salt,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}
