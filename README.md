# BoatApp
 Coding Challenge Boat App
 
 # Requirements
 - Docker needs to be installed and running
 
 # Installation
 - Clone
 - Change directory
 ```bash 
 cd BoatApp 
 ```
 - run docker compose
 ```bash
 docker compose up
 ```
 Now to fill in the static data for the database it's going to be a bit tricky.
 First we open the backend solution in visual studio. Then we gotta change up the connectionstring in the ```asppsettings.json```.
 That we need to do because docker needs to host the database in a virtual environment but we are feeding it in our localhost.
 
 So we needs to change the `host` from `db` to `localhost`.
 Then we can run the `Update-Database` command in the package manager console. This feeds the database with static data. Of course you're also free to feed it through sql on pgadmin. 
 
 As for security I highly recommend changing up the jwt secret-key as well as all the other sensible data in the appsettings and the docker compose file if this project is used in production.
