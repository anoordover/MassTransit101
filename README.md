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

