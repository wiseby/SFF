namespace Application.RentService
{
    public class ReturnRequest
    {
        public int StudioId { get; set; }
        public int[] MovieId { get; set; }
    }
}