# RecipesApp

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
git clone https://github.com/kiq7/recipes-app
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


### Frontend

On the root path, run the following commands:

```
cd src/Recipes.WebApp
npm install or yarn install 
npm start or yarn start 
```

Frontend application will run at http://localhost:4200


## Built With

* [.NET Core](https://www.microsoft.com/net/learn/get-started/) + Entity Framework Core, DI, AutoMapper, Flunt, EF InMemory Database
* [Angular 7](https://angular.io/) + Angular Material

## Author

* **Kaique Vieira**  

## License

This project is licensed under the MIT License