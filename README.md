# RecipesApp
[![Build status](https://ci.appveyor.com/api/projects/status/3ll52d3by9e8r58m?svg=true)](https://ci.appveyor.com/project/kiq7/recipes-app)

An simple app to manage cook recipes.

## Getting Started

### Prerequisites

* .NET Core 2.1
* Node v8.11.1+
* npm
* Angular CLI


## Running project

### Checkout this repository 

```
git clone https://github.com/kiq7/recipes-app.git
```

### Backend 

On the root path, run the following commands:

```
dotnet restore && dotnet run -p src/Recipes.API
```

API will run at http://localhost:5001/

### Exploring the API

If you wanna test any method exposed by the API, you should do it by using the Swagger interactive documentation. Just navigate to

```
http://localhost:5001/swagger/
``` 

and explore it, as simple as that.

### Running the tests

On the root path, run the following command:

```
$ dotnet test tests/Recipes.Domain.Tests
```

### Frontend

On the root path, run the following commands:

```
cd src/Recipes.WebApp
npm install or yarn install 
npm start or yarn start 
```

Frontend application will run at http://localhost:4200


## Built With

* [.NET Core](https://www.microsoft.com/net/learn/get-started/) + Entity Framework Core, DI, AutoMapper, Flunt, EF InMemory Database, xUnit + Fluent Assertions
* [Angular 7](https://angular.io/) + Angular Material

## Author

* **Kaique Vieira**  

## License

This project is licensed under the MIT License