namespace MCInfrastructure.Messaging.Requsets
{
    public class IsActiveRequest : ServiceRequestBase
    {
        public bool IsActive { get; set; }
        public IsActiveRequest(bool isActive)
        {
            IsActive = isActive;
        }
        public IsActiveRequest()
        {
            IsActive = true;
        }
    }
}
