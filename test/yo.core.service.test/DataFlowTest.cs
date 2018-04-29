using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace YoVip.Core.Service.Test
{
    using YoVip.Core.Models.Entities;
    [TestClass]
    public class DataFlowTest
    {
        [TestMethod]
        public void WriteDataIntoStream()
        {
            for (var i = 0; i < 10000; i++)
            {
                Shop shop = new Shop()
                {
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
        }
    }
}
