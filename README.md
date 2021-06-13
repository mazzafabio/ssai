# SixthSenseAI

## Presentation
Hi I'm Fabio and this is my coding challenge solution. I wanted to give you some consideration before start with DOC. I've used EF Core (Code First) as O/RM and SQL Server as database. EF Core itself is already an UoW/Repository pattern implementation but however I implemented my custom UoW and repo pattern (NO generic, just cause the project is small). This can be useful for testing (I can use EFCore InMemory) or if, in the future, there will be the needs of change ORM or database!
Another consideration is about the computation of total amount of a order: I've used Strategy Pattern (in view of future company codes).
Last consideration is about the Jwt authentication. Usually I've used external tool like Auth0 that already have frontend integration and backend token generation: I've just to implement the Verify function. In this project, however, I created a custom middleware and [authorize] attribute. I have not create an User table in DB, I've just hard coded a list with 1 user: username: test, password: test). The algorithm used for generation of token is HMAC and private key is in appsettings, but usually must be saved in secure store as aws secret manager.
Business Logic is in services and so, if this REST API will deploy in serverless solution as AWS Lambda, it's easy to do.
OpenAPI json is generated with the help of swashbuckle package and can be view at endpoint /swagger/index.html".

## Documentation
Project is structured as follow:

- *API* (controllerbase objects in order to define the paths)
- *Data* (DBContexts for Product and Order databases)
- *Entity*
    - *DB* (Models that define tables and are used as DBSet in DBContext)
    - *IRepository* (no comment)
    - *Repository* (no comment)
- *Helpers*
    - *Authorize* (Middleware and custom [Authorize] attribute for manage Jwt token)
    - *ComputationTotalAmount* (the algorithm that returns the total amount of a order. As I said, for that I've used Strategy Pattern)
    - *Pagination* (simple extension method for paginate lists)
- *Model*
    - *Request* (here are defined models of API requests)
    - *Response* (here are defined models of API responses)
- *Service* (services injected as dependency in startup and here you can find the Business Logic of Application)
- *UOW* (Means of course Unit of Work...)

## TODO
- *Manage errors* and return them in response in order to inform final users - *DONE*
- add *.gitignore* and take off bin and obj folder - *DONE*
- insert *< summary >* tag aroung the code - *DONE*
- document API Endpoint with *OpenAPI 3.0 spec*. - *WORKING*
- add in solution a *SSAI.Test project* with NUnit for testing with moq
