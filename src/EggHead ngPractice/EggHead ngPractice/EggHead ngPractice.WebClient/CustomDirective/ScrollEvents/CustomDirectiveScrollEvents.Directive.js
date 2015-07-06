angular.module('custom.directive').directive('directiveAsElement', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function () {
            alert('I am called with restriction "E" ');
        }
    }
});

angular.module('custom.directive').directive('directiveAsClass', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'C',
        link: function () {
            alert('I am called with restriction "C" ');
        }
    }
});

angular.module('custom.directive').directive('directiveAsAttribute', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'A',
        link: function () {
            alert('I am called with restriction "A" ');
        }
    }
});

angular.module('custom.directive').directive('customDirectiveScrollEvents', function () {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function (scope, element, attrs) {
            alert('I am called with restriction "CustomDirectiveScrollEvents" ');
            element.bind("DOMMouseScroll mousewheel onmousewheel", function (event) {
                //console.log('I am Mousewheel!', event);
                // cross-browser wheel delta
                var event = window.event || event; // old IE support
                var delta = Math.max(-1, Math.min(1, (event.wheelDelta || -event.detail)));
                if (delta > 0) {
                    console.log("WheelEvent Up");
                    // for IE
                    event.returnValue = false;
                    // for Chrome and Firefox
                    if (event.preventDefault) {
                        event.preventDefault();
                    }
                }
                else  {
                    console.log("WheelEvent Down");
                    // for IE
                    event.returnValue = false;
                    // for Chrome and Firefox
                    if (event.preventDefault) {
                        event.preventDefault();
                    }
                }
            });
        }
    }
});

