angular.module('isolateScope').controller('AppCtrl', function ($scope) {
    $scope.flavor = 'asd';
});
angular.module('isolateScope').directive('drink', function () {
    return {
        restrict: 'E',
        scope: {
            flavor: '@'
        },
        template: '<div>{{flavor}}</div>'
        //link: function(scope,elem,attrs) {
        //    scope.flavor = attrs.flavor;
        //}
    }
});  