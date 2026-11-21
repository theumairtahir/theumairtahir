namespace Website.Data;

public sealed record SocialLink(string Network, string Label, string Url);

public sealed record Highlight(string Value, string Label);

public sealed record Role(string Company, string Title, string Start, string End, string Summary, string[] Stack)
{
	public string Initial => Company[..1];
}

public sealed record Project(string Name, string Description, string LinkLabel, string Url, string Icon, string[] Stack);

public sealed record Article(string Slug, string Title, DateOnly Date, string Description, string BodyHtml);

public sealed record Talk(string Title, string Event, string Description, string Cta, string Url);

public sealed record TalkGroup(string Title, Talk[] Talks);

public sealed record Tool(string Name, string Description);

public sealed record ToolGroup(string Title, Tool[] Tools);

/// <summary>
/// Every piece of copy on the site lives here, so the pages stay layout-only.
/// Entries marked PLACEHOLDER are invented and should be replaced with real details.
/// </summary>
public static class SiteContent
{
	public const string Name = "Umair Tahir";
	public const string JobTitle = "Senior Software Developer";
	public const string Headline = "Senior software developer, .NET architect, and builder of calm systems.";

	public const string Intro =
		"I’m Umair, a senior software developer who has spent the last decade building products on .NET, Blazor and Azure. " +
		"I work at NimbleLoop Technologies, where I lead engineering on Marksheet+ and maintain TailwindUi.Blazor, " +
		"a component library that brings Tailwind Plus to Blazor.";

	// PLACEHOLDER: contact address and CV link.
	public const string Email = "hello@theumairtahir.com";
	public const string CvUrl = "#";

	public static readonly SocialLink[] Socials =
	[
		new("github", "Follow on GitHub", "https://github.com/theumairtahir"),
		// PLACEHOLDER: LinkedIn and X handles.
		new("linkedin", "Follow on LinkedIn", "https://www.linkedin.com/in/theumairtahir"),
		new("x", "Follow on X", "https://x.com/theumairtahir"),
	];

	// PLACEHOLDER: the numbers are illustrative.
	public static readonly Highlight[] Highlights =
	[
		new("10+", "years shipping production software"),
		new("100+", "Blazor components published"),
		new(".NET 10", "Blazor, Azure Functions, Service Bus"),
		new("40+", "schools running on software I built"),
		new("0", "pages that need a circuit to render"),
	];

	// PLACEHOLDER: everything except the NimbleLoop entry is invented.
	public static readonly Role[] Work =
	[
		new("NimbleLoop Technologies", "Senior Software Developer", "2021", "Present",
			"Lead engineering on Marksheet+, a multi-tenant school management platform, and maintain the TailwindUi.Blazor component library.",
			["C#", "Blazor", "Azure Functions", "Service Bus", "SignalR"]),
		new("Northwind Systems", "Software Engineer", "2018", "2021",
			"Split a billing monolith into vertical slices and moved its batch jobs to queue-driven workers.",
			["ASP.NET Core", "SQL Server", "RabbitMQ"]),
		new("Fabrikam Digital", "Full-stack Developer", "2016", "2018",
			"Built line-of-business web apps for logistics and retail clients.",
			["ASP.NET MVC", "Angular", "EF Core"]),
		new("Contoso Labs", "Junior Developer", "2014", "2016",
			"Maintained internal reporting tools and wrote my first production migrations.",
			["C#", "WinForms", "T-SQL"]),
	];

	public static readonly Project[] Projects =
	[
		new("Marksheet+",
			"A multi-tenant school management platform: admissions, classes, sessions, results and parent communication, built as vertical slices on .NET with a Blazor WebAssembly front end.",
			"marksheetplus.com", "#", "academic-cap",
			["Blazor WASM", "Azure Functions", "Service Bus", "MongoDB"]),
		new("TailwindUi.Blazor",
			"More than a hundred Razor components that port the Tailwind Plus design system to Blazor, themed through eight semantic colors with first-class dark mode.",
			"github.com", "https://github.com/NimbleLoop-Technologies/TailwindUi.Blazor", "squares-2x2",
			["Blazor", "Tailwind v4", "bUnit"]),
		new("theumairtahir.com",
			"This site. A statically rendered Blazor Web App that ports the Spotlight template and uses TailwindUi.Blazor for its controls.",
			"github.com", "https://github.com/theumairtahir/theumairtahir", "globe-alt",
			["Blazor SSR", "Tailwind v4"]),
		// PLACEHOLDER: the next three projects are invented.
		new("QueueLens",
			"A command-line inspector for Azure Service Bus dead-letter queues. Search, replay and export poisoned messages without writing a script each time.",
			"github.com", "#", "queue-list",
			[".NET tool", "Service Bus"]),
		new("SliceKit",
			"A dotnet new template for vertical-slice APIs: one folder per feature, with validation, endpoint mapping and tests already wired together.",
			"github.com", "#", "rectangle-stack",
			["ASP.NET Core", "Templates"]),
		new("TenantGuard",
			"EF Core interceptors and analyzers that make it hard to forget a tenant filter, plus tests that fail when a query leaks across tenants.",
			"github.com", "#", "shield-check",
			["EF Core", "Roslyn"]),
	];

