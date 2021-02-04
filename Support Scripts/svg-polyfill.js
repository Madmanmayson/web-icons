let cache = new Map();
let path = 'images/symbol-defs.svg'; //change to the absolute path to the svg sprite/icon file

window.addEventListener('load', run); //running on window.load so initial file finishes loading (allows caching)

function run(){
    //Generate XHR to GET the SVG file
    let xhr = new XMLHttpRequest();
    xhr.addEventListener('load', cacheSVG);
    xhr.open('GET',path, true);
    xhr.send();
}

function cacheSVG(evt){
    let iconList = this.responseXML.getElementsByTagName('symbol');

    //Generate cache of icons from the provided SVG
    for(let icon of iconList){
        cache.set(icon.id, icon.childNodes);
    }
    replaceSVG();
}

function replaceSVG(){
    let svgList = document.getElementsByTagName('svg');
    for(let svg of svgList){

        //Get the href path from the use tag in the SVG to reference the id cache and set viewbox
        let useTag = svg.querySelector('use');
        let ref = useTag.getAttribute('href') || useTag.getAttribute('xlink:href');
        svg.setAttribute('viewBox', '0 0 200 200')

        //Clear original child elements
        while(svg.hasChildNodes()){
            svg.removeChild(svg.firstChild);
        }

        //filling in the SVG with the new path
        ref = ref.split('#');
        let newChildren = cache.get(ref[1]);
        console.log(newChildren)
        for(let i = 0; i < newChildren.length; i++){
            svg.appendChild(newChildren[i].cloneNode(false));
        }
    }
}