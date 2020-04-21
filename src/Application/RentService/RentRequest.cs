namespace Application.RentService
{
    public class RentRequest
    {
        public int StudioId { get; set; }
        public int[] MovieId { get; set; }
    }
}