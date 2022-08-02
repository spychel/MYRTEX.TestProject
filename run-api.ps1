Set-ExecutionPolicy RemoteSigned -Scope Process
dotnet restore
cd api
dotnet watch run