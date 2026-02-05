using Services.DomainModel.Security.Composite;

namespace Services.Services
{
    public static class Session
    {
        public static User CurrentUser { get; set; }
    }
}
