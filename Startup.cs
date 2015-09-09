
namespace Twock
{
    using Microsoft.AspNet.Authentication;
    using Microsoft.AspNet.Authentication.Cookies;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;
    using Nancy.Owin;

    public class Startup
    {
        private const string TWITTERCONSUMERKEY = "EKC5L16edV5gBgnPjbuAAsWkb";
        private const string TWITTERSECRET = "I5CwN0kIcttZI6xiSsq9APDyaMMZaauxTd2Ho4oux1Jf7McE2o";

        public void Configure(IApplicationBuilder app)
        {
            var factory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            factory.AddConsole();

            app.UseCookieAuthentication(options => {
                options.AutomaticAuthentication = true;
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.LoginPath = new PathString("/signin");
            });

            app.UseTwitterAuthentication( configureOptions =>
            {
                configureOptions.ConsumerKey = TWITTERCONSUMERKEY;
                configureOptions.ConsumerSecret = TWITTERSECRET;
                configureOptions.AutomaticAuthentication = true;
                configureOptions.AuthenticationScheme = "Twitter";
            });

            app.UseOwin(x => x.UseNancy());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();

            services.Configure<SharedAuthenticationOptions>(options => {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            });
        }
    }
}
