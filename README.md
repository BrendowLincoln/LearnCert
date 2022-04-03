# Learn Certification API

> .NET 6 WEB API

### Checklist

- [x] Create .NET 6 project;
- [x] Add SQL Server Connection (*temporary*);
- [x] Implement a Repository Pattern with UnitOfWork;
- [x] Create functionality to use multiple files to implements a Dependency Injection of IServiceCollection;
- [x] Separate multiple projects inside the solution for Api, Domain, Infrastructure, and others;
- [x] Change Dockerfile to create a image with all projects of solution;
- [x] Remove SQL Server and Add MySQL (Amazon Aurora);
- [x] Add MySQL docker-compose;
- [x] Add migrations database;
- [x] Configure Unit Test suite;
- [x] Configure Integration Test suite;
- [x] Add feature to connect on test database and clear all data before run the tests;
- [x] Configure Autofixture;
- [x] Add Log tool;
- [x] Add Authentication;
- [x] Add FluentValidation;
- [ ] Create React app with Vite;
- [ ] Add React app docker-compose;
- [x] Implement CQRS pattern;

### Build and run app using Docker

````bash
docker build -t learn-cert-api-image -f Dockerfile .
docker run -d -p 8080:5000 --name learn-cert-api-container learn-cert-api-image
````

> API - http://localhost:8080/Book
> Swagger - http://localhost:8080/swagger/index.html

### Use Docker Compose

```base 
#powershell
docker-compose rm -f -s | docker-compose build | docker-compose up -d
````

### NoSQL Workbench 
[Download](https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/workbench.settingup.html)

