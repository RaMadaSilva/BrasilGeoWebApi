using Bogus;



namespace BrasilGeo.Test.Utils
{
    public class FakerPtBr
    {
        public static Faker CreateFaker()
        {
            return new Faker("pt_BR");
        }
    }
}
