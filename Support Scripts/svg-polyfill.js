var cache = new Map();
var path = 'images/symbol-defs.svg'; //change to the absolute path to the svg sprite/icon file

//TODO NOTE: Add User Agent Support

window.addEventListener('load', run); //running on window.load so initial file finishes loading (allows caching)

function run(){
    //Generate XHR to GET the SVG file
    var xhr = new XMLHttpRequest();
    xhr.addEventListener('load', cacheSVG);
    xhr.open('GET',path, true);
    xhr.send();
}

function cacheSVG(){
    var iconList = this.responseXML.getElementsByTagName('symbol');

    //Generate cache of icons from the provided SVG
    for(var i = 0; i < iconList.length; i++){
        cache.set(iconList[i].id, iconList[i].childNodes);
    }
    replaceSVG();
}

function replaceSVG(){
    var svgList = document.getElementsByTagName('svg');
    var svg
    for(var i = 0; i < svgList.length; i++){

        svg = svgList[i];
        //Get the href path from the use tag in the SVG to reference the id cache and set viewbox
        var useTag = svg.querySelector('use');
        var ref = useTag.getAttribute('href') || useTag.getAttribute('xlink:href');
        svg.setAttribute('viewBox', '0 0 200 200') //TODO: Get viewbox from symbol tag

        //Clear original child elements
        while(svg.hasChildNodes()){
            svg.removeChild(svg.firstChild);
        }

        //filling in the SVG with the new path
        ref = ref.split('#');
        var newChildren = cache.get(ref[1]);
        for(var j = 0; j < newChildren.length; j++){
            svg.appendChild(newChildren[j].cloneNode(false));
        }
    }
}