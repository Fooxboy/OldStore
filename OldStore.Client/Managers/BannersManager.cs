using OldStore.Shared.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Client.Managers
{
    public static class BannersManager
    {
        public delegate void BannerOpened(Banner banner);

        public static event BannerOpened BannerOpenedEvent;

        public static void Invoke(Banner banner)
        {
            BannerOpenedEvent?.Invoke(banner);
        }
    }
}
