using EasyValidator.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyApp {
    public class TestBase {

        protected EasyValidatorContext Context { private set; get; }

        public TestBase() {
            Context = BuildContext();
        }

        public EasyValidatorContext BuildContext() {
            var collection = new ServiceCollection();
            collection.AddLogging(builder => {
                builder.AddConsole();
            });

            collection.AddDbContext<EasyValidatorContext>(builder => {
                var c = "Host=localhost;User Id=postgres;Password=1234;Database=DDDD";
                builder.UseNpgsql(c);
            });

            var provider = collection.BuildServiceProvider();
            return provider.GetService<EasyValidatorContext>();
        }
    }
}