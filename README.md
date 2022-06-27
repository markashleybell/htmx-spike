# htmx-spike

Learning about [htmx](https://htmx.org/docs/).

## References

* https://htmx.org/docs/
* https://www.jetbrains.com/dotnet/guide/tutorials/htmx-aspnetcore/
* https://github.com/khalidabuhakmeh/htmx.net

## Gotchas

* You need to call `htmx.process(element)` for htmx to work with dynamically added HTML elements: https://htmx.org/docs/#3rd-party
* `throttle` doesn't work like `debounce`!! Use `delay` in conjunction with `hx-sync` instead ([see last example here](https://htmx.org/attributes/hx-sync/)), which does what you want in most cases where you'd use a debounce function.
