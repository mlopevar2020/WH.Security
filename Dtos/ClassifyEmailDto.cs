using WH.Common.Dtos.Interfaces;

namespace WH.Common.Dtos
{
    public class ClassifyEmailRequestDto
    {
        public IEnumerable<string> ClassifiedWords { get; set; }
        public string EmailText { get; set; }
    }
    public class ClassifyEmailResponseDto : ITrackableDto
    {
        public bool HasClassifiedWords { get; set; } = false;
        public string EmailText { get; set; }
        public TimeSpan ElapsedTime { get ; set ; }
    }
}