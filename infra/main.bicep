targetScope = 'subscription'

@allowed(['uksouth', 'ukwest'])
param location string

@minLength(3)
@maxLength(12)
param environment string

param publisherEmail string
param publisherName string

resource resourceGroup 'Microsoft.Resources/resourceGroups@2024-11-01' = {
  name: 'rg-trippy-${environment}'
  location: location
}

module appInsights 'appInsights.bicep' = {
  scope: resourceGroup
  name: 'appInsights'
  params: {
    location: location
    environment: environment
  }
}

module storage 'storage.bicep' = {
  scope: resourceGroup
  name: 'storage'
  params: {
    location: location
    environment: environment
  }
}

module functions 'functions.bicep' = {
  scope: resourceGroup
  name: 'functions'
  params: {
    location: location
    environment: environment
    appInsightsConnectionString: appInsights.outputs.connectionString
    appInsightsKey: appInsights.outputs.key
    storageAccountConnectionString: storage.outputs.connectionString
  }
}

module apiManagement 'apiManagement.bicep' = {
    scope: resourceGroup
    name: 'apiManagement'
    params: {
        location: location
        environment: environment
        publisherEmail: publisherEmail
        publisherName: publisherName
    }
}
