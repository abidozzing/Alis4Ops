using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Alis4Ops2024.Web.Core
{
    public abstract class BasePageComponent : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        // Method to be called from JavaScript
        [JSInvokable]
        public async Task NotifyInitializationComplete()
        {
            try
            {
                await JSRuntime.InvokeVoidAsync("myNamespace.onLoad.sayHello", "World");
            }
            catch (JSException jsEx)
            {
                Console.Error.WriteLine($"JavaScript error: {jsEx.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
