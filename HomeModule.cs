namespace aspnet5nancybridge
{
    using Nancy;

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hi";
            Get["/signin"] = _ => 401; //Should this be 302? In MVC this is where it does a challenge result
            Get["/signin-twitter"] = _ => "twitter authd";
        }
    }
}
