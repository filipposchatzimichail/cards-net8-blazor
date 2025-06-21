using Logicea.Cards.Business.Interfaces;
using Logicea.Cards.DataAccess.Models;
using Microsoft.AspNetCore.SignalR;

namespace Logicea.Cards.Business.Services;

public class CardService : CrudService<Card>, ICardService
{
    private readonly IHubContext<CardHub> _hubContext;

    public CardService(ApplicationDbContext context, IHubContext<CardHub> hubContext) : base(context)
    {
        _hubContext = hubContext;
    }


    public override async Task<bool> AddAsync(Card item)
    {
        var result = await base.AddAsync(item);
        if (result)
        {
            await _hubContext.Clients.All.SendAsync("CardAdded", item);
        }
        return result;
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        var card = await GetByIdAsync(id);
        if (card == null) return false;
        var result = await base.DeleteAsync(id);
        if (result)
        {
            await _hubContext.Clients.All.SendAsync("CardDeleted", card);
        }
        return result;
    }

    public override async Task<bool> UpdateAsync(Card item)
    {
        var result = await base.UpdateAsync(item);
        if (result)
        {
            await _hubContext.Clients.All.SendAsync("CardUpdated", item);
        }

        return result;
    }
}
