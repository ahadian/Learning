angular.module('finalProject').controller('bookListCtrl', ['$scope', 'fakeService', function ($scope, fakeService) {
    $scope.Books = fakeService.GetBooks();
    console.log('Books', $scope.Books);
}]);