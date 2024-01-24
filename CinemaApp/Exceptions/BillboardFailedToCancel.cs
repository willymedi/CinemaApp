namespace CinemaApp.Exceptions
{
    public class BillboardFailedToCancel : Exception
    {
        public BillboardFailedToCancel()
        {

        }

        public BillboardFailedToCancel(string message) : base(message) { }

        public BillboardFailedToCancel(string message, 
            Exception inner) : base(message, inner) { }
    }
}
