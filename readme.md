## Falco with MVC5 

The App has two Roles: "Admin" and "User".

**Only Admin Role can access to "paciente" view.**

login by default:

role admin :   
    user: admin@email.com
    password: demo
    
role user : 
    user: user@email.com
    password: demo
    

demo online: (site demo online)[clinicafalco.azurewebsites.net]



**Note:** If you get the error stated above on the first time you run the Solution, by simply enabling Nuget package manager to download those packages, you can run the project smoothly. 

#### Remedy:

1. In Visual Studio, right-click the solution and click "Restore NuGet Packages"; this will download the necessary packages needed to run the solution.

2. Build the project and Run.


**Note:** The packages used by the project are the default package files when you create a new MVC template within Visual Studio.
