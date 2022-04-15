using System;
using System.Diagnostics;
using System.Threading;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;


namespace SafeRide.src.Models
{
    public class OTP 
    {
        public string Passphrase { get; set; }

        public Stopwatch Timer { get; set; }

        public bool IsUsed { get; set; }
        public bool IsExpired { get; set; }

        public OTP() {
            Timer = new Stopwatch();
            IsUsed = false;
            IsExpired = false;
            Passphrase = "";
            Generate();
        }

        
        public void Generate() {
            //_otp = "";
            // generate otp with following reqs:
            // min length of 8: 
            Random random = new Random();
            int length = random.Next(8, 21); // max length is 20    
            char current = ' ';
            for (int i = 0; i < length; i++)
            {
                random = new Random();
                // get random val between 0-2 to decide which criteria the current character will be chosen from 
                int criteria = random.Next(0,3);
                // first criteria is uppercase letter between A - Z which corresponds to ASCII values between 65 - 91 
                if (criteria == 0) {
                    current = (char) random.Next(65, 91);
                }
                // second criteria is lowercase letters between a - z which corresponds to ASCII values between 97 - 123
                else if (criteria == 1) {
                    current = (char) random.Next(97, 123);
                }
                // third criteria is numbers 0 - 9 which corresponds to ASCII values between 97 - 123
                else if (criteria == 2) {
                    current = (char) random.Next(48, 58);
                }
                //Console.WriteLine(current);
                Passphrase += current.ToString();
            }
            // start the timer when OTP is generated
            //Console.WriteLine(Passphrase);
            Timer.Start();
            //SendEmail(_generatedOTP);
        }

        // compares a string OTP value provided by the user to this OTP's string value
        public bool Compare(string providedOTP) {
            // find elapsed time since the OTP was generated
            Timer.Stop();
            TimeSpan timespan = Timer.Elapsed;
            // Console.WriteLine("provided: " + providedOTP);
            // Console.WriteLine("actual: " + Passphrase);  
            // Console.WriteLine("Time elapsed since OTP generation" + timespan);  
            
            if (timespan.TotalSeconds > 120) {
                Console.WriteLine("Original OTP has expired, new OTP will be generated and sent out");
                IsExpired = true;   
            }
            return (Passphrase == providedOTP);
        }
    }
}
        
