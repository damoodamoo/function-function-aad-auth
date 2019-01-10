# Function -> Function AAD Auth with MSI

This repo contains 2 projects:
- **ADFunctionApp**: Simple Azure Function app protected with AAD 'EasyAuth'
- **ADFuncClient**: Azure Function app utilising Managed Service Identity (MSI) to call the AD-secured app above.

## Set Up
Most of the work happens in the Azure portal. To get things running, clone the repo then...
- Publish the ADFunctionApp to Azure. 
- Enable AD Auth for the app:
  - In the Portal, find the Function and go to `Platform Settings` -> `Authentication / Authorization` -> Switch it on and use the AAD Express settings to create a new AAD app. 
  - Make sure you can call the Function in the browser and do the redirect dance to authenticate and eventually get the *"Authenticated Result!"* message.
  - Find the AAD App Registration in AAD, and make a note of the `ClientId` (Called `Application ID` in the Portal)
- Update the code in the ADFuncClient App:
  - Insert the `ClientId` from the step above, and enter the endpoint url for the Http call (*...azurewebsites.net/api/...*)
  - Publish the Function App to Azure
  - Find the Function in the portal and ensure `Identity` is switched on. This gives the Function Client app an identity in AAD.

Call the Function Client endpoint. If all is good it should in turn call the AD secured endpoint and return the *Authenticated Result!* message. 

That's it :)
