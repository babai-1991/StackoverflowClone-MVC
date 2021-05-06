The service layers always seats between the Controller and Repository Layer. So Controller will  call the service. service 
will call the Repository and the Repository will take care about Insertion/Updation/Deletion/Fetching etc.

Business logic will be kept in the service layer & Service Layer is also responsible to place the AutoMapper code.
