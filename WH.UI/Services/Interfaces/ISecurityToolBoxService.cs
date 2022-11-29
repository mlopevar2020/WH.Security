using WH.Common.Dtos;

namespace WH.UI.Services.Interfaces
{
    public interface ISecurityToolBoxService
    {
        Task<ClassifyEmailResponseDto> ClassifyEmail(ClassifyEmailRequestDto req);
    }
}
