namespace Website.Components.Layout;

public sealed record NavEntry(string Href, string Label);

public static class SiteNav
{
	public static readonly NavEntry[] Links =
	[
		new("/about", "About"),
		new("/articles", "Articles"),
		new("/projects", "Projects"),
		new("/speaking", "Speaking"),
		new("/uses", "Uses"),
	];
}
