# Salt Tech - Tech Challenge
Author: Ívar Óli Sigurðsson

A tech challenge proposed by SaltPay, it invloves  creating a functional ECommerce site with both a frontend and backend. I decided to use .Net Core for the backend because how comfortable I am with that environment and also how easy it is to implement unit tests in OOP using dependency injection. I Also chose to use ReactJS for the frontend mainly because how comfortable I am using that framework.

I chose to run the fontend seperatly from the backend on the react development server, instead of serving it using .Net core, even though it is easily doable. Mainly because I know from experience it could take some time to create a static version of the site that can be served.

For the database I chose to use MySQL hosted on a small server that I was already renting from digital ocean. I also used a tool that changes CSV files into SQL tables and insert statements. Instead of using the provided dataset, I decided to find a better one on kaggle that includes images and just the relevant data, I ended up using [this](https://www.kaggle.com/PromptCloudHQ/flipkart-products).

My solutions to this challenge was developed using the VS Code IDE on a Linux (Ubuntu) machine.

## Depenencies
 - .Net Core (Version 3.0^)
 - dotnet-ef (Version 3.0.0)
 - ReactJS (Version 3.0^)
## Deployment
To run unit tests on the API: 
```
dotnet test
```

To build and run the backend (keep in mind that it runs on port 5000): 
```
dotnet run
```

Running the ReactJS frontend on the development server: 
```
npm start
```

## API Reference