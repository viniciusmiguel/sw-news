# Skyworks News Test App

To deploy this application a resource group called "sw-news-rg" needs to be created and
two secrets must be created and added to github secrets:
Command to create in Azure CLI:
az ad sp create-for-rbac --name "skyworkz-news-github" --role Contributor --scopes /subscriptions/{YOUR SUBSCRIPTION ID}/resourceGroups/skyworkz-news-rg --sdk-auth
AZURE_CREDENTIALS
format:
```json
{
  "appId": "xxxxxx",
  "displayName": "xxxxx",
  "name": "http://azure-cli-xxxxxx",
  "password": "xxxxx",
  "tenant": "xxxxx"
}
```
and AZURE_SP_SECRET
This service principal is used by AGIC to control the gateway
Command to create in Azure CLI:
az ad sp create-for-rbac --name "skyworkz-news-agic" --sdk-auth --role Contributor | base64 -w0

format: the output is a long key.

The sample application was developed using .net core.
It exposes a simple frontend using Razor pages and
a api with the following routes:
https://ip/api/news GET - return the list of news in JSON.
https://ip/api/news/uuid GET - return a specific news article by id in JSON.
https://ip/api/news POST 

POST payload : JSON
```json
{
    "Title" : "Your title",
    "Description" : "Your article description"
}
```
Both fields are mandatory. The api is only validating if the request is valid.
No domain validation was implemented to inspect the data.
WAF is active to intercept common OWASP attacks.

The diagram bellow illustatres, in general, the IaC:

![](https://raw.githubusercontent.com/viniciusmiguel/sw-news/master/diagram.png)

Improvements:
No DNS infra was deployed, for that a domain must be setup.
The digital certificate is self signed. With a domain a cert-manager chart could be deployed to letsencrypt it :)
The Application Gateway is doing the SSL offloading, for higher security scenarios the pods could have certificates
and talk only https.
Firewalls where not implemented inside the v-net to isolated the subnets.
Application domain should validate field content also.
Missing unit and integration tests. 
Define more granular roles for the service principals used in the automation.