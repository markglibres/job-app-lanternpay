namespace Lantern.Api.Application.Lectures.ResponseModels
{
    public class LectureResponseModel
    {
        public string Id { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public LectureTheatreResponseModel LectureTheatre { get; set; }
    }
}