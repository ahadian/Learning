angular.module('finalProject').controller('bookDetilCtrl', ['$scope', 'fakeService', '$stateParams', function ($scope, fakeService, $stateParams) {
    $scope.currentBook = fakeService.GetbyId($stateParams.id);
}]);