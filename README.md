# LanternPay - Programming Exercise

A simple demonstration for the following:

* dotnetcore C#
* Dependency Injection (IoC - Inversion of Control)
* DDD
* Event Driven Design (using MediatR)
* Service Layer Pattern
* Repository Pattern (PostgreSQL Jsonb using Marten)
* CQRS
* Docker
* RESTful API (did not apply jsonapi standard due to time constraints)

## Table of Contents

- [References](#references)
- [Project Structure](#project-structure)
- [How to run API with docker](#how-to-run-api-with-docker)
- [Testing using Postman collection](#testing-using-postman-collection)
- [How to debug API](#how-to-debug-api)
- [How to run console app file reverse project](#how-to-run-console-app-file-reverse-project)
- [Software Architecture](#software-architecture)

### References
[back to top](#table-of-contents)

* [The Ideal Domain-Driven Design Aggregate Store](https://kalele.io/the-ideal-domain-driven-design-aggregate-store/)
* [Dependency Injection in .Net](http://sd.blackball.lv/library/Dependency_Injection_in_.NET_(2011).pdf)
* [Microsoft eShop](https://github.com/dotnet-architecture/eShopOnContainers)

### Project Structure
[back to top](#table-of-contents)

1. API

   * Lantern.API = Application Layer
   * Lantern.Core = Implementation Layer
   * Lantern.Domain = Domain Layer

2. File
    * Lantern.File = revert file console app

3. Tests
    * Lantern.File.Test = file console unit tests
    * Lantern.File.Api = unit test for API (skipped due to time constraints)

### How to run API with docker
[back to top](#table-of-contents)

1. Go to project root folder 

2. Build docker
```
docker-compose build
```

3. Run docker
```
docker-compose up
```

4. PG Admin can be viewed at: http://localhost:5431
```
pg admin login:

u: admin
p: password

database login:

server: lantern-postgre-sql
u: postgres
p: password

```

5. API endpoint is accessible at: http://localhost:5000
6. Swagger endpoint is at: http://localhost:5000/swagger

### Testing using Postman collection
[back to top](#table-of-contents)

1. Import postman collections found at /postman/LanternPay.postman_collection.json
2. Import postman environment variables at /postman/LanternPay.postman_environment.json

*Note: All postman collections are configured with a test data.*

*Collections to be executed in order:*
1. Create Lecture Theatre = automatically populates postman variable "lectureTheatreId"
2. Create subject = automatically populates postman variable "subjectId"
3. Create lecture on a subject = automatically uses variables on #1 and #2
4. Create student = automatically populates postman variable "studentId"
5. Enroll = automatically populates postman variable "applicationId" and uses variables for student and subject

*All other postman collections can be accessed at any order and time (depending on the values of variables used)*

### How to debug API
[back to top](#table-of-contents)

1. Go to project root folder 

2. Build docker (if you haven't done it yet from previous steps)
```
docker-compose build
```

3. Run docker database and pgadmin on the background
```
docker-compose up -d lantern-postgre-sql
```

4. Go to API project folder (/src/api/Lantern.Api)

5. Build API project
```
dotnet build
```

6. Run API project
```
dotnet run
```

7. Api endpoint at: http://localhost:5000/
8. Attach debugger from Visual Studio or JetBrains Rider

### How to run console app file reverse project
[back to top](#table-of-contents)

1. On shell, go to /src/file/Lantern.File
2. Edit input.txt for the file to reverse
3. Build the project
```
dotnet build
```
4. Run the project
```
dotnet run
````
5. Check output_<datetime tick value>.txt contents (every run generates a unique filename if output.txt already exists)
  
NOTE: Unit tests can be found on /src/tests

### Software Architecture
[back to top](#table-of-contents)

Diagram can be found on /src/diagram/eShop-microservice.jpg
![Software Architecture](https://github.com/markglibres/job-app-lanternpay/blob/master/src/diagram/eShop-microservice.jpg)
