# IBAS Support WebApp

Dette projekt er en .NET Blazor WebApp til håndtering af supporthenvendelser for IBAS.

WebApp'en bruger Azure Cosmos DB til at gemme supporthenvendelser.

## Funktioner

WebApp'en kan:

- Oprette en ny supporthenvendelse
- Validere inputfelter
- Gemme supporthenvendelser i Cosmos DB
- Hente og vise eksisterende supporthenvendelser
- Navigere mellem forsiden, oprettelse og oversigt

## Teknologier

- .NET / Blazor
- C#
- Azure Cosmos DB
- Microsoft.Azure.Cosmos
- Azure
- GitHub

## Cosmos DB

Projektet bruger følgende Cosmos DB-struktur:

- **Resource Group:** `IBasSupportRG`
- **Cosmos DB Account:** `ibas-db-account-16834`
- **Database:** `IBasSupportDB`
- **Container:** `ibassupport`
- **Partition Key:** `/category`

### Opret Cosmos DB med Azure CLI

Log ind på Azure:

```bash
az login
```

Opret resource group:

```bash
az group create --name IBasSupportRG --location swedencentral
```

Opret Cosmos DB account:

```bash
az cosmosdb create \
  --name ibas-db-account-16834 \
  --resource-group IBasSupportRG \
  --locations regionName=swedencentral \
  --enable-free-tier true
```

Opret database:

```bash
az cosmosdb sql database create \
  --account-name ibas-db-account-16834 \
  --resource-group IBasSupportRG \
  --name IBasSupportDB
```

Opret container:

```bash
az cosmosdb sql container create \
  --account-name ibas-db-account-16834 \
  --resource-group IBasSupportRG \
  --database-name IBasSupportDB \
  --name ibassupport \
  --partition-key-path "/category"
```

## Kør projektet

Start projektet med:

```bash
dotnet run
```

Åbn derefter den lokale adresse, som vises i terminalen.

## Status

- [x] Blazor WebApp oprettet
- [x] GitHub repository oprettet
- [x] Cosmos DB oprettet
- [x] SupportMessage model oprettet
- [x] Cosmos DB service oprettet
- [x] Oprettelse af supporthenvendelser
- [x] Validering af input
- [x] Visning af supporthenvendelser
- [x] Navigation
- [x] Home-side tilpasset
- [x] Testet lokalt