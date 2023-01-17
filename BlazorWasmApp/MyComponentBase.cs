using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorWasmApp
{
    public class MyComponentBase : ComponentBase
    {
        [Inject]
        public Events Events { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Events.LanguageChanged += (_, lang) => StateHasChanged();
            }
        }
    }
}