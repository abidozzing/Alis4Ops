
using Alis4Ops2024.Web.Pages;
using Alis4Ops2024.Web.Models;
using System;
using System.Data;
using Microsoft.JSInterop;

namespace Alis4Ops2024.Web.Core
{
    using System;

    public class RefreshService
    {
        public event Action? RefreshRequested;

        public void RequestRefresh()
        {
            // Invoke RefreshRequested event immediately when RequestRefresh() is called
            OnRefreshRequested();
        }

        private void OnRefreshRequested()
        {
            RefreshRequested?.Invoke();
        }
    }
}

