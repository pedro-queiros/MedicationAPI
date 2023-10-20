# Medication API
API to manage medication storage.

## Technologies/Tools
This project was developed with **.Net 7.0** and **Microsoft SQL Server 2022**.
Regarding tools, it was developed using **Microsoft Visual Studio 2022** and **SQL Management Studio 19**.
To make calls to the API, **Postman** (v10.19) was used.

## Setup
In the ```appsettings.json``` configure the connection string ```DefaultConnection``` to the database.
To create an empty database according to the configuration defined in the migration, run the following command in the ```Package Manager Console``` :
```
update-database
```
## Build the Application

### Via Command Line
Run the following command on the ```Host``` folder:
```
dotnet build
```

### Via Visual Studio 2022

Build the entire solution.


## Run the Application

### Via Command Line
Run the following command on the ```Host``` folder to start the API:
```
dotnet run
```

### Via Visual Studio 2022

Set *Host* project has startup project. Then, run the project.
When running, a page with the *Swagger* documentation of the API will prompt in the browser.

## Example Requests
**Notice:** All the example requests assume that the host is listening on port 5230.
### GET Requests
The GET requests support *OData* (v4.0).

#### Get all the medications 
```
http://localhost:5230/api/v1.0/medications
```
#### Get the name of all medications
```
http://localhost:5230/api/v1.0/medications?$select=name
```

#### Get the medication with id=1
```
http://localhost:5230/api/v1.0/medications/1
```

### POST Requests
#### Create a new medication
```
http://localhost:5230/api/v1.0/medications
```
##### Body:
```
{
"name":  "Ben-u-ron",
"quantity":  10
} 
```
### PUT Requests
#### Update the medication with id=1
```
http://localhost:5230/api/v1.0/medications/1
```
#### Body:
```
{
"name":  "Ben-u-ron",
"quantity":  5
} 
```
### DELETE Requests
#### Delete the medication with id=1
```
http://localhost:5230/api/v1.0/medications/1
```

## Unit Tests

**Notice:** There are unit tests only on the *Data Layer*, more precisely the *MedicationRepository* class methods.

### Via Command Line

To build the unit tests, run the following command on the ```Data.Tests``` folder:
```
dotnet build
```
Then, to run the unit tests, run the following command on the ```Data.Tests``` folder:
```
dotnet test
```

### Via Visual Studio 2022

Build the *Data.Tests* project and then run all tests (Test > Run All Tests).