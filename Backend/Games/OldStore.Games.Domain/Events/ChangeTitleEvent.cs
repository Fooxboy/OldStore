using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Domain.Events
{
    public class ChangeTitleEvent : INotification
    {
        public int GameId { get; }

        public string OldTitle { get; }

        public string NewTitle { get; }

        public ChangeTitleEvent(int gameId, string oldTitle, string newTitle)
        {
            this.GameId = gameId;
            this.OldTitle = oldTitle;
            this.NewTitle = newTitle;
        }

    }
}
