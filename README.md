# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test
To build and run with docker compose:
* From root directory run `docker-compose up -d --build`
* Navigate to localhost:54331

To build a component into docker image: 
* From root dir run: `docker image build . -t webspa:1.0 -f src/webspa/Dockerfile`
* To run image: `docker container run -d -p 8080:80 --name webspa webspa:1.0`

# Contribute

To add migration for BlogAPI:
* From BlogAPI directory run: `dotnet ef migrations add <MIGRATION NAME> -o DataContext\Migrations`