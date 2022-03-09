# Learn Certification API

> .NET 6 WEB API

### Checklist

- [x] Create .NET 6 project;
- [x] Add SQL Server Connection (*temporary*);
- [x] Implement a Repository Pattern with UnitOfWork;
- [x] Create functionality to use multiple files to implements a Dependency Injection of IServiceCollection;
- [x] Separate multiple projects inside the solution for Api, Domain, Infraestructure, and others;
- [ ] Remove SQL Server and Add MySQL (Amazon Aurora);
- [ ] Correct Dockefile to build all projects in soluction;
- [ ] Add MySQL docker-compose;
- [ ] Create React app with Vite;


### Build and run app using Docker

````bash
docker build -t learn-cert-api-image -f Dockerfile .
docker run -d -p 8080:5000 --name learn-cert-api-container learn-cert-api-image
````

> API - http://localhost:8080/WeatherForecast \
> Swagger - http://localhost:8080/swagger/index.html

### Use Docker Compose

```base 
#powershell
docker-compose rm -f -s | docker-compose build | docker-compose up -d
````

### NoSQL Workbench 
[Download](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/workbench.settingup.html)

