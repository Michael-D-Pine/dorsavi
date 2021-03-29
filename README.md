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
  