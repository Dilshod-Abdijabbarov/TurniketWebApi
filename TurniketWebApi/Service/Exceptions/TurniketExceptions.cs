namespace TurniketWebApi.Service.Exceptions
{
    public class TurniketExceptions : Exception
    {
        public int Code { get; set; }

        public TurniketExceptions(int code,string message):base(message)
        {
            this.Code = code;
        }
    }
}
