# tfg-backend

## C�mo aplicar las migraciones

### Nugget package manager console (selecting infrastructure project)

Add-Migration <Name> -Context DatabaseContext -OutputDir Persistence/Migrations

Update-Database -Context DatabaseContext

Remove-Migration -c DatabaseContext

Script-Migration -Context DatabaseContext

### Powershell from solution dir

dotnet-ef migrations add -c DatabaseContext --project Infrastructure --startup-project WebApi/ --output-dir Persistence/Migrations

dotnet-ef migrations remove -c DatabaseContext --project Infrastructure --startup-project WebApi/

dotnet-ef database update -c DatabaseContext --project Infrastructure --startup-project WebApi/

dotnet ef migrations script -c DatabaseContext