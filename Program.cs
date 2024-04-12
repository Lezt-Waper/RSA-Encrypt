using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using test.RSACalculatorLib;
using test.RSALib;

namespace test;
class Program
{
    public static void Main(string[] arg)
    {
        //Demo RSA encrypt
        RSA client = new RSA();
        RSA server = new RSA();

        //The data that client want to send to server
        string origin = "Hello I'm Long Nguyen";
        Console.WriteLine($"The origin data:\n{origin}\n");

        //Client get public key from server. 
        //The public key is the tuple (N, PublicKey)
        client.DestPublicKey = server.PublicKey;
        client.DestN = server.N;

        //Client encrpyt the data
        var encrypstring = client.Encrypt(origin);

        //The data after encrypt
        Console.WriteLine("The data after encrypt and send to server:");
        foreach (var item in encrypstring)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();

        //Server decrypt the data
        string decrypstring = server.Decrypt(encrypstring);

        //The origin data that client want to send
        Console.WriteLine($"\nThe data that server receiver after decrypt:\n{decrypstring}");
    }
}



