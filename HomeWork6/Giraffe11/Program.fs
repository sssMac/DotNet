module Giraffe11.App


open System
open System.IO
open Giraffe11
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Giraffe11.Input
open Giraffe11.Parser
open Giraffe11.Calculator

type MaybeBuilder() =
    member b.Bind(x, foo) =
        match x with
        | Ok y -> foo y
        | Error n -> Error n
    member b.Return x = Ok x
let maybe = MaybeBuilder()

let CalculatorHandler:HttpHandler =
    fun next ctx ->
        let res = maybe{
            let! problem = ctx.TryBindQueryString<Input>()
            let! operation = Parser.TryParseOperationInput problem
            let result = Calculator.Calculate problem.v1 operation problem.v2
            return result
        }     
        match res with
        | Ok v ->
            (setStatusCode 200 >=> json v) next ctx 
        | Error v ->
            (setStatusCode 400 >=> json v) next ctx
    
let webApp =
    choose [
        route "/ping" >=> text "pong"
        route "/calculate" >=> CalculatorHandler
        setStatusCode 404 >=> text "Not found"]
     

type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder)
                        (env : IHostEnvironment)
                        (loggerFactory : ILoggerFactory) =
        app.UseGiraffe webApp
        app.Use |> ignore

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(
            fun webHostBuilder ->
                webHostBuilder
                    .UseStartup<Startup>()
                    |> ignore)
        .Build()
        .Run()
    0