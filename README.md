# PowerliftMeet

PowerliftMeet is a meet-management app for powerlifting competitions, with an Angular/Ionic frontend and a .NET (ASP.NET Core) backend API backed by PostgreSQL.

## Project structure

```
PowerliftMeet/
├── Backend/PowerliftMeet/
│   ├── PowerliftMeet.Api/         # ASP.NET Core Web API (controllers, DTOs, auth)
│   ├── PowerliftMeet.Database/    # EF Core DbContext, entities, migrations
│   └── PowerliftMeet.Tests/       # Backend unit tests
└── powerlift-meet/                # Ionic/Angular frontend (also buildable as a Capacitor mobile app)
```

## Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download) (backend targets `net10.0`)
- [Node.js](https://nodejs.org/) 18+ and npm (frontend uses Angular 20 / Ionic 8)
- [PostgreSQL](https://www.postgresql.org/download/) running locally (or accessible via connection string)
- Angular CLI (optional, for convenience): `npm install -g @angular/cli`
- A Google OAuth 2.0 Client ID/Secret if you want Google sign-in to work locally ([Google Cloud Console](https://console.cloud.google.com/apis/credentials))

## Backend setup (`Backend/PowerliftMeet`)

1. Create a local PostgreSQL database, e.g. `PowerliftMeet`.
2. Add an `appsettings.Development.json` file inside `Backend/PowerliftMeet/PowerliftMeet.Api/` (this file is gitignored, so it won't be committed):

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=PowerliftMeet;Username=<your-pg-user>;Password=<your-pg-password>"
     },
     "Jwt": {
       "Key": "<a-long-random-secret-key>",
       "Issuer": "http://localhost:5135"
     },
     "Authentication": {
       "Google": {
         "ClientId": "<your-google-client-id>",
         "ClientSecret": "<your-google-client-secret>"
       }
     },
     "App": {
       "FrontendUrl": "http://localhost:8100"
     }
   }
   ```

3. Restore dependencies and apply database migrations (migrations run automatically on startup, but you can also apply them manually):

   ```bash
   cd Backend/PowerliftMeet
   dotnet restore
   dotnet ef database update --project PowerliftMeet.Database --startup-project PowerliftMeet.Api
   ```

4. Run the API:

   ```bash
   dotnet run --project PowerliftMeet.Api
   ```

   The API listens on `http://localhost:5135` (and `https://localhost:7291` for the `https` profile). Swagger UI is served at the root (`http://localhost:5135/`).

5. Run backend tests:

   ```bash
   dotnet test
   ```

## Frontend setup (`powerlift-meet`)

1. Install dependencies:

   ```bash
   cd powerlift-meet
   npm install
   ```

2. The frontend reads the API URL from `src/environments/environment.ts` (already set to `http://localhost:5135/api` for local dev). Update this if your backend runs on a different host/port.

3. Run the dev server:

   ```bash
   npm start
   ```

   This runs `ng serve`; the app is available at `http://localhost:4200` by default. If you're testing Google login end-to-end, note the backend's `App:FrontendUrl` expects the app on `http://localhost:8100` (Ionic's default serve port) — run `ionic serve` instead if you need that to line up, or update `App:FrontendUrl` in your `appsettings.Development.json`.

4. Run frontend unit tests:

   ```bash
   npm test
   ```

5. Lint:

   ```bash
   npm run lint
   ```

### Mobile builds (Capacitor)

The frontend is also configured as a Capacitor app (`capacitor.config.ts`, `ionic.config.json`). After building the web assets (`npm run build`), use the Capacitor CLI (`npx cap sync`, `npx cap open android|ios`) if you need to build/run the native shells.

## Environment variables & secrets

- Backend secrets (DB connection string, JWT signing key, Google OAuth credentials) live in `appsettings.Development.json` / `appsettings.Production.json`, both gitignored. Never commit real secrets — use the placeholder template above.

## Notes

- The backend uses PostgreSQL via Npgsql/EF Core; migrations live in `PowerliftMeet.Database/Migrations` and apply automatically at API startup.
- CORS is currently wide open (`AllowAnyOrigin`) for development convenience — tighten this before any production deployment beyond what's already configured.
