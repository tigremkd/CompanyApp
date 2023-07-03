namespace WebApi.Utility.Exceptions
{
    public class NotFoundException : Exception
    {
        public int? Id { get; init; }


        public NotFoundException(string message) : base(message)
        {

        }


        public NotFoundException(int? id) : base($"The record with id {nameof(id)} you are looking for does not exist")
        {
            Id = id;


        }
    }
}
