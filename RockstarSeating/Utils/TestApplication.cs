using System;
using RockstarSeating.Utils;

namespace HashPassword
{
	class TestApplication
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Generate a new random password string
			string myPassword = Password.CreateRandomPassword(8);

			// Debug output
			Console.WriteLine(myPassword);

			// Generate a new random salt
			int mySalt = Password.CreateRandomSalt();

			// Initialize the Password class with the password and salt
			Password pwd = new Password(myPassword, mySalt);

			// Compute the salted hash
			// NOTE: you store the salt and the salted hash in the datbase
			string strHashedPassword = pwd.ComputeSaltedHash();

			// Debug output
			Console.WriteLine(strHashedPassword);
		}
	}
}
