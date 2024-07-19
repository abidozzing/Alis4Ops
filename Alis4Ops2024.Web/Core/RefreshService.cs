
using Alis4Ops2024.Web.Pages;
using Alis4Ops2024.Web.Models;
using System;
using System.Data;
using Microsoft.JSInterop;

namespace Alis4Ops2024.Web.Core
{
    // RefreshService.cs
    using System;

    public class RefreshService
    {
        public event Action RefreshRequested;

        public void RequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
