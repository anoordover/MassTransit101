# MassTransit101

Based on [MassTransit Youtube](https://youtu.be/dxHNAn69x6w)
and [live coding](https://masstransit-project.com/getting-started/live-coding.html)

## Introduction

When watching these videos I noticed that the result of the different sessions couldn't
be reproduced based on the git-repository.
So I tried to reproduce the end-result of each session.

## Session 1: MassTransit with Mediator

1. New solution `dotnet new sln -n SampleTwitch`
1. New webapi project `dotnet new webapi -n Sample.Api`
1. Add project to solution by executing `dotnet sln ../SampleTwitch.sln add .`
1. Open project in Rider
1. Cleanup all usings in solution
1. Try to run: goto project directory and execute `dotnet run`
1. Goto weatherforecast controller e.g. [weatherforecast](https://localhost:5001/weatherforecast)
1. Stop project and add nuget package `dotnet add package MassTransit.AspNetCore`

We are at [project with ref to masstransit](https://youtu.be/dxHNAn69x6w?list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C&t=314)
Available at tag Session1a in git.

Proceed with:
1. Add services.AddMassTransit in Startup;
1. Add new classlib project for contracts in source folder `dotnet new classlib -n Sample.Contracts -f netstandard2.0`
1. Add project to solution in `dotnet sln add Sample.Contracts`
1. Add interface SubmitOrder
1. Add reference to Contracts project from WebApi e.g. `dotnet add reference ../Sample.Contracts/`
1. Add new classlib project for components named Sample.Components
1. Add new project to solution
1. Add reference to Sample.Contract in Sample.Components
1. Add nuget package to Sample.Components `dotnet add package MassTransit`
1. Add consumer of SubmitOrder named SubmitOrderConsumer
1. Add reference to Sample.Components in Sample.Api
1. During implementation of functionality a package is added to Sample.Api `dotnet add package MassTransit.Analyzers`
this adds code completion help for objects passed to and from MassTransit
1. Same package is added to Sample.Components
1. Adding Mediator in the newest version has been changed, see Startup.cs
1. Adding nswag.aspnetcore to Sample.Api

We are at [First try with swagger](https://youtu.be/dxHNAn69x6w?list=PLx8uyNNs1ri2MBx6BjPum5j9_MMdIfM9C&t=1519)


