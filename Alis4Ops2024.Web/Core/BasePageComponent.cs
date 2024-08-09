namespace Alis4Ops2024.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public abstract class BasePageComponent : ComponentBase
{

    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            // run some JS function(s) here 
            await JSRuntime.InvokeVoidAsync("myNamespace.onLoad.sayHello", "World");
        }
    }
}