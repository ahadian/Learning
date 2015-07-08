angular.module('isolateScope').controller('AppCtrl', function ($scope) {
    $scope.callHome = function(phonenumber,extention) {
        console.log(phonenumber + ":" + extention);
    };
});
angular.module('isolateScope').directive('phone', function() {
    return {
        restrict: 'E',
        scope: {
            dial: '&',
            phonenumber: '=',
            extension: '@'
        },
        template: '<div ng-click="dial({phonenumber:phonenumber,extension:extension})">Call Home</div>'
    }
});