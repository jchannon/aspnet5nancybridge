namespace aspnet5nancybridge
{
    using System;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.OnError += LogError;
        }

        private Response LogError(NancyContext ctx, Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }
}
