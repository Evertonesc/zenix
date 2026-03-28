namespace Zenix.Api

#nowarn "20"

open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0
    
    let webApp =
        choose [
            route "/ping" >=> text "pong"
        ]
        
    let configureApp (app: IApplicationBuilder) =
        app.UseGiraffe webApp
        
    let configureServices(services: IServiceCollection) =
        services.AddGiraffe() |> ignore

    [<EntryPoint>]
    let main args =
        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .Configure(configureApp)
                        .ConfigureServices(configureServices)
                        |> ignore)
            .Build()
            .Run()
        exitCode