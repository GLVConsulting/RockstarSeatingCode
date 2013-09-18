using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace RockstarSeating.Utils
{
	/// <summary>
	/// Illustrates the use of RijndaelEnhanced class to encrypt and decrypt data
	/// using a random salt value.
	/// </summary>
	public class SaltUtility
	{
		RijndaelEnhanced rijndaelKey;
		string plainText = String.Empty;
		string cipherText = String.Empty;
		string errMsg = String.Empty;
		const string _initPassPhrase = "c0ns1gnm3nt";
		const string _initVector = "65e324q8323@4s6#";
		public ArrayList seasonings = new ArrayList();

		public void RijndaelEnhanced() {
		}


		public List<String> runTest()
		{

			initialize();
			plainText = "Hello, World!";

			List<String> ciphers = new List<String>();

			ciphers.Add(String.Format("Plaintext   : {0}\n", plainText));

			// Encrypt the same plain text data 10 time (using the same key,
			// initialization vector, etc) and see the resulting cipher text;
			// encrypted values will be different.
			for (int i = 0; i < 10; i++)
			{
				cipherText = rijndaelKey.Encrypt(plainText);
				ciphers.Add(String.Format("Encrypted #{0}: {1}", i, cipherText));
				plainText = rijndaelKey.Decrypt(cipherText);
			}

			// Make sure we got decryption working correctly.
			ciphers.Add(String.Format("\nDecrypted   :{0}", plainText));

			return ciphers;

		}

		public List<String> getTestCiphers()
		{
			return runTest();
		}


		public string seasonIt(string food, string randPassPhrase = _initPassPhrase, string randVector = _initVector)
		{
			return encryptString(food, randPassPhrase, randVector);
		}
		protected string encryptString(string plainText, string meat, string rice)
		{
			string encryptedString = string.Empty;

			if (isInitialized())
			{
				encryptedString = rijndaelKey.Encrypt(plainText);
				rijndaelKey = null;
				return encryptedString;
			}
			else
			{
				return "fail";
			}
		}



		public string deSeasonIt(string food, string randPassPhrase = _initPassPhrase, string randVector = _initVector)
		{
			return decryptString(food, randPassPhrase, randVector);
		}
		protected string decryptString(string plainText, string meat, string rice)
		{
			string decryptedString = string.Empty;

			if (isInitialized())
			{
				decryptedString = rijndaelKey.Decrypt(plainText);
				rijndaelKey = null;
				return decryptedString;
			}
			else
			{
				return "fail";
			}
		}


		public Boolean isInitialized(Boolean passCredentials = false)
		{
			//need to pass them in on userRegistration
			if (passCredentials && seasonings.Count > 1)
			{
				return initialize(seasonings[0].ToString(), seasonings[1].ToString());
			}
			//otherwise, use the values passed into season/deSeason methods
			return initialize();
		}
		protected Boolean initialize(string meat = "", string rice = "")
		{
			try
			{
                //if meat and rice have values, use those
				if (!string.IsNullOrEmpty(meat) && !string.IsNullOrEmpty(rice))
				{
					rijndaelKey = new RijndaelEnhanced(meat, rice);
				}
				else
				{//use default values from code
					rijndaelKey = new RijndaelEnhanced(_initPassPhrase, _initVector);
				}

				return true;
			}
			catch (Exception ee)
			{
				errMsg = ee.Message.ToString();
				return false;
			}
		}
        

		public string randomString(int stringLen)
		{
			return CreateRandomPassword(stringLen);
		}
		protected static string CreateRandomPassword(int PasswordLength)
		{
			String _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
			Byte[] randomBytes = new Byte[PasswordLength];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(randomBytes);
			char[] chars = new char[PasswordLength];
			int allowedCharCount = _allowedChars.Length;

			for (int i = 0; i < PasswordLength; i++)
			{
				chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
			}

			return new string(chars);
		}

		public static string DoubleSalt()
		{
			string returnVal = String.Empty;

			return returnVal;

		}


	}
}