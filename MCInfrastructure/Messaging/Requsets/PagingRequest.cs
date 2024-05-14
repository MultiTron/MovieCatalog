namespace MCInfrastructure.Messaging.Requsets
{
    public class PagingRequest : ServiceRequestBase
    {
        public int ElementsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public PagingRequest()
        {
            ElementsPerPage = int.MaxValue;
            CurrentPage = 1;
        }
        public PagingRequest(int currentPage, int elementsPerPage)
        {
            CurrentPage = currentPage;
            ElementsPerPage = elementsPerPage;
        }
    }
}
