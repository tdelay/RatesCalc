# Interest rate calculation example

Application which evaluates how the change of base rate will impact the interest rate.

## Description

This project is an attempt to follow Domain-Driven Design (DDD) pattern.
Application contains five main projects:

- Shared Base
- Core
- Infrastructure
- Web
- Web Service

### Shared Base

Contains all base classes, interfaces and code which will be implemented, shared among all projects. 

### Core

The Core project is the center of the Application. It contains data models, enums as well as helper class `BaseRateValueApi` which is 
responsible for interest rates calculation by given data. This class is wrapped into factory which make it to be lazy loadable.

### Infrastructure

Responsible for data access and implementation of interfaces provided by Core project. 

### Web 

The entry point of the application.

### Web Service 

The entry point of the application.


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Clone GitHub repository

```
git clone https://github.com/tdelay/RatesCalc.git
```
or download manually

### Installing

Locate RatesCalc.sln file  in 'src' directory and run it.

## Running the tests

All tests are located in 'test' folder.

### Break down into end to end tests

Test are separated into 3 projects:

- Unit
- Integration
- Functional

## Built With

* [.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - The web framework used
* [ASP.NET Core and Entity Framework](https://docs.microsoft.com/en-us/ef/) - Data access
* [xUnit](https://xunit.net/) - Tests
* [API structure](https://swagger.io/) - Swagger (run Web API project and navigate to ¬/swagger)
