# AGLDeveloperTest
http://agl-developer-test.azurewebsites.net/

Built using ".NET Core 2.2 SDK - Windows x64 Installer (v2.2.104)"

Please use the following link to download latest SDK 2.2, otherwise the solution will not build:
    https://dotnet.microsoft.com/download/dotnet-core/2.2

NOTE to reviewer:
   Some summary notes have been written as a discussion reasoning behind classes.
   Because of the layering the application got bigger so I didn't write comments for everything

Architecture:

    Models 
    Core
    Business
    Services

    ConsoleTester
    XUnitTests

    Basic Onion architecture:
        Models -> Core -> Business -> Services

ConsoleTester:

    Consumes an OwnerService that return IList of objects.
    Use one of the console formatters to display the data the way you like.
    For this case, as per AGL dev test requirements:
        "output a list of all the cats in alphabetical order under a heading of the gender of their owner."
    
XUnitTests:

    Close to 100% coverage on all methods.  
    MOQ objects so not to hit the "live" sites.
    Trait "IntegrationLive" if no internet these will all fail. 
    This could be moved to seperate test project so test build failures aren't an issue.

Packages of interest:

    SkippableFact - allows you to use [SkippableFact] instead of [Fact] and 
                    you can use Skip.<xyz> within a Tests to dynamically 
                    Skip the Test during runtime.

    Required to setup ConsoleApp:
      "dependencies": {
      "Microsoft.NETCore.App": "2.2.0",
      "Microsoft.Extensions.DependencyInjection": "2.2.0",
      "Microsoft.Extensions.Configuration.Json": "2.2.0",
      "Microsoft.Extensions.Configuration.FileExtensions": "2.2.0",
      "Microsoft.Extensions.Configuration": "2.2.0",
      "Microsoft.Extensions.Options.ConfigurationExtensions": "2.2.0",
      "Microsoft.Extensions.Logging": "2.2.0",
      "Microsoft.Extensions.Logging.Console": "2.2.0",
      "Microsoft.Extensions.Logging.Debug": "2.2.0"
    }
    

TODO:

    Part of TDD is -> Red, Green and REFACTOR
    Project can be safely refactored. One area is dynamic LINQ properties to functions.  
    Nulls, bad data not completely catered for.
    Injectable Services - pipeline for console was a little bit more that I bargained for.
        WebAPI it's build for you. Since i'm asked in interviews I will attempt to finish soon.
    Add WebAPI and an Angular 2+ project to consume and display.
        Though most my Angular projects are on disk and "Pluralsight"/Work related, I should add this soon.
