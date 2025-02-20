## Instructions

### Install EF Cli
```bash
dotnet tool install --global dotnet-ef  
```

### Add migration files
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design -p ProductManagement.API
```

### Apply migration
```bash
dotnet ef database update -p ProductManagement.Infra -s ProductManagement.API

```

#### Explanation:
- `-p` ProductManagement.Infra: Specifies the project that contains your DbContext (and migration files).
- `-s` ProductManagement.API: Specifies the startup project, which is used for runtime configurations like the connection string.
