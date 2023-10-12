namespace BrasilGeo.Domain.Commands.Interfaces
{
    public interface ICommandResult
    {
       bool Sucess { get; set; }
       string Mensage { get; set; }
       object Data { get; set; }
    }
}
