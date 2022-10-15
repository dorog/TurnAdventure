using ConsoleApp.Communication;
using Microsoft.Extensions.DependencyInjection;
using TurnAdventures;
using TurnAdventures.Communication;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            TurnAdventure turnAdventure = SetupGame();
            turnAdventure.Start();
        }

        private static TurnAdventure SetupGame()
        {
            ServiceCollection services = new();

            services.AddSingleton<IUserCommunicator, ConsoleUserCommunicator>();
            services.AddSingleton<TurnAdventure>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetService<TurnAdventure>()!;
        }
    }
}