# LanternPay - Programming Exercise

**References / Inspiration for the patterns and designs used on this project**

[The Ideal Domain-Driven Design Aggregate Store](https://kalele.io/the-ideal-domain-driven-design-aggregate-store/)

[Dependency Injection in .Net](http://sd.blackball.lv/library/Dependency_Injection_in_.NET_(2011).pdf)

[Microsoft eShop](https://github.com/dotnet-architecture/eShopOnContainers)

**How to run API with docker**

*NOTE: all heavy tasks and functionalities are done for this project, but wiring them up on the controller and testing is pending...*

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

**Testing using Postman collection**

1. Import postman collections found at /postman/LanternPay.postman_collection.json
2. Import postman environment variables at /postman/LanternPay.postman_environment.json

*Collections*
1. Create Lecture Theatre
2. Create subject
3. Get all lecture theatres
4. Get all subjects
5. Get subject by id => "subjectId" variable gets populated automatically after calling "Create Subject"
6. Get lecture theatres by id => "theatreId" variable gets populated automatically after calling "Create Lecture Theatre"

**How to debug API**

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

**How to run console app file reverse project**

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
