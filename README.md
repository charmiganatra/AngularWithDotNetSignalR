# AngularWithDotNetSignalR
We will see how to create hub here step by step:
1.	Create web application in dotnet core. 
2.	you have to install ‘Microsoft.AspNetCore.SignalR’ from NuGet.
3.	Now we need to introduce two new middle-wares to Startup.cs. Open your Startup.cs file and locate ConfigureServices method. Add below code ‘services.AddSignalR();’ segment before services.AddMvc();
4.	Here we are adding Cross-origin policy to accept request from localshot:4200 and then we tell to use SignalR.
5.	Now locate Configure method in the same Startup.cs class and add below code before app.UserMvc();
app.UseCors("CorsPolicy");
app.UseSignalR(routes =>
{
  routes.MapHub<NotifyHub>("notify");
});
6.	Create hub named as ‘notify’ and we are calling BroadcastMessage method that we defined in our ITypedHubClient interface. When we do that it will send the message to all connected clients.
7.	Here we are adding SignalR route to the api. In this way we can connect the clients by adding <hostedurl>:<port>/notify (eg: http://bloodgroupsampleapp.azurewebsites.net/notify) in the client application.

