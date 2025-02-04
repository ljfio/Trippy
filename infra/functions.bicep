param location string
param environment string

param appInsightsConnectionString string
param appInsightsKey string
param storageAccountConnectionString string

resource functionAppPlan 'Microsoft.Web/serverfarms@2024-04-01' = {
  name: 'plan-trippy-${environment}-func'
  location: location
  sku: {
    name: 'Y1'
    tier: 'Dynamic'
    capacity: 0
  }
  properties: {
    reserved: true
  }
}

module activityFunctionApp 'functionApp.bicep' = {
  name: 'functions-activity'
  params: {
    name: 'activity'
    location: location
    environment: environment
    functionAppPlanId: functionAppPlan.id
    appInsightsConnectionString: appInsightsConnectionString
    appInsightsKey: appInsightsKey
    storageAccountConnectionString: storageAccountConnectionString
  }
}

module participantFunctionApp 'functionApp.bicep' = {
  name: 'functions-participant'
  params: {
    name: 'participant'
    location: location
    environment: environment
    functionAppPlanId: functionAppPlan.id
    appInsightsConnectionString: appInsightsConnectionString
    appInsightsKey: appInsightsKey
    storageAccountConnectionString: storageAccountConnectionString
  }
}

module tripFunctionApp 'functionApp.bicep' = {
  name: 'functions-trip'
  params: {
    name: 'trip'
    location: location
    environment: environment
    functionAppPlanId: functionAppPlan.id
    appInsightsConnectionString: appInsightsConnectionString
    appInsightsKey: appInsightsKey
    storageAccountConnectionString: storageAccountConnectionString
  }
}
