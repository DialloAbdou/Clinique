namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface IAuthApplication
    {
        /// <summary>
        /// elle permet de recuperer l'id du médecin à partir du token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<int?> GetMedecinIdFromTokenAsync(string token);
    }
}
