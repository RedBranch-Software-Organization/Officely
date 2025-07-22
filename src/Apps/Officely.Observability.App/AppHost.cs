var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject("CodeService", "../../Services/CodeService/Api/Api.csproj");
builder.AddProject("StorageService", "../../Services/StorageService/Api/Api.csproj");

builder.Build().Run();
