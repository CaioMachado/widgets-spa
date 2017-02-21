# Test - RedVentures

Requirements:
- .NET Framework 4.6.1 installed
- Visual Studio 2015 installed

To compile (if you have Visual Studio installad):
1. Open the solution
2. Build the solution

To compile (if you don't have Visual Studio installed)
1. Open a command prompt windows  
2. Change the directory to your installation directory of the .NET Framework
    cd \Windows\Microsoft.NET\Framework\v4*
3. Then call the msbuild with the path of the .sln file
    msbuild "[PATH_TO_SLN_FILE].sln" /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU"    

To start:
1. After compiled, go to the release folder and open the file 'RedVentures.Host.exe'.
2. A console window will prompt with the WebApi Port.

To use:
1. Before call any method, you will need to ask for a token
2. To do so, you need send POST to 'http://localhost:8080/token' with the following data:
    - Content-Type: application/x-www-form-urlencoded
    - Inside the form you need to send:
        a. grant_type: password
        b. username: xxxxxx
        c: password: xxxxxx
3. After that, if you sent a valid username and password, you'll receive an access_token and a token_type.
4. Inside each request, you need to add the Authorization header with the following value: "{token_type} {access_token}"
5. The tokens are valid for 1 day.