using FalcoMvc;

namespace FalcoMvc
{
    public static class IdentityConfig
    {
        public static void RegisterIdentities()
        {
            // Ensures the Seed of Users and Roles that we need 
            UserManager.Seed();
        }
    }
}