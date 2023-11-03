# API .NET 7.0 WITH MONGODB
```
- Microservice developed using ASP.NET Core and MongoDb Drive
```
## Descrição do Projeto
```
- This is a sample project that demonstrates using .NET 7.0 to create an API that allows you to insert customers into a MongoDB database. After creating a customer, the system sends a confirmation email to the registered customer.
```
## Requisitos
```
- .NET 7.0
- Docker
```
## Features
```
- Save Customer. 
- Update Customer. 
- Get Customer. 
- Get By ObjectId Customer. 
- Send E-mail Create Customer.
- Unit Test
```
## Technologies, Architecture and Patterns
```
- Microsoft.AspNetCore.OpenApi - Version 7.0.4
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets - Version 1.17.2
- Swashbuckle.AspNetCore - Version 6.4.0
- MongoDB.Bson - Version 2.22.0
- MongoDB.Driver - Version 2.22.0
- AutoMapper - Version 12.0.1
- Microsoft.Extensions.Options - Version 7.0.1
- automapper.extensions.microsoft.dependencyinjection - Version 12.0.1
- Microsoft.Extensions.Configuration.Abstractions - Version 6.0.0
- Microsoft.Extensions.DependencyInjection.Abstractions - Version 7.0.0
- NCrontab.Signed - Version 3.3.1
- Microsoft.AspNetCore.Mvc.NewtonsoftJson - Version 5.0.7
- Microsoft.AspNetCore.ResponseCompression - Version 2.2.0
- Newtonsoft.Json - Version 13.0.1
- Polly - Version 7.2.2
```
### Pacotes adicionais para testes:
```
- Microsoft.NET.Test.Sdk - Version 17.5.0
- xunit - Version 2.4.2
- xunit.runner.visualstudio - Version 2.4.5
- coverlet.collector - Version 3.2.0
- AutoMapper - Version 12.0.1
- AutoFixture - Version 4.17.0
- Bogus - Version 34.0.1
- MOQ - Version 4.15.2
- MOQ.automock - Version 2.1.0
- Moq - Version 4.16.1
```
## Use
```
- Clone this repository to your local machine.
- Open the project in your preferred IDE or code editor.
- Make sure MongoDB is running with the settings provided in the docker-compose.yml file.
- Run the application.
- Use the API to insert customers into MongoDB.
- After inserting a customer, the system will send a confirmation email to the registered customer.
```
