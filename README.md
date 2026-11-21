# theumairtahir

My personal portfolio website: a Blazor Web App (.NET 10) that ports the Tailwind Plus
**Spotlight** template and uses **TailwindUi.Blazor** for its controls.

## Run

```
dotnet run --project Website/Website/Website
```

Restoring `TailwindUi.Blazor` needs the `GH_PACKAGES_USER` and `GH_PACKAGES_TOKEN`
environment variables (see `Website/nuget.config`). The build runs `npm install` and the
Tailwind CLI for you; Node.js must be installed.

## Where things live

| Path (under `Website/Website/Website`) | What |
|---|---|
| `Data/SiteContent.cs` | All copy: bio, work history, projects, articles, talks, uses. Entries marked `PLACEHOLDER` are invented. |
| `Components/Pages` | One Razor page per route, statically rendered. |
| `Components/Layout`, `Components/Ui` | Header, footer and the Spotlight building blocks. |
| `Styles/app.css` | Tailwind v4 source. Site utilities use the `sl:` prefix so they never collide with the library's bundle. |
| `wwwroot/js/site.js` | Theme toggle and mobile menu. |
