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

    Consumer an OwnerService that hides and retrieves all the data. A simple console formatter prints as per AGL dev test requirements "output a list of all the cats in alphabetical order under a heading of the gender of their owner."
    
XUnitTests:

    Close to 100% coverage on all methods.  MOQ objects so not to hit the "live" sites.
    Trait "IntegrationLive" if no internet these will all fail. 
    This could be moved to seperate test project so test build failures aren't an issue.

Packages of interest:

    SkippableFact - allows you to use [SkippableFact] instead of [Fact] and 
                    you can use Skip.<xyz> within a Tests to dynamically 
                    Skip the Test during runtime.

TODO:

    Part of TDD is -> Red, Green and REFACTOR
    Project needs to be refactored of course.  Nulls, bad data not completely catered for.
    Injectable Services - pipeline for console was a little bit more that I bargained for
    Add WebAPI and an Angular 2+ project to consume and display.
