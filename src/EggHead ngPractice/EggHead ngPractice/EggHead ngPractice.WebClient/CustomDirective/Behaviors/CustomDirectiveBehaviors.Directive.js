angular.module('custom.directive').controller('myCtrl', ['$scope',function($scope) {
    $scope.sayHi = function() {
        console.log('Hi Cortana');
    }
    $scope.sayBye = function () {
        console.log('Bye Cortana');
    }
}]);

angular.module('custom.directive').directive('mouseEnter', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function (scope, element,attrs) {
            console.log(attrs);
            //element[0].onmouseover = function () {
            //    console.log('Mouse Entered!');
            //};
            
            element.bind("mouseenter", function () {
                element.removeClass("redClass");
                element.addClass("blueClass");
                //console.log('Mouse Entered!', attrs);
                scope.$apply(attrs.invokeHi);

            });
            element.on("mouseleave", function () {
                element.addClass("redClass");
                element.removeClass("blueClass");
                //console.log('Mouse Leaved!');
                scope.$apply(attrs.invokeBye);
            });
        }
    }
});

/*
onabort: null ~
onautocomplete: null~
onautocompleteerror: null!~
onbeforecopy: null~
onbeforecut: null~
onbeforepaste: null~
onblur: null~
oncancel: null~
oncanplay: null~
oncanplaythrough: null~
onchange: null~
onclick: null~!
onclose: null~
oncontextmenu: null~
oncopy: null~
oncuechange: null~
oncut: null~
ondblclick: null~
ondrag: null~
ondragend: null~
ondragenter: null~
ondragleave: null~
ondragover: null~
ondragstart: null~
ondrop: null~
ondurationchange: null~
onemptied: null~
onended: null~
onerror: null~
onfocus: null~
oninput: null~
oninvalid: null~
onkeydown: null~
onkeypress: null~
onkeyup: null~
onload: null~
onloadeddata: null~
onloadedmetadata: null~
onloadstart: null~
onmousedown: null~
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