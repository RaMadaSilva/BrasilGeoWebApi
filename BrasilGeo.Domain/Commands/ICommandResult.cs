namespace BrasilGeo.Domain.Commands.Interfaces
{
    public interface ICommandResult
    {
       bool Success { get; set; }
       string Message { get; set; }
       object Data { get; set; }
    }
}
