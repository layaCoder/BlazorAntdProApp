using AntDesign.Extensions.Localization;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAntdProApp.Layouts
{
   

    public partial class CustomizeLayout:LayoutComponentBase
    {
        private MenuDataItem[] _menuData =[];
        [Inject] private HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            _menuData = await HttpClient.GetFromJsonAsync<MenuDataItem[]>("data/menu.json");

        }
    }
}
