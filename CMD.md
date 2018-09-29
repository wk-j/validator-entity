## Commands

```
dotnet ef migrations add InitialCreate \
    --startup-project tests/MyEntity/MyEntity.csproj \
    --project src/ValidatorEntity/ValidatorEntity.csproj

dotnet ef migrations script \
    --startup-project tests/MyEntity/MyEntity.csproj \
    --project src/ValidatorEntity/ValidatorEntity.csproj
```