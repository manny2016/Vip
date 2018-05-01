using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoVip.Core;
using YoVip.Core.Models.Entities;
using YoVip.Core.Services;

namespace StreamWriteTest
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            for (var i = 1; i < 10000; i++)
            {
                Shop shop = new Shop()
                {
                    Id = i,
                    Name = string.Format("Shop_{0}", i),
                    License = i.ToString("00000"),
                    Address = string.Format("Address_{0}", i),
                    Addition = "{}",
                    Contact = string.Format("Joey_{0}", i),
                    ContactPhone = i.ToString("00000000000"),
                    Coordinate = "{ \"lng\":1.999,\"lat\":20.00}",
                    Description = "Description"
                };
                DataWriteStreamService.Stream.Write(shop);
            }
            Console.WriteLine("Completed in {0}", DateTime.Now.Subtract(dt).TotalSeconds);
            Console.ReadLine();
        }
    }
}
