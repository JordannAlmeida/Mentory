# Description

This is a repository dedicated to study of azure cloud with some anotations about the services and most important components of this cloud.

# Organization

Azure organize your services as "resources". A resource is a abstraction of a service as VM, database, storage, etc. This resources can be organized by type (e.g. resource group of databases), lifecycle (resource group of production environment), billing, etc;


![resource group organization](<assets/Captura de tela 2024-11-30 143931.png>)

whe can edit resources using resource management

![alt text](<assets/Captura de tela 2024-11-30 145625.png>)

hierarchical structure still contains the subscription, Tenant and Access by Azure AD:

### 1. Azure Active Directory (Azure AD)
Azure Active Directory (Azure AD) is the foundational identity and access management service in Azure. It handles user authentication and authorization to all Azure resources and services.
It manages users, groups, and roles, allowing you to assign permissions for access to resources.
Azure AD also integrates with other Microsoft services (like Office 365) and third-party applications, and provides security features like Multi-Factor Authentication (MFA).
### 2. Tenant
Tenant refers to an instance of Azure AD. A single Azure AD tenant represents an organization and provides access to Azure services within that tenant.
You can have multiple subscriptions under a single Azure AD tenant, but all users and resources are governed by the policies of the tenant.
### 3. Subscription
Subscription is the next level in the hierarchy and is associated with a specific Azure account. It provides access to Azure services and resources and defines billing boundaries.
Each subscription is tied to a tenant, and can be assigned a specific billing model (e.g., Pay-As-You-Go, Enterprise Agreement).
You can have multiple subscriptions under a single Azure AD tenant, allowing for better organization and management (e.g., different departments, environments like dev/test/prod, or regions).
Subscriptions are also where you define and enforce policies, quotas, and compliance rules.

```
Azure Active Directory (Azure AD) Tenant
|
|-- Management Groups (Optional, for larger organizations)
|
|-- Subscription
    |
    |-- Resource Group
        |
        |-- Resources (e.g., VMs, Storage, Databases)
```

# Compute Services

To view All in this [App Service](./AppService/README.MD)

Compare with another resoucers:

![alt text](<assets/Captura de tela 2024-11-30 151139.png>)

![alt text](<assets/Captura de tela 2024-11-30 151408.png>)

![alt text](<assets/Captura de tela 2024-11-30 151520.png>)

# Virtual Network

![alt text](<assets/Captura de tela 2024-11-30 152017.png>)

We can Vnet peering vs VPN gateway [here](./network/vnetPeeringVsVPN/README.MD)



# References:

https://www.youtube.com/playlist?list=PLGjZwEtPN7j-Q59JYso3L4_yoCjj2syrM