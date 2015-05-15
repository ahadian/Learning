angular.module('uiRoutingExample').controller('ShowsDetailsController', ['$scope', '$stateParams', 'ShowsService', function ($scope, $stateParams, ShowsService) {
    $scope.selectedShow = ShowsService.find($stateParams.id);
    //console.log('Ola');
}]);