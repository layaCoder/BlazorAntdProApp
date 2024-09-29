using System.Threading.Tasks;
using BlazorAntdProApp.Models;
using BlazorAntdProApp.Services;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace BlazorAntdProApp.Pages.User
{
    public partial class Login
    {
        private readonly LoginParamsType _model = new LoginParamsType();

        [Inject] public NavigationManager NavigationManager { get; set; }
        private bool _isLoading = false;
        private string errorMessage = string.Empty;

        public void HandleSubmit()
        {
            if (_model.UserName == "admin" && _model.Password == "admin")
            {
                NavigationManager.NavigateTo("/");
                return;
            }
            else
            {
                _isLoading = !_isLoading;
                errorMessage = "Invalid username or password!";
            }
        }

    }
}