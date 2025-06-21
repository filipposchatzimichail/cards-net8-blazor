using Microsoft.AspNetCore.SignalR;

namespace Logicea.Cards.Business
{
    public class CardHub : Hub
    {
        public async Task BroadcastNewCard(string cardId)
        {
            await Clients.All.SendAsync("CardAdded", cardId);
        }

        public async Task BroadcastDeleteCard(string cardId)
        {
            await Clients.All.SendAsync("CardDeleted", cardId);
        }

        public async Task BroadcastUpdateCard(string cardId)
        {
            await Clients.All.SendAsync("CardUpdated", cardId);
        }
    }
}
