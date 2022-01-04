# Rocket_Elevators_REST_API



Implemented using ASP.NET WEB API to deploy this REST API on Haroku: https://rocket-rest-ap.herokuapp.com/




Get all the interventions that are In the pending Status.

GET:

```
https://rocket-elevators-rest-api.azurewebsites.net/battery/intervention 
```


Update the status of an intervention to InProgress and the DateTime.

**** Make Sure the Spelling is Correct for the Status ****

PUT: https://rocketelevators1.azurewebsites.net/battery/intervention 

```
{ "id": 1,
"status": "InProgress"
	
}



```


Update the status of an intervention to a Completed and add the DateTime

PUT: https://rocketelevators1.azurewebsites.net/battery/intervention 

```
{ "id": 1,
"status": "Completed"
	
}




```


### API ENDPOINTS FROM LAST WEEK 

### Retrieving and Modifying The Data
<ol>
   <li>Retrieving the current status of a specific Battery</li>
   <p>https://rocketelevators1.azurewebsites.net/battery/1</p>
   
   <li>Changing the status of a specific Battery</li>
   <p>https://rocketelevators1.azurewebsites.net/battery</p>
   <p>In Postman body: {"id": "1", "status": "Inactive" }</p>
   
   <li>Retrieving the current status of a specific Column:</li>
   <p>https://rocketelevators1.azurewebsites.net/column/1</p>
   
   <li>Changing the status of a specific Column:</li>
   <p>https://rocketelevators1.azurewebsites.net/column</p>
   <p>In Postman body: {"id": "1",  "status": "Inactive" }</p>
   
   <li>Retrieving the current status of a specific Elevator:</li>
   <p>https://rocketelevators1.azurewebsites.net/elevator/1</p>
   
   <li>Changing the status of a specific Elevator:</li>
   <p>https://rocketelevators1.azurewebsites.net/elevator</p>
   <p>In Postman body: {"id": "1",  "status": "Inactive" }</p>
   
   <li>Retrieving a list of Elevators that are not in operation at the time of the request</li>
   <p>https://rocketelevators1.azurewebsites.net/elevator/inactive</p>
   
   <li>Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention</li>
   <p>https://rocketelevators1.azurewebsites.net/buildings</p>
   
   <li>Retrieving a list of Leads created in the last 30 days who have not yet become customers.</li>
   <p>https://rocketelevators1.azurewebsites.net/leads/recent</p>
</ol>
