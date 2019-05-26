# LanternPay - Programming Exercise

**Using Postman collection**

1. Import postman collections found at /postman/LanternPay.postman_collection.json
2. Import postman environment variables at /postman/LanternPay.postman_environment.json

*Collections*
1. Get all lecture theatres = add new lecture theatre

**How to run API with docker**

1. Go to API project folder (/src/api/Lantern.Api)

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
