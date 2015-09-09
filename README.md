# aspnet5nancybridge

This app/repo is trying to use AspNet5 middleware with Nancy that runs as Owin middleware.

When this app is run and a request is made to `/signin` it returns 500 status code and the logging reports `warning : [Microsoft.AspNet.Authentication.Twitter.TwitterAuthenticationMiddleware] Invalid state`

The `500` comes from something in AspNet5 I believe as nothing is logged to console when `/signin` is called but does when `/error` is called.
