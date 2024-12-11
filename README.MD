# Full-stack .NET online shop app
This repo contains end of semester project for ASP.NET Course - full-stack .NET app of online shop.
It contains two solutions - `WebApi` with backend code and `WebShop` with frontend.

## File structure
### Database
Database directory contains everything needed to understand database schema and to reconstruct the database locally.
in `/description` there is a schema of the database, while in `/sql` you can find sql queries to create tables and to populate it with mock data.
### WebApi
Backend
### WebShop
Frontend

## How to run
### Database setup
- Create 'ShopDb' in your Microsoft SQL Server.
- Copy connection string data, keep it for a moment
- Run `init_tables.sql`
- Run `populate_tables.sql`
### Backend setup
- Start `WebApi.csproj` in a VS instance
- Run `dotnet restore` to install all needed packages
- Replace connection string with your own
- Run it
### Frontend setup
- Start `WebShop.csproj` in a VS instance
- Run `dotnet restore` to install all needed packages
- Run it


When you start project again, you need to start it in this sequence.