# todo

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

## Run docker compose
Run dev project. only the client has active development
```bash
docker-compose -f docker-compose-dev.yml up --build
```
Build the full project, non dev version. Has nginx on client
```bash 
docker-compose build
```
Start
```bash
docker-compose up
```
Or build and start all in one
```bash
docker-compose up --build
```
