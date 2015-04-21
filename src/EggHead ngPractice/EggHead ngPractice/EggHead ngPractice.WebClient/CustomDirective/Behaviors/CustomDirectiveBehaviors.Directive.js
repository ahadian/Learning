angular.module('custom.directive').directive('mouseEnter',function() {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function(scope,element) {
            //console.log(scope, 'scope', element, 'element');
            //element.bind("mouseenter",function() {
            //    console.log('Mouse Entered!');
            //});
            console.log(element.length);
            element[0].onmouseover= function () {
                console.log('Mouse Entered!');
            };
        }
    }
});

angular.module('custom.directive').directive('mouseEnter', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function (scope, element) {
            //console.log(scope, 'scope', element, 'element');
            //element.bind("mouseenter",function() {
            //    console.log('Mouse Entered!');
            //});
            console.log(element.length);
            element[0].onmouseover = function () {
                console.log('Mouse Entered!');
            };
        }
    }
});

/*
onabort: null
onautocomplete: null
onautocompleteerror: null
onbeforecopy: null
onbeforecut: null
onbeforepaste: null
onblur: null
oncancel: null
oncanplay: null
oncanplaythrough: null
onchange: null
onclick: null
onclose: null
oncontextmenu: null
oncopy: null
oncuechange: null
oncut: null
ondblclick: null
ondrag: null
ondragend: null
ondragenter: null
ondragleave: null
ondragover: null
ondragstart: null
ondrop: null
ondurationchange: null
onemptied: null
onended: null
onerror: null
onfocus: null
oninput: null
oninvalid: null
onkeydown: null
onkeypress: null
onkeyup: null
onload: null
onloadeddata: null
onloadedmetadata: null
onloadstart: null
onmousedown: null
onmouseenter: null
onmouseleave: null
onmousemove: null
onmouseout: null
onmouseover: null
onmouseup: null
onmousewheel: null
onpaste: null
onpause: null
onplay: null
onplaying: null
onprogress: null
onratechange: null
onreset: null
onresize: null
onscroll: null
onsearch: null
onseeked: null
onseeking: null
onselect: null
onselectstart: null
onshow: null
onstalled: null
onsubmit: null
onsuspend: null
ontimeupdate: null
ontoggle: null
onvolumechange: null
onwaiting: null
onwebkitfullscreenchange: null
onwebkitfullscreenerror: null
onwheel: null
*/