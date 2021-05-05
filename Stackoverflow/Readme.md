--------New
the main difference between Repository layer and the Service layer it is that the Repository layer will contain the actual methods to 
call EF related LINQ queries. For example we could use db.Users.Where(u=>.....)

But in the service layer, we don't use the Linq to entities but we perform business logic.

So bottom line is Repository seats between Service Layer and Data Access Layer. Service Layer contains the business logic. 

Service Layer seats between domain model and ViewModel because Controller should not access domain model directly, Controller can access the ViewModel. 

So the Service Layer responsibility is to Migration of data  between Domain Model to ViewModel and ViewModel to Domain model.

