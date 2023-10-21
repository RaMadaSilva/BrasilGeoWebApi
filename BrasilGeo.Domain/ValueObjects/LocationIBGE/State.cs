namespace BrasilGeo.Domain.ValueObjects.LocationIBGE
{
    public class State
    {
        public string Uf { get; set; }

        public State(string uf)
        {
            if (string.IsNullOrEmpty(uf))
                throw new Exception("UF inválido");

            Uf = uf.Trim().ToUpper();

            if (Uf.Length > 2 || Uf.Length < 2)
                throw new Exception("UF invalido");
        }

        public static implicit operator State(string uf) {  return new State(uf); }
        public static implicit operator string(State state) {  return state.ToString(); }
    }
}
