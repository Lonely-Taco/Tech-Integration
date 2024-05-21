# TechIntegration Project

## Overview

The TechIntegration project is a .NET 8 application designed to interact with the Trello API to manage and update Trello
boards based on data from CSV files. The application reads tender data from a CSV file, generates Trello cards, and
updates custom fields on these cards based on the tender data.

## Requirements

- .NET 8 SDK
- Trello API Key, Secret, and Token
- Trello Board ID

## Setup

### Step 1: Install .NET 8 SDK

.NET 8 SDK from [.NET official website](https://dotnet.microsoft.com/download/dotnet/8.0).

### Step 2: Acquire Trello API Credentials

1. **Trello API Key and Secret**:
    - Go to the [Trello Developer API Keys page](https://trello.com/app-key).
    - Log in with your Trello account.
    - Copy the API Key and generate an API Secret.

2. **Authenticate with Trello**
    - Call the Trello/auth endpoint and go to the provided link.
    - Approve the access and copy the generated token.
   
3. **Trello API Token**:
    - Once the access has been approved copy the token and paste it in the `appsettings.Development.json`

### Step 3: Configure `appsettings.Development.json`

Create or update the `appsettings.Development.json` file in the root of your project with the following content:


```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "TRELLO_API_KEY": "<Your Trello API Key>",
  "TRELLO_API_SECRET": "<Your Trello API Secret>",
  "TRELLO_API_TOKEN": "<Your Trello API Token>",
  "TRELLO_API_BOARDID": "<Your Trello Board ID>"
}
```

## Running the application

```bash
dotnet restore
```

```bash
dotnet build
```

```bash
dotnet run
```

## Endpoints

**GET /Trello/auth**

Returns the Trello authorization URL.

**GET /Trello/boards**

Fetches all boards associated with the Trello account.

**GET /Trello/fields**

Fetches all custom fields for the specified board.

**GET /Trello/cards**

Creates cards based on the tender data from the CSV file.

**GET /Trello/card/{id}**

Fetches details for a specific card by its ID.

**GET /Trello/card/fields/{id}**

Fetches custom field values for a specific card by its ID.

**GET /Trello/lists**

Fetches all lists for the specified board.

**GET /Trello/list/{id}**

Fetches details for a specific list by its ID.

**GET /Trello/list/cards/{id}**

Fetches all cards for a specific list by its ID.

POST /Trello/card/{listId}**

Creates a card in the specified list with the provided data.
