// Theme toggle and mobile menu for the statically rendered site. No Blazor circuit needed.
// Uses the same localStorage key as TailwindUi.Blazor's ThemeSwitcher, so the two stay in sync.
(function () {
  var KEY = 'tailwindui-blazor-theme';
  var media = window.matchMedia('(prefers-color-scheme: dark)');

  function stored() {
    try { return localStorage.getItem(KEY); } catch (_) { return null; }
  }

  function isDark() {
    var value = stored();
    if (value === 'dark') return true;
    if (value === 'light') return false;
    return media.matches;
  }

  function apply() {
    document.documentElement.classList.toggle('dark', isDark());
  }

  apply();
  media.addEventListener('change', apply);

  document.addEventListener('click', function (event) {
    if (event.target.closest('[data-theme-toggle]')) {
      var dark = !document.documentElement.classList.contains('dark');
      // Choosing what the OS already prefers goes back to following the OS.
      var value = dark === media.matches ? 'system' : dark ? 'dark' : 'light';
      try { localStorage.setItem(KEY, value); } catch (_) { /* private mode */ }
      document.documentElement.classList.toggle('dark', dark);
      return;
    }

    // Close the mobile menu when one of its links is followed.
    var link = event.target.closest('[popover] a');
    if (link) link.closest('[popover]').hidePopover();
  });

  // Enhanced navigation patches the document in place; keep the theme class on <html>.
  document.addEventListener('DOMContentLoaded', function () {
    if (window.Blazor && Blazor.addEventListener) Blazor.addEventListener('enhancedload', apply);
  });
})();
