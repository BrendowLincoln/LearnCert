# Learn Certification API

> ASP .NET 6 WEB API


### Build and run app using Docker

````bash

docker build -t learn-cert-api-image -f Dockerfile .

docker run -d -p 8080:5000 --name learn-cert-api-container learn-cert-api-image

http://localhost:8080/WeatherForecast

http://localhost:8080/swagger/index.html

```