param location string
param environment string
param name string

param functionAppPlanId string

param appInsightsConnectionString string
param appInsightsKey string
param storageAccountConnectionString string

resource functionApp 'Microsoft.Web/sites@2024-04-01' = {
  name: 'func-trippy-${environment}-${name}'
  location: location
  kind: 'functionapp,linux'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    reserved: true
    serverFarmId: functionAppPlanId
    httpsOnly: true
    siteConfig: {
      http20Enabled: true
      minTlsVersion: '1.2'
      scmMinTlsVersion: '1.2'
      netFrameworkVersion: 'v8.0'
      use32BitWorkerProcess: false
      publicNetworkAccess: 'Enabled'
      linuxFxVersion: 'dotnet-isolated|8.0'
    }
  }
}

resource functionAppConfig 'Microsoft.Web/sites/config@2024-04-01' = {
  name: 'appsettings'
  parent: functionApp
  properties: {
    FUNCTIONS_EXTENSION_VERSION: '~4'
    FUNCTIONS_WORKER_RUNTIME: 'dotnet-isolated'
    WEBSITE_RUN_FROM_PACKAGE: '1'
    APPINSIGHTS_INSTRUMENTATIONKEY: appInsightsKey
    APPLICATIONINSIGHTS_CONNECTION_STRING: appInsightsConnectionString
    WEBSITE_CONTENTSHARE: replace(functionApp.name, '-', '')
    WEBSITE_CONTENTAZUREFILECONNECTIONSTRING: storageAccountConnectionString
    WEBSITE_USE_PLACEHOLDER_DOTNETISOLATED: '1'
    AzureWebJobsStorage: storageAccountConnectionString
  }
}
