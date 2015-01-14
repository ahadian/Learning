/**
 * Created by najim.ahmed on 1/14/2015.
 */
var thisApp = angular.module('myApp', []);
thisApp.controller('SortCtrl', ['$scope', function ($scope) {
    $scope. ColumnName = ["Name","Age"];
    $scope. myList = [
        { Name: "B",Age: 10 },
        { Name: "A",Age:20 }
    ];
    /*$scope. myList = [
        { name: "Peter",   age: 20 },
        { name: "Pablo",   age: 55 },
        { name: "Linda",   age: 20 },
        { name: "Marta",   age: 37 },
        { name: "Othello", age: 20 },
        { name: "Markus",  age: 32 }
    ];
    */
    $scope.Fun = function (idx) {
        $scope.sortCriteria = $scope.ColumnName[idx];
        console.log($scope.sortCriteria);
    }
    }]);