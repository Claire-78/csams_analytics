# CSAMS Analytics
## Jira link
https://dev.imt.hig.no/tracker/projects/CSAMSAN/summary

# How to launch the project

## Database

The database is located at Backend/CSAMS/Data, with the last folder not existing on gitlab.
The database is in the format of .sqlite as it was the best way to make the least work for the group.
It meant that only one of us was requried to mess with database connections as all the others would simply just have to copy paste the database into the folder and it would work.

### How to change the database

The location of the database in the code is currently located at Backend/CSAMS/Models/AppDbContext.cs at line 23
How to set up a connection string can be found at https://docs.microsoft.com/en-us/ef/ef6/fundamentals/configuring/connection-strings

## Using the backend

To check for if the backend works, it will be simplest to check if one page works.
When the applications starts running, the log window will give two ports for the program.
Only the first port will work, as the 2nd is insecure. Fastest way to see if the database connection is there is by checking [url]/api/sample/user

## Starting the frontend

To start the frontend, navigate a command promt to React/test-http and run "npm install" in the promt
Once everything is installed, run "npm start" in the promt to start the frontend.
Check any page while the backend is running to see if the connection is there.
If the connection fails, check test-http/src/Component/AssiComments.js and look at the link on line 20.
Check if the port on the link is the same as the one on the backend, and if not, change the backend port.

The port for the frontend is found at test-http/package.json on line 22