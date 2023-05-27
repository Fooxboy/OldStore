using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.AggregatesModel.GameAggregate
{
    public class GameDeveloper
    {
        public string Name { get; }

        public string? Payload { get; }

        public GameDeveloper(string name, string payload = null)
        {
            this.Name = name;

            this.Payload = payload;
        }
    }
}
