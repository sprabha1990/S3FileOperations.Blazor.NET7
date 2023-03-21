It's a .NET 7 Blazor WebAssembly application that will provide functionalities to the users to see the list of files in the S3 bucket, download them and upload a new file into the S3 bucket.

An ASP NET Core WebAPI application will handle the request comming from Blazor application and do the following actions in the AWS S3 workd.

To run this application,
run the following commands in from the solution directory

```
dotnet run --project Api\S3FileOperations.WebApi.csproj
dotnet run --project WebApp\S3FileOperations.Blazor.csproj

```

> More information about this project is available in my [blog post](https://dev.to/sprabha1990/series/22262)
