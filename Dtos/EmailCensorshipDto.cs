using WH.Common.Dtos.Interfaces;

namespace WH.Common.Dtos
{
    public class EmailCensorshipRequestDto
    {
        public IEnumerable<string> ClassifiedWords { get; set; }
        public string EmailText { get; set; }
    }
    public class EmailCensorshipResponseDto : ITrackableDto
    {
        public bool HasClassifiedWords { get; set; } = false;
        public String EmailText { get; set; }
        public TimeSpan ElapsedTime { get ; set ; }
    }
}