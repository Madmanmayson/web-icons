# web-icons
This is a collection of icons I've made across various projects, free and available to all.

## Icons
![Image of all icons](https://github.com/Madmanmayson/web-icons/blob/master/.github/iconlist-8.png?raw=true)

## Usage
Once you have a stacked SVG file either from the [Releases](https://github.com/Madmanmayson/web-icons/releases) or after making your own, you should upload it to your web server and reference it using an absolute path from root to get the most out of caching across webpages.
An example declaration of the SVG in HTML would look as follows.
```HTML
<svg><use href="[path-to-file]/symbol-defs.svg#[icon-name]"></use></svg>
```
`[path-to-file]` - the absolute path to the icon folder on your website (remove square brackets)

`[icon-name]` - the name of the icon you wish to use, either found above or the name of the original file if you made your own stack (remove square brackets but make sure to keep the # symbol before it)

## Creating your own Stack
If you wish to create your own stacked SVG file rather then use a premade one found under [Releases](https://github.com/Madmanmayson/web-icons/releases), there are a couple ways you can get the SVGStacker found in this repository to use it yourself.
1. Compile the SVGStacker program yourself using .NET Core 3.1 and run the built exe file.
2. Download a prebuilt exe file of the SVGStacker from the [Releases](https://github.com/Madmanmayson/web-icons/releases) section.

NOTE: As of this moment the SVGStacker program is a bit buggy and finicky with the file structure of the SVG input files. As of right now, it only accepts SVGs that contain a single icon that do not contain any style information for parts like strokes. In the future this will probably be cleaned up and optimized but those kinds of SVGs should not be used anyways as they don't properly scale on webpages at times, more info can be found under **Icon Requests and Submissions** 

Once you have the program you can either run it on its own or supply the path to the folder containing the icons as an argument. For the best chance of success the path you provide should be an absolute path ending with the name of the folder that contains the icons (ex: `D:\web-icons\Icons` where Icons is a folder or directory that contains all of the icons)
```shell
SVGStacker.exe <icon-folder-with-path>
```
This will output a file called `symbol-defs.svg` in the same folder as the SVGStacker.exe file which you can then host on your website to access the icons.
By making the file yourself you can choose to only include icons you want to use on your website in the Icons folder and the stacked file will only include those allowing for a smaller filesize overall. If you create it yourself the `iconname` used in the HTML tag above will be the same as the original SVG file's name without the extension.

## Icon Requests and Submissions
If you would like to request for an icon to be designed, create a new Icon Request [Issue](https://github.com/Madmanmayson/web-icons/issues/new?assignees=&labels=Icon+Request&template=icon-request.md&title=%5BREQUEST%5D+) and I will do my best to try and create an icon for your request or explain why it is not possible. 

If instead you would like to submit an icon you created, you can create a pull request that submits the svg file to the Icons folder and it will be reviewed. Upon being accepted, credit will be given in the Author section at the bottom of the readme. Do note however that the icons will be licesnsed under CC0 still so if you wish to guarantee recieving attribution when used, you should not submit your own icons.

When submitting an icon, you should make sure that it does not contain any style information especially for strokes and instead make sure the icon has been expanded to utilize paths w/fills for complex shapes in order to make sure they properly scale down on webpages.

## License
 CC0-1.0 License 
 
## Author
[@Madmanmayson](https://github.com/Madmanmayson) - Creating the initial icons and stacking program