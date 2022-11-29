using Microsoft.AspNetCore.Components;
using WH.Common.Dtos;
using WH.UI.Services.Interfaces;
using WH.UI.ViewModels;

namespace WH.UI.Pages
{
    public class ClassifyEmailComponent : ComponentBase
    {
        [Inject]
        ISecurityToolBoxService _securityToolBoxService { get; set; }

        protected override async Task OnInitializedAsync()
        {
        }

        protected async Task<ClassifyEmailVm> ClassifyEmail(ClassifyEmailVm vm)
        {
            var dto = new ClassifyEmailRequestDto() 
            {
                ClassifiedWords = vm.ClassifiedWords,
                EmailText = vm.EmailText,
            };

            var res = await _securityToolBoxService.ClassifyEmail(dto);

            if(res.HasClassifiedWords)
                vm.EmailText = dto.EmailText;

            return vm;
        }

    }
}
