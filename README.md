# EasyNetQ
Basic Project with RabbitMQ containing 2 APIs to simulate a calculator, one called "OPERATOR" and the other called "PROCESS", implementing service bus to work with EasyNetQ

# Technologies
- C#
- .NET 5.0
- Docker
- RabbitMQ
- EasyNetQ

# A little bit about EasyNetQ
EasyNetQ also has a client-side library for the RabbitMQ Management HTTP API. This lets you control all aspects for your RabbitMQ broker from .NET code, including creating virtual hosts and users; setting permissions; monitoring queues, connections and channels; and setting up exchanges, queues and bindings.
More info on the official github: [EasyNetQ](https://github.com/EasyNetQ/EasyNetQ/wiki/Introduction)

# Installation
First you need to install docker desktop 
[Docker Desktop](https://docs.docker.com/desktop/windows/install/)

After installing Docker, you need to download and install RabbitMQ, you can do this by executing the following command:
```
  docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

Execute the project and it will open 2 API's tabs on the browser.

# How this works
On the "Operation" API you need to send a number and the a operation( + or - ), then the "Process" API is going to evaluate the operation and give a result.
This was achieved because I'm implementing a service bus, it will receive the API petition, evaluate and then respond to the Operation API with the desired object.
This process is using ["Request/Response"](https://github.com/EasyNetQ/EasyNetQ/wiki/Request-Response) messaging pattern.
Example on operation controller:
```
return await _bus.RequestAsync<OperationEvent, ResponseMessage>(userRequest);
```
