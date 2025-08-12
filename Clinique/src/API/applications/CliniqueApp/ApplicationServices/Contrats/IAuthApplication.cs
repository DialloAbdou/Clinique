namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface IAuthApplication
    {
        public Task<int?> GetMedecinIdFromTokenAsync(string token);
    }
}
