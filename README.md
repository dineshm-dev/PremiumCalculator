# Premium Calculator

This application is used to calculate premiums based on person's occupation and insured amount.
I will use Angular as  frontend and .Net Core Web API as Backend service.
![image](https://user-images.githubusercontent.com/115399963/194752053-f222c20b-2dd5-4db5-8c7d-7c51ff2b6961.png)

# Angular Architectural Approach
I will use Facade pattern. Benefit of using it is business logic will be implemented in Facade service so that presentation layer will not impacted when we want to switch  data fetching from Api call to Redux state.

Age field is disabled and it will be calculated based on date of birth. However, we have implemented validation logic on age in case if user tries to tweak it.

# Calculator .Net Core API
 I have create API using .Net core 3.1 and followed Unit Of Work pattern assuming we might add additional business logic. I have followed SOLID principles.
 
 I have used below technologies for our Api
 .Net Core 3.1 WEB API
 .Net Core Native DI
 FluentValidation
 AutoMapper
 EntityFramework Core Code First Approach
 Swagger UI
 Automated Migrations
 
 
 
 

