# Premium Calculator

This application is used to calculate premiums based on person's occupation and insured amount.
I will use Angular as  frontend and .Net Core Web API as Backend service.

![image](https://user-images.githubusercontent.com/115399963/194751620-344b19f0-7560-4609-8143-9b2d1d9d635b.png)

Angular Architectural Approach
I will use Facade pattern. Benefit of using it is business logic will be implemented in Facade service so that presentation layer will not impacted when we want to switch  data fetching from Api call to Redux state.

Age field is disabled and it will be calculated based on date of birth. However, we have implemented validation logic on age in case if user tries to tweak it.

.Net Core API
 I have create API using .Net core 3.1 and followed Unit Of Work pattern assuming we might add additional business logic. I have followed SOLID principles.
 
 I have used below technologies for our Api
 FluentValidation
 AutoMapper
 EntityFramework Core Code First Approach
 DB migration
 
 
 
 

