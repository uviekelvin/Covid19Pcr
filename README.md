# Covid19Pcr ThynkSoftware Report


I used a .net core 5 and CQRS which separates all layers of application More work but with better code maintainability.

I used a mediator framework for the implementation of the calls, this can be reusable if an API is to be layered on this application.

Implementation approach was TDD and Domain Driven designs.

# If There was more time I would have:

Introduced redis for cached data calls that would not change very often.The GetLocationsWithLabQuery is a perfect example of such
Introduced authorization and authentication which would enforce security across the application, grant access to user based on roles and permissions.
Introduced audit trails which is dependent on authentication and authorization to know who is doing what in the application.

Completed the empty tests and added a lot more tests to cater for the conditions in the handlers. The test setup is complete and adding tests would have been a lot easier.

Add Controller and UI tests.
