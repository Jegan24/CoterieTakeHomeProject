# CoterieTakeHomeProject
This project is a complete implementation of the requirements described by https://github.com/CoterieInsure/backend-takehome

To run, open the solution with Visual Studio and start debugging.

To test the implementation, you can use the swagger page that opens automatically. Likely https://localhost:7174/swagger/index.html, though the port may differ slightly.
You can also use the Postman desktop agent to make a POST request directly to https://localhost:7174/Quote (you must disable SSL Verification)

Example body:
{
  "revenue": 100000,
  "state": "OH",
  "business": "Plumber"
}

Time spent:
~1.5 hrs implementation, 1hr documentation.

Given more time, I would expand upon the dependency injection to allow more flexible ways of computing premium prices, finding factors and refactor the hard coded classes to be created from a JSON file.
