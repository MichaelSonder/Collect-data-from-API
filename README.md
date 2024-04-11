# Spotify API Integration Project

## Introduktion
Dette projekt er en ASP.NET Core MVC applikation, der integrerer med Spotify's API for at hente og vise nye musikudgivelser.

## Funktioner
- Henter adgangstoken fra Spotify's API ved hjælp af klientens legitimationsoplysninger.
- Henter en liste af nye udgivelser fra Spotify's API ved hjælp af adgangstokenet.
- Viser de nye udgivelser til brugeren.

## Klasser
- `SpotifyAccountService`: En service, der henter en adgangstoken fra Spotify's API ved hjælp af klientens legitimationsoplysninger.
- `SpotifyService`: En service, der henter en liste af nye udgivelser fra Spotify's API ved hjælp af en adgangstoken.
- `SpotifyController`: En controller, der håndterer interaktionen mellem brugeren og Spotify's API ved at hente nye udgivelser og vise dem til brugeren.

## Husk
- Indtast dine Spotify klient legitimationsoplysninger i `appsettings.json`.
- Jeg har fjernet dem via gitignore.
