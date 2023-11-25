using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using Microsoft.AspNetCore.Mvc;
using BlazorMinimalApis.Lib.Views;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public interface IContactsTablePartialViewModel : IXViewModel
{
    List<Contact> Contacts { get; set; }
	Task Initialize(string contactSearch);
}

public class ContactsTablePartialViewModel : XPage, IContactsTablePartialViewModel
{
    public List<Contact> Contacts { get; set; }

    public async Task Initialize(string contactSearch)
    {
        Contacts = Database.Contacts
                    .Where(x => x.Name.Contains(contactSearch ?? "", StringComparison.OrdinalIgnoreCase))
                    .ToList();

        await Task.CompletedTask;
    }

    public override void Map(WebApplication app)
	{
        app.MapGet("/contacts/search", async ([FromQuery] string ContactSearch, [FromServices] IContactsTablePartialViewModel VM) => 
        {
            await VM.Initialize(ContactSearch);
            return Page<ContactsTablePartial>();
        })
        .WithName("Contacts.Search");
    }
}