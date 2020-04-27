# Project Title

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

Contains all base class, interfaces and code which will be implemented shared among all projects. 

### Core

The Core project is the center of the Application. It contains data models, enums as well as helper class `BaseRateValueApi` which is 
responsible for interest rates calculation by given data. This class is wrapped into factory which make it to be lazy loadable.

### Infrastructure

Responsible for  data access and implementation of interfaces provided by Core project. 

### Web 

The entry point of the application is the ASP.NET Core web project.

### Web Service 

The entry point of the application is the ASP.NET Core web API.


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

All test are located in 'test' folder.  xUnit framework was used to write test classes.

### Break down into end to end tests

All test are separated into 3 projects:

- Unit
- Integration
- Functional

#### Unit




## Authors

* **Tomas Simkus*
