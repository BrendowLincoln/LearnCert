# Learn Certification API

> ASP .NET 6 WEB API


### Build and run app using Docker

````bash

docker build -t learn-cert-api-image -f Dockerfile .

docker run -d -p 8080:5000 --name learn-cert-api-container learn-cert-api-image

```

> API - http://localhost:8080/WeatherForecast
> Swagger - http://localhost:8080/swagger/index.html

### Use Docker Compose

```base 

#powershell

docker-compose rm -f -s | docker-compose build | docker-compose up -d

```