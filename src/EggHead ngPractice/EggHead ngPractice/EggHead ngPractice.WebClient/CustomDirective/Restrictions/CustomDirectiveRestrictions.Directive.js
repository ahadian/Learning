angular.module('custom.directive').directive('directiveAsElement',function() {
    // best practice is always return object from directive function instead of function
    return {
        restrict: 'E',
        link: function() {
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

