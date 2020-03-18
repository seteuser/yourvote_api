using System;

namespace BrilhaMuito.Domain.Account.Entities
{
    public class Image
    {
        public Guid ImageId { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }
    }
}