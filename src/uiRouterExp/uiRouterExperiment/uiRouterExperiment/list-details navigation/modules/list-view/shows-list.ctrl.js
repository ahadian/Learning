angular.module('uiRoutingExample').controller('ShowsController', ['$scope', 'ShowsService', function ($scope, ShowsService) {
    $scope.shows = ShowsService.list();
    //console.log('I never came Here!', $scope.shows);
}]);