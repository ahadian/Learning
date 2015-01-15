/**
 * Created by najim.ahmed on 1/15/2015.
 */

var thisApp = angular.module('myApp',[]);
thisApp.controller('SwitchCtrl',['$scope',function($scope){
    $scope.name = "Najim";
$scope.Persons = [
    {
    Name: "Najim",
    Age: 26,
    Sex: "Male"
    },
    {
        Name: "Foysal",
        Age: 30,
        Sex: "Male"
    },
    {
        Name: "Tanzila",
        Age: 28,
        Sex: "Female"
    }
];
}]);
/*
 <div ng-switch on="Persons.Sex">
 <table>
 <tr ng-repeat="p in Persons">
 <td>{{p.Name}}</td>
 <td>{{p.Age}}</td>
 <div><td ng-switch-when="Male">{{p.Sex}}</td></div>
 </tr>
 </table>
 </div>
* */