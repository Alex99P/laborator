using System;

namespace Laborator3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        ststic void Initialize()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,  
                               DriveService.Scope.DriveFile,};  

              var clientId = "747269699991-c00mv50bmqt4pa23757uhr9iulkgobfu.apps.googleusercontent.com";      // From https://console.developers.google.com  
              var clientSecret = "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";          // From https://console.developers.google.com  
                                           // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
              var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets  
              {  
                  ClientId = clientId,  
                  ClientSecret = clientSecret  
              },scopes,  
              Environment.UserName,
              CancellationToken.None,
              new FileDataStore("MyAppsToken")
              ).Result;  
              //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   
  
              _service = new DriveService(new BaseClientService.Initializer()  
              {  
                  HttpClientInitializer = credential,  
                  
  
              });
              _token = credential.Token.AccessToken;
              Console.Write("Token "+credential.Token.AccessToken);
        }
    }
}
