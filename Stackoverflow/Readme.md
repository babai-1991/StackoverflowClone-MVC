In the **domain models project**  , we are going to add domain models which are related to entity framework. So all the entity framework related model classes we are going to place here.

The viewmodels contains the models which can be binded to the respective views.

Service Layer representing the services. For every table, we are going to create a separate service which contains the methods for CRUD operation.

The repositories contain the actual code for CRUD operation.

Repository seats between data access Layer and the service layer.

--------New
so we have added the reference of the View models into service layer and into the UI project because in the service layer,
we are trying to convert the data from the view model to domain model and domain model to view model. Also in UI project we will create View using
ViewModels only.
