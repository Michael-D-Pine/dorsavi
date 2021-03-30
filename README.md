# dorsavi

- To run the front end 

The project was built assuming it is hosted at /.
You can control this with the homepage field in your package.json.

The build folder is ready to be deployed.
You may serve it with a static server:

  npm install -g serve
  serve -s build

- The azure functions can be run by simply func start --port:5800

- The react app hard coded this url to be locahost with that port number but
  in real life this would be taken from a environment variable or loaded
  from a service to call the API, we tend to use enviornment variables
  defined in the docker container settings and react simply sucks
  them in

- the nuget package I just created a local repo instead of serving up to nuget
  or somewhere else. We do use nuget packages and create many of them ourselves
  and we serve the feed as Azure Repo Artefacts
  
- Was unable to get the nuget specific working correctly the mix of dotnet pack/nuget pack
  was causing me issues and I just don't have the time to sort this out, sorry. I have
  included the sample.dll c++ dll into the back project as everything will run as is
  including the functions

- the code for the sample c++ dll is in the top level "sample" folder

- We do use many Nuget packages for internal libraries but none of them call c++ dlls!

- We have built interal libaries for all integration pieces e.g Sql library that implemements
  dapper against Azure Sql so if we ever change database we are literally able to re engineer
  that component within reasobable bounds we use it for all Sql access including Bulk operations