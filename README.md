# dotnet-weather
A fun small weather app written in .NET MVC C# 

### Description

A web application that provides information on the weather conditions at a US geographical location. The UI Design should have a modern look/feel consistent with contemporary design practices and frameworks.

### Input:
       US zip code (only US locations can be used)
UI - should validate input and display errors if the validation fails. The underlying framework should also validate the data before it is submitted for processing. 
       	
### Processing:
Using value submitted through the UI (button click), the following web services should provide the current weather conditions for a zip code:

#### Step 1: retrieve latitude/longitude based on the zip code provided:
Google API (Geocoding API to obtain latitude/longitude)
API Documentation: https://developers.google.com/maps/documentation/geocoding/start
API key: 

#### Step 2: retrieve current weather based on latitude\longitude from the previous call:
Open Weather (Weather API)
API Documentation: https://openweathermap.org/current
API key: 

### Output:
Result of the web service calls:
Success:
UI view describing the current weather for this zip code.
(Up to you how you display the weather conditions)

Create a db record storing results displayed in the UI.
(This data could be displayed again, or used in reports)

Failure:
Message in the UI 
(Example: “Submitted zip code was not found.”)

Technology:   
  * C#, MVC web project

Database Technology:
  * Developer Discretion