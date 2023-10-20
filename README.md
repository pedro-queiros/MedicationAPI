# Medication API
API to manage medication storage.

## Technologies/Tools
This project was developed with **.Net 7.0** and **Microsoft SQL Server 2022**.
Regarding tools, it was developed using **Microsoft Visual Studio 2022** and **SQL Management Studio 19**.
For testing purposes, Postman was used **Postman** to make the requests.

## Setup
In the ```appsettings.json``` configure the connection string ```DefaultConnection``` to the database.
To create an empty database according to the configuration defined in the migration, run the following command in the ```Data``` project :
```
update-database
```
## Build the project
To build the API, run the following command on the ```Host``` folder:
```
dotnet build
```
## Run the project
After building the API, run the following command on the ```Host``` folder to start the API:
```
dotnet run
```

## Example Requests
**Notice:** All the example requests assume that the host is listening on port 5230.
### GET Requests
#### Get all the medications 
```
http://localhost:5230/api/v1.0/medications
```
#### Get the medication with id=1
```
http://localhost:5230/api/v1.0/medications/1
```
#### Get the name of all medications
```
http://localhost:5230/api/v1.0/medications?$select=name
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
### Delete Requests
#### Delete the medication with id=1
```
http://localhost:5230/api/v1.0/medications/1
```

## Testing

**Notice:** The tests only test the MedicationRepository class methods.

To build the tests, run the following command on the ```Data.Tests``` folder:
```
dotnet build
```
Then, to run the tests, run the following command on the ```Data.Tests``` folder:
```
dotnet test
```