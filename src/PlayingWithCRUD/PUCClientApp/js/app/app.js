var thisApp = angular.module('restDemo', ['ngResource']);

thisApp.controller('restController', ['$scope', 'restService', function ($scope, restService) {
    $scope.persons = [];
    $scope.Get_Array = function () {
        restService.Get_Array('http://localhost:31183/api/person').then(function (response) {
            $scope.persons = response;
            //console.log('this log');
            //console.log(response);
        });
    };
    $scope.Get_IntString_Object = function () {
        restService.Get_IntString_Object('http://localhost:31183/api/person/:intgr/:str').then(function (response) {
            $scope.human = response;
            //console.log('this log');
            //console.log($scope.human);
        });
    };
    
    $scope.Post_Object = function () {
        restService.Post_Object('http://localhost:31183/api/person').then(function (response) {
            $scope.message = response;
            //console.log('$scope.message: ');
            //console.log($scope.message);
        });
    };

    $scope.Put_Id_Object = function () {
        restService.Put_Id_Object('http://localhost:31183/api/person/:id').then(function (response) {
            $scope.message = response;
            //console.log('$scope.message: ');
            //console.log($scope.message);
        });
    };

    $scope.Delete_Id = function () {
        restService.Delete_Id('http://localhost:31183/api/person/:id').then(function (response) {
            $scope.message = response;
            //console.log('$scope.message: ');
            //console.log($scope.message);
        });
    };
    //Delete_Id


    
    $scope.name = 'Hello me';
}]);
