# INit starting out this project
do migrations - no db connection needed, just creates classes
```bash
dotnet ef migrations add InitialMigration
```

Create the react app
```bash
npx create-react-app react-aspcore-crud1
# or with npm
npm init react-app react-aspcore-crud1
```
Build https local cert
```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\ReactAspCoreCrud1.pfx -p Pa55w0rd!
dotnet dev-certs https --trust
dotnet user-secrets set "Kestrel:Certificates:Development:Password" "Pa55w0rd!"
```

## Running local development
Run dev project. only the client has active development
```bash
docker-compose -f docker-compose-dev.yml build --no-cache
```
Start
```bash
docker-compose -f docker-compose-dev.yml up
```

## Running the "prod" environment
build the images
> add `--no-cache` if having errors or needing rebuild
```bash
# build the client
docker build -f ./react-aspcore-crud1/Dockerfile -t client_react_crud1_image ./react-aspcore-crud1/
# build the back end
docker build -t aspnet_react_crud1_image .
```
Then Run the images in docker-compose
```bash
docker-compose up -d
```
Then View the application at `http://localhost/`, no SSL setup on client just api


## Running the dev environment with live reloading on client and api
build
```bash
docker-compose -f docker-compose-dev.yml build --no-cache
```