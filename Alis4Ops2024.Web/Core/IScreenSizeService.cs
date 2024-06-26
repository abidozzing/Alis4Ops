// IScreenSizeService.cs
using System;
using System.Threading.Tasks;

namespace Alis4Ops2024.Web.Core // Replace with your actual namespace
{
    public interface IScreenSizeService
    {
        int ScreenWidth { get; }
        int ScreenHeight { get; }

        event EventHandler<ScreenSizeChangedEventArgs> ScreenSizeChanged;

        Task InitializeAsync();

        void Dispose();
    }

    public class ScreenSizeChangedEventArgs : EventArgs
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
