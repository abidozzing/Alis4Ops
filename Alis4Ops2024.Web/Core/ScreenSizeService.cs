// ScreenSizeService.cs
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Alis4Ops2024.Web.Core // Replace with your actual namespace
{
    public class ScreenSizeService : IScreenSizeService, IDisposable
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public event EventHandler<ScreenSizeChangedEventArgs> ScreenSizeChanged;

        private readonly IJSRuntime _jsRuntime;
        private readonly string _jsFunctionName = "window.registerResizeListener";

        public ScreenSizeService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            await _jsRuntime.InvokeVoidAsync(_jsFunctionName, DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void UpdateScreenSize(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
            ScreenSizeChanged?.Invoke(this, new ScreenSizeChangedEventArgs { Width = width, Height = height });
        }

        public void Dispose()
        {
            // Cleanup if needed
        }
    }
}
