var thisApp = angular.module('myApp', ['ngRoute', 'ngResource']);


thisApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'partials/BriefView.html', controller: 'BriefViewCtrl' });
    $routeProvider.when('/TaskInDetails', { templateUrl: 'partials/TaskInDetails.html', controller: 'TaskInDetailsCtrl' });
    $routeProvider.otherwise({ redirectTo: '/' });
}]);

thisApp.factory('myFactory', ['$resource',
    function ($resource) {
        var resource = $resource('http://localhost:26609/Api/Todolist', {}, { get: { method: 'GET', isArray: false } });
        return resource;
    }
]);


thisApp
  .controller('BriefViewCtrl', ['$scope', 'myFactory', function ($scope, myFactory) {
      $scope.name = 'Tiger';
      
      myFactory.get(function (response) {
          if (response.IsSuccess == true) {
              $scope.myTaskList = response.Data;
          } else {
              alert(response.Message);
          }
      });
      $scope.invoke = function (idx) {
          $scope.somevar = idx;
      }
  }])
  .controller('TaskInDetailsCtrl', ['$scope', function ($scope) {
      //console.log('Hello Me' + $rootScope.somevar);
     

  }]);