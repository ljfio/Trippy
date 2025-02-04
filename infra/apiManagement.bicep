param location string
param environment string

param publisherEmail string
param publisherName string

resource apiManagement 'Microsoft.ApiManagement/service@2024-05-01' = {
  name: 'apimtrippy${environment}'
  location: location
  sku: {
    name: 'Consumption'
    capacity: 0
  }
  properties: {
    publisherEmail: publisherEmail
    publisherName: publisherName
    virtualNetworkType: 'None'
  }
}

