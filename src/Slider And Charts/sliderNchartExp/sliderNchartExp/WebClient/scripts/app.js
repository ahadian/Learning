var thisApp = angular.module('chartsExp', ['ngResource', 'nvd3ChartDirectives']);
thisApp.controller('chartCtrl', ['$scope', '$resource', function ($scope, $resource) {
    $scope.test = 'asd';
    var restGet = $resource("http://localhost:53402/api/JSON", {}, {
        get: {
            method: 'GET',
            isArray: true
        }
    });
    restGet.get(function (data) {
        console.log(data);
    });

    $scope.exampleData = [
     	{ key: "One", y: 5 },
         { key: "Two", y: 2 },
        { key: "Three", y: 9 },
         { key: "Four", y: 7 },
      { key: "Five", y: 4 },
       { key: "Six", y: 3 },
       { key: "Seven", y: 9 }
    ];
    $scope.xFunction = function () {
        return function (d) {
            return d.key;
        };
    }
    $scope.yFunction = function () {
        return function (d) {
            return d.y;
        };
    }
    //$scope.$watch("slider", function(e) {
    //    console.log(e);
        
    //    if (!$scope.$$phase) {
    //        //$digest or $apply
    //        $scope.$apply($scope.slider);
    //    } else {
           
    //    }
    //});

}]);