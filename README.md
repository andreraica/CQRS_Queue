# CQRS_Queue
This will be a Basic CQRS with EventSourcing (Command Query Responsibility Segregation) using Queue inter domains


# UNDER CONSTRUCTION


### Requeriments

* [Visual Studio] - Microsoft Visual Studio!
* [.NET Core 2.1] - SDK/RunTime Microsoft .NET Core 2.1 [https://www.microsoft.com/net/download/dotnet-core/2.1]
* Docker Tools (Docker for Windows or Mac) [https://www.docker.com/products/docker-desktop]

### RUN STEPS

# UNDER CONSTRUCTION

# About Project!

### Basic Tech

**This project is using SOLID concepts**

* User Input: Angular Application / WebAPI
* Project Tiers: Class Library
* Project Test: xUnit

**Tiers:**
>Domain 
* Model & Services: Domain is a global tier used by all tiers providing the main entities and services

>Infrastructure
* Data: This tier consumes the WebAPI. It has your own model to manipulate the JSON and response to Services 
* IoC: This tier just Inject all dependencies (DI) - using package SimpleInjector

>Tests
* This project implements all the mensurable tests in the scope
* Using Moq & Stubs to emulate injections and isolating the tests

**Packages & Techs:**
* Moq
* xUnit
* Newtonsoft.Json
* SimpleInjector
* UoW
* EntityFramework
* Others .net Core Packages...



### Next Steps Todo

**General**

 - Make ContextDB .Writer - Auto Migrations with Seed
 - Create Mongo Docker .Reader - Docker Compose
 - Handle - commands and events
 - Implement EventSourcing
 - Create Full Domain Stock

**FrontEnd**

 - Create Angular simple interface
 
License
----

**Free by Andre Raiça Silva**