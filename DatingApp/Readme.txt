npm install bootstrap font-awesome
---------
Angular v6 Snippets
Angular Language Service
Angular Files
Angular2-switcher
Auto Rename Tag
Bracket Pair Colorizer
Debugger for Chrome
Material Icon Thame
Path Intellisense
Prettier - Code Formatter
TSLint
--------------

Go to the definition of variables/functions when press f12 within html.

Switch .ts|.html|.css|.spec.ts fastly.

alt+o(Windows) shift+alt+o(macOS)

if on .ts|.css|.spec.ts: go to html
if on .html: go to previous

alt+i(Windows) shift+alt+i(macOS)

if on .ts|.html|.spec.ts: go to css
if on .css: go to previous

alt+u(Windows) shift+alt+u(macOS)

if on .css|.html|.spec.ts: go to ts
if on ts: go to previous

alt+p(Windows) shift+alt+p(macOS)

if on .ts|.css|.html: go to spec.ts
if on .spec.ts: go to previous
---
Using Command Palette (CMD/CTRL + Shift + P)

1. CMD + Shift + P -> Format Document
OR
1. Select the text you want to Prettify
2. CMD + Shift + P -> Format Selection
Custom keybindings

If you don't like the defaults, you can rebind editor.action.formatDocument and editor.action.formatSelection in the keyboard shortcuts menu of vscode.

Format On Save

Respects editor.formatOnSave setting.

You can turn on format-on-save on a per-language basis by scoping the setting:

// Set the default
"editor.formatOnSave": false,
// Enable per-language
"[javascript]": {
    "editor.formatOnSave": true
}