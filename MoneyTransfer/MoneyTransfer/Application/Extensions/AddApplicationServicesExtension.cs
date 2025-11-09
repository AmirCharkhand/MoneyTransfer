namespace MoneyTransfer.Application.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddRepositories()
                .AddUseCases();
        }
    }
}
