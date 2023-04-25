### Restaurant manager API build with ASP.NET CORE

This api was built for a customer and is part of a larger project

Feel free to test the website and API, but be careful 🚨 only admin can delete everything you created.🚨

#### REACT CLIENT REPO: https://github.com/corsall/restaurant-react-client
#### REACT CLIENT Website that consumes API: https://corsall.github.io/restaurant-react-client/

Here you can see some of the created endpoints

![restaurant_manager_api](https://github.com/corsall/restaurant-manager-api/blob/master/swagger-example.png)

## In general

- Api has endpoints to perform all sorts of CRUD operations on restaurant tables.
- Api also has a system of users and roles🔑(login\registration via JWT tokens)
- Some endpoints are protected and accessible only to users with the appropriate role.
- Api uses SQL database, in my case it is an azure SQL server.
- Api even has its own mini client ❤️

## Technologies

The project uses the following technologies:

- .NET Core 6
- REST principles
- Swagger
- Entity Framework Core
- SQL Server

When api is running, it can be accessed via a small client, written in pure JS/html/css

![restaurant_manager_api_website](https://github.com/corsall/restaurant-manager-api/blob/master/restaurant-manager-api-example.png)

