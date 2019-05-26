# LanternPay - Programming Exercise

**How to run API with docker**

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
