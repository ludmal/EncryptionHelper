using System;
using EncryptionHelper;

namespace EncryptionTests
{
    public class Customer
    {
        [Encrypted]
        public string Mobile { get; set; }

        public string Name { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var customer = new Customer
            {
                Mobile = "078388348",
                Name = "Ludmal de silva"
            };

            Console.WriteLine(customer.Mobile);
        }
    }
}