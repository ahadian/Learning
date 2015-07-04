﻿var thisApp = angular.module('chartsExp', ['ngResource', 'nvd3ChartDirectives']);
thisApp.controller('chartCtrl', ['$scope', '$resource', '$q', function ($scope, $resource, $q) {
    $scope.test = 'asd';
    var restGet = $resource("http://localhost:53402/api/JSON?id=1", {}, {
        get: {
            method: 'GET',
            isArray: true
        }
    });
    function saveMyAss() {
        // There will always be a promise so always declare it.
        var deferred = $q.defer();
        restGet.get(function(data) {
            deferred.resolve(data);
        }),
        function(data) {
            deferred.reject(data);
        };
        return deferred.promise;

    }

    saveMyAss().then(function(myAss) {
        console.log('myAss', myAss);
        $scope.reduceXTicksData = [
        {
            "key": "Series 1",
            "values": myAss
    }
        ];
        console.log('date exp', $scope.reduceXTicksData.values);
    });


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
    $scope.xAxisTickFormatFunction = function () {
        return function (d) {
            return d3.time.format('%b %Y')(new Date(d));
            return d3.time.format('%m-%y')(new Date(d));
            return d3.time.format('%b')(new Date(d));
        }
    }
    //$scope.reduceXTicksData = [
    //       {
    //           "key": "Series 1",
    //           "values": $scope.values
    //       }
    //];

    
    //console.log('date exp', new Date(1025409600000).getDate(), new Date(1025409600000).getMonth(), new Date(1025409600000).getYear());
    var xyz = new Date(2015, 5, 24, 0, 0, 0);
    console.log('date exp', xyz, xyz.getDate(), xyz.getMonth(), xyz.getYear(), ((xyz.getTime() * 10000) + 621355968000000000));
    console.log('date exp', new Date(1025409600000));
    console.log('date exp', new Date(1041310800000 + 1000000000));
    //console.log('date exp', $scope.reduceXTicksData.values);
    //$scope.exampleData = [
    //             {
    //                 "key": "Series 1",
    //                 "values": [[1025409600000, 0], [1028088000000, -6.3382185140371], [1030766400000, -5.9507873460847], [1033358400000, -11.569146943813], [1036040400000, -5.4767332317425], [1038632400000, 0.50794682203014], [1041310800000, -5.5310285460542], [1043989200000, -5.7838296963382], [1046408400000, -7.3249341615649], [1049086800000, -6.7078630712489], [1051675200000, 0.44227126150934], [1054353600000, 7.2481659343222], [1056945600000, 9.2512381306992]]
    //             },
    //              {
    //                  "key": "Series 2",
    //                  "values": [[1025409600000, 0], [1028088000000, 0], [1030766400000, 0], [1033358400000, 0], [1036040400000, 0], [1038632400000, 0], [1041310800000, 0], [1043989200000, 0], [1046408400000, 0], [1049086800000, 0], [1051675200000, 0], [1054353600000, 0], [1056945600000, 0], [1059624000000, 0], [1062302400000, 0], [1064894400000, 0], [1067576400000, 0], [1070168400000, 0], [1072846800000, 0], [1075525200000, -0.049184266875945]]
    //              },
    //             {
    //                 "key": "Series 3",
    //                 "values": [[1025409600000, 0], [1028088000000, -6.3382185140371], [1030766400000, -5.9507873460847], [1033358400000, -11.569146943813], [1036040400000, -5.4767332317425], [1038632400000, 0.50794682203014], [1041310800000, -5.5310285460542], [1043989200000, -5.7838296963382], [1046408400000, -7.3249341615649], [1049086800000, -6.7078630712489], [1051675200000, 0.44227126150934], [1054353600000, 7.2481659343222], [1056945600000, 9.2512381306992]]
    //             },
    //            {
    //                "key": "Series 4",
    //                "values": [[1025409600000, -7.0674410638835], [1028088000000, -14.663359292964], [1030766400000, -14.104393060540], [1033358400000, -23.114477037218], [1036040400000, -16.774256687841], [1038632400000, -11.902028464000], [1041310800000, -16.883038668422], [1043989200000, -19.104223676831], [1046408400000, -20.420523282736], [1049086800000, -19.660555051587], [1051675200000, -13.106911231646], [1054353600000, -8.2448460302143], [1056945600000, -7.0313058730976]]
    //            }
    //];
}]);