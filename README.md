# PetPal 

PetPal is a "match-making" app for dogs where pet owners can find other pet owners.
The goal is to broaden the network for pet owners and help them find friends for their pets.

The user can create an account and thereafter view other users and their pets.
The user can message and like other users to match with them and socialice with them.

## Local Development
### **Install**:

- Project was built with using Visual Studio to building Backend and using VS Code to build frontend

- Make sure you have SSMS downloaded since this project is using SQL Server as Database and have test data seeded upon starting backend.

### Start project only using VS Code:
- Open project in VS Code. 
- Open termianl and navigate to PetPal-Client `cd petpal-client` and run `npm i --force` 
- In terminal run `npm run ng serve` or `ng serve`
- Navigate to PetPal-Api and run `dotnet run` (if you're currently in PetPal-Client simply `cd ../PetPal-Api`)
- Lastly `dotnet build` `dotnet run` or `dotnet watch`

### Start projekt using VS Code frontend & Visual Studio Backend
- Open PetPal-Client in VS Code.
- Open termianl and navigate to PetPal-Client `cd petpal-client` and run `npm i --force` 
- In terminal run `npm run ng serve` or `ng serve`
- Either click `PetPal.sln` or open PetPal using Visual Studio.
- Start program `f5` or in terminal run `dotnet build` `dotnet run` or `dotnet watch`

