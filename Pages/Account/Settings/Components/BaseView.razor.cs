using System.Threading.Tasks;
using BlazorAntdProApp.Models;
using BlazorAntdProApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorAntdProApp.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}