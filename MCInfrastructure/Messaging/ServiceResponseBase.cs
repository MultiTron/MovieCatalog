namespace MCInfrastructure.Messaging
{
    public abstract class ServiceResponseBase
    {
        public BussinesStatusCodeEnum StatusCode { get; set; }
        public ServiceResponseBase()
        {
            StatusCode = BussinesStatusCodeEnum.Success;
        }
        public ServiceResponseBase(BussinesStatusCodeEnum statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
