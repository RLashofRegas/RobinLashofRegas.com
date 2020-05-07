# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started

## Install Dev Dependencies

### Linux

Install node.js and npm:
- archlinux: `sudo pacman -S nodejs npm`

Install angular:
- `npm install -g @angular/cli`

Install .NET Core:
- archlinux: `sudo pacman -S dotnet-runtime dotnet-sdk`

Install docker and docker-compose:
- archlinux: `sudo pacman -S docker-compose`

## Build and Test
To build and run with docker compose:
* start/enable docker daemon
* make sure the docker daemon is running: `docker info`

* From root directory run `docker-compose up -d --build`
* Navigate to localhost:5431

To build a component into docker image: 
* From root dir run: `docker image build . -t webspa:1.0 -f src/webspa/Dockerfile`
* To run image: `docker container run -d -p 8080:80 --name webspa webspa:1.0`

To connect to running database container:
* run `docker network ls` to get the name of the network (probably robinlashofregascom_com.robinlashofregas.network)
* run `docker run -it --network <NETWORK NAME> --rm mariadb mysql -hsqldb -uroot -p`
    - docker run runs a new container
    - -it means interactive mode (i) and attach stdin and stdout to terminal (t)
    - --rm specifies to remove the container on exit
    - mariadb is the image to run
    - mysql is the command to run against the container
    - specifies the host of the db, sqldb in this case because new container is being added to same network
    - -u is username
    - -p specifies to ask for password

Common MySql Commands reference: http://g2pc1.bu.edu/~qzpeng/manual/MySQL%20Commands.htm

# Contribute

To add migration for BlogAPI:
* Install dotnet ef CLI tool: `dotnet tool install --global dotnet-ef --version 3.0.0`
* From BlogAPI directory run (on linux use `DataContext/Migrations`): `dotnet ef migrations add <MIGRATION NAME> -o DataContext\Migrations`