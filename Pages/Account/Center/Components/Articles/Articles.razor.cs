using System.Collections.Generic;
using BlazorAntdProApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAntdProApp.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}