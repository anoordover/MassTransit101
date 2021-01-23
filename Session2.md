# Session 2

Based on [Session 2](https://youtu.be/97PXJIrGnes?list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C)

# Adding RabbitMQ

In Session 2 Chris Patterson implemented a console app and added a HostedService.
This more or less results in a dotnet worker-service.
I started of using a worker-service.

Because a worker-service uses the same architecture as a webapi project I also
used the MassTransit.AspNetCore package.

1. using worker project `dotnet new worker -n Sample.Service`
1. add new project to solution `dotnet sln add ...`
1. add reference to component project
1. add reference to MassTransit.AspNetCore
1. add reference to MassTransit.RabbitMq   
1. changed Program.cs to start MassTransit

Logging configuration isn't needed when using the worker-service template.
Writing the HostedService isn't needed when using MassTransit.AspNetCore package.
This class is already available in this nuget-package.
