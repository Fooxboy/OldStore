using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Services
{
    public class IdGeneratorService
    {

        private readonly DateTime start = new DateTime(2019, 1, 1);
        private static readonly Random Random = new Random();


        public IdGeneratorService()
        {
        }


        public int GetId()
        {
            int id = 0;

            using var ms = new MemoryStream();

            var timestamp = (int)(DateTime.UtcNow - start).TotalSeconds / 900 << 10; // 21 bit

            var rnd = Random.Next(0, 1387545023);

            id += timestamp;
            id += rnd;

            return id;
        }
    }
}
