# web-icons
This is a collection of icons I've made across various projects, free and available to all.

## Icons
![Image of all icons](https://github.com/Madmanmayson/web-icons/blob/master/.github/iconlist-8.png?raw=true)

## Usage
Download either the regular or minified version of the Stacked SVG file from [Releases](https://github.com/Madmanmayson/web-icons/releases) or the [.dist](https://github.com/Madmanmayson/web-icons/tree/master/.dist) folder in this repo and upload it to your web server. Once that is done, you can use the icons by adding an `<svg>` tag to your web page and a `<use>` tag inside the `<svg>` tag as seen below. 
An example declaration of the SVG in HTML would look as follows.
```HTML
<svg><use href="[path-to-file]/symbol-defs.svg#[icon-name]"></use></svg>
```
`[path-to-file]` - the absolute path to the icon folder on your website (remove square brackets)

`[icon-name]` - the name of the icon you wish to use, either found above or the name of the original file if you made your own stack (remove square brackets but make sure to keep the # symbol before it)
<br>
Fully filled out example:
```HTML
<svg class="icon"><use href="/images/symbol-defs.svg#energy"></use></svg>
```

Any styling you wish to do such as sizing or changing the fill color should be done in a CSS class and attached to the `<svg>` tag as seen with the `icon` class above.
<br>
<br>

## Icon Requests and Submissions
If you would like to request for an icon to be designed, create a new [Icon Request Issue](https://github.com/Madmanmayson/web-icons/issues/new?assignees=&labels=Icon+Request&template=icon-request.md&title=%5BREQUEST%5D+) and I will do my best to try and create an icon for your request or explain why it is not possible. 

If instead you would like to submit an icon you created, you can create a pull request that submits the svg file to the Icons folder and it will be reviewed. Upon being accepted, credit will be given in the Author section at the bottom of the readme. Do note however that the icons will be licesnsed under CC0 still so if you wish to guarantee recieving attribution when used, you should not submit your own icons.

When submitting an icon, you should make sure that it does not contain any style information especially for strokes and instead make sure the icon has been expanded to utilize paths w/ fills for complex shapes in order to make sure they properly scale down on webpages.

## License
 CC0-1.0 License 
 
## Author
[@Madmanmayson](https://github.com/Madmanmayson) - Creating the initial icons and stacking program