	// PLACEHOLDER: the articles are sample writing to show the layout.
	public static readonly Article[] Articles =
	[
		new("static-ssr-first-blazor",
			"Static SSR first: when Blazor doesn’t need a circuit",
			new DateOnly(2026, 10, 12),
			"Most pages are documents. Rendering them as plain HTML and adding interactivity only where a user actually interacts keeps a Blazor site fast and cheap to host.",
			"""
			<p>When Blazor Web Apps arrived, the default advice was to pick a render mode for the whole app. I now start from the other end: every page is static server-side rendering until something on it proves it needs more.</p>
			<h2>What static SSR already covers</h2>
			<p>Navigation, forms, streaming rendering and enhanced page loads all work without a WebSocket or a WebAssembly download. A portfolio, a marketing site and most of an admin area are documents with links between them.</p>
			<h2>Where interactivity earns its place</h2>
			<p>A data grid with inline editing, a live dashboard, a drag-and-drop planner. Those get an interactive island, and the island is the only part of the page that pays for it.</p>
			<p>This site follows that rule. The theme toggle and the mobile menu are a few lines of JavaScript and the browser’s popover API. No circuit is opened for any page.</p>
			"""),
		new("porting-tailwind-plus-to-blazor",
			"Porting Tailwind Plus to Blazor: lessons from 100 components",
			new DateOnly(2026, 7, 8),
			"What I learned turning a library of HTML snippets into typed Razor components, and why semantic color slots mattered more than any single component.",
			"""
			<p>Tailwind Plus ships as HTML and React. Using it from Blazor meant copying markup into every project and keeping each copy in sync by hand. TailwindUi.Blazor started as a way to stop doing that.</p>
			<h2>Parameters are the API</h2>
			<p>A snippet has no API. A component does, and every parameter is a promise. We kept enums small, gave everything a sensible default and let attribute splatting cover the long tail.</p>
			<h2>Semantic colors over literal hues</h2>
			<p>Components never say indigo. They say Primary, and the host app decides what that means with a few CSS variables. Re-skinning a whole product became a stylesheet change.</p>
			<h2>Ship the CSS</h2>
			<p>The library builds its own Tailwind bundle, so a consumer links one file and every component is styled. Apps that write their own utilities run their own build alongside it.</p>
			"""),
		new("vertical-slices-two-years-on",
			"Vertical slices in a .NET monolith: what held up after two years",
			new DateOnly(2026, 3, 21),
			"We organized a multi-tenant product by feature instead of by layer. Here is what still works, what we changed, and what I would do differently.",
			"""
			<p>Two years ago we reorganized Marksheet+ around features. Each use case owns its endpoint, validator, handler and tests, and lives in one folder.</p>
			<h2>What held up</h2>
			<p>Changes stay local. A new developer can read one folder and understand one behavior. Code review got faster because a pull request rarely touches more than two slices.</p>
			<h2>What we changed</h2>
			<p>Shared rules crept into slices as copies. We now pull a rule into the domain model the second time it appears, not the third.</p>
			<h2>What I would do differently</h2>
			<p>Decide early how slices talk to each other. We settled on events over a service bus, and wish we had done that before the first cross-slice call was written.</p>
			"""),
	];

	// PLACEHOLDER: the talks and podcasts are invented.
	public static readonly TalkGroup[] Speaking =
	[
		new("Conferences",
		[
			new("Static first: Blazor without the circuit", ".NET Conf Community Edition 2026",
				"A walk through render modes, and a case for treating interactivity as an opt-in island instead of an app-wide default.",
				"Watch video", "#"),
			new("A design system your Blazor team will actually use", "DevDay 2025",
				"How we turned a folder of copied snippets into a typed component library with theming, dark mode and a test suite.",
				"Watch video", "#"),
		]),
		new("Podcasts",
		[
			new("Multi-tenancy without the midnight pages", "The Modern .NET Show, episode 142",
				"Tenant isolation, noisy neighbors, and the guard rails that let a small team run a product for many schools.",
				"Listen to podcast", "#"),
			new("Shipping a component library as a side effect", "Blazor Weekly, episode 67",
				"Why the best internal tools start as something you needed twice.",
				"Listen to podcast", "#"),
		]),
	];

	// PLACEHOLDER: adjust to the setup you really use.
	public static readonly ToolGroup[] Uses =
	[
		new("Workstation",
		[
			new("Custom desktop, Ryzen 9, 64GB RAM", "Windows 11 Pro with Hyper-V and WSL. Builds the whole solution and runs the emulators without complaint."),
			new("Two 27” 4K displays", "Editor on one, the running app and its logs on the other."),
			new("Keychron Q1 Pro", "Tactile switches, and a volume knob I use more than I expected."),
		]),
		new("Development tools",
		[
			new("Visual Studio 2026", "Still the best debugger for .NET, and Hot Reload has become dependable for Razor."),
			new("Claude Code", "Pairing on refactors, reviews and the boring parts of a migration."),
			new("Docker Desktop", "SQL Server, MongoDB and the Service Bus emulator, one compose file per project."),
			new("Windows Terminal with PowerShell", "A profile per repository and a handful of well-worn aliases."),
		]),
		new("Stack",
		[
			new(".NET 10 and C#", "The language keeps getting out of the way."),
			new("Blazor", "One component model for server-rendered pages and rich client apps."),
			new("Azure Functions and Service Bus", "Queue-driven workers for everything that does not need to answer right now."),
			new("Tailwind CSS v4", "Design tokens as CSS variables, with no config file to maintain."),
		]),
		new("Productivity",
		[
			new("ClickUp", "Backlog, sprints and the occasional grocery list."),
			new("Figma", "For reading designs more often than drawing them."),
			new("Fireflies", "Meeting notes I can search instead of rewatch."),
		]),
	];

	public static Article? FindArticle(string slug) =>
		Articles.FirstOrDefault(article => string.Equals(article.Slug, slug, StringComparison.OrdinalIgnoreCase));
}
