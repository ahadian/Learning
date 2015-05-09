angular.module('isolateScope').controller('AppCtrl', function ($scope) {
    $scope.flavorFromCtrl = "Tea";
});
angular.module('isolateScope').directive('drink', function () {
    return {
        restrict: 'E',
        scope: {
            flavor: '='
        },
        template: '<div><input type="text" ng-model="flavor"></div>'
    }
}); 