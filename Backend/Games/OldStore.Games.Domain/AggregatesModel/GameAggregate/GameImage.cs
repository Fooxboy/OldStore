using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.AggregatesModel.GameAggregate
{
    public class GameImage
    {
        public Uri Url { get; }

        public GameImage(string url)
        {
           Url = new Uri(url);
        }

        public GameImage(Uri url)
        {
            Url = url;
        }
    }
}
