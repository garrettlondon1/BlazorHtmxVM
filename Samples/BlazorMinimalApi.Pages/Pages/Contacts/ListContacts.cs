using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;
using BlazorMinimalApis.Lib.Views;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class ListContacts : XPage
{
	public override void Map(WebApplication app)
	{
		app.MapGet("/contacts", List)
        .WithName("Contacts");
    }
	
	public async Task<IResult> List(HttpContext context, IContactsTablePartialViewModel VM)
	{
		await VM.Initialize("");
		return Page<ListContactsPage>();
	}
}