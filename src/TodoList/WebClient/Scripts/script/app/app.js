var thisApp = angular.module('myApp', ['ngRoute', 'ngResource']);


thisApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: 'partials/BriefView.html', controller: 'BriefViewCtrl' });
    $routeProvider.when('/DetailView', { templateUrl: 'partials/DetailView.html', controller: 'DetailsViewCtrl' });
    $routeProvider.when('/Add', { templateUrl: 'partials/AddTask.html', controller: 'AddTaskCtrl' });
    $routeProvider.when('/Details/:id', { templateUrl: 'partials/TaskInDetails.html', controller: 'TaskInDetailsCtrl' });
    $routeProvider.when('/Edit/:id', { templateUrl: 'partials/EditTask.html', controller: 'EditTaskCtrl' });
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
      $scope.Delete = function(idx) {
          var r = confirm('Are you sure you want to delete this item?');
          if (r == true) {
              myFactory.delete($scope.myTaskList[idx],
              function (response) {
                  if (response.IsSuccess == true) {
                      $scope.myTaskList.splice(idx, 1);
                  } else {
                      alert(response.Message);
                  }
              });
          }
          
      }
  }])

.controller('DetailsViewCtrl', ['$scope', '$routeParams', 'myFactory', function ($scope, $routeParams, myFactory) {
    $scope.Delete = function (idx) {
        var r = confirm('Are you sure you want to delete this item?');
        if (r == true) {
            myFactory.delete($scope.myTaskList[idx],
            function (response) {
                if (response.IsSuccess == true) {
                    $scope.myTaskList.splice(idx, 1);
                } else {
                    alert(response.Message);
                }
            });
        }

    }
}])

  .controller('TaskInDetailsCtrl', ['$scope', '$routeParams', function ($scope, $routeParams) {
      $scope.currentIndex = parseInt($routeParams.id);
      $scope.DetailViewData = ($scope.myTaskList[$scope.currentIndex - 1]);
  }])

.controller('AddTaskCtrl', ['$scope', '$routeParams','myFactory', function ($scope, $routeParams,myFactory) {
    $scope.Add = function() {
        myFactory.save($scope.newTask,
                  function (response) {
                      if (response.IsSuccess == true) {
                          $scope.myTaskList.push($scope.newTask);
                      } else {
                          alert(response.Message);
                      }
                  });
    }
}])

  .controller('EditTaskCtrl', ['$scope', '$routeParams','myFactory', function ($scope, $routeParams,myFactory) {
      $scope.currentIndex = parseInt($routeParams.id);
      $scope.Task2Update = ($scope.myTaskList[$scope.currentIndex - 1]);

      for (i = $scope.Task2Update.Todo.length-1; i >= 0; i--) {
          if ($scope.Task2Update.Todo.charAt(i) != ' ') {
              $scope.updTodo = $scope.Task2Update.Todo.substr(0,i+1);
              break;
          }
      }
      $scope.updPriority = $scope.Task2Update.Priority;
      $scope.updTimeAndDate = (new Date($scope.Task2Update.TimeAndDate));


      $scope.Update = function () {
          console.log('HHS');
          $scope.Task2Update.Todo = $scope.updTodo;
          $scope.Task2Update.TimeAndDate = $scope.updTimeAndDate;
          $scope.Task2Update.Priority = $scope.updPriority;
          myFactory.save($scope.Task2Update,
              function (response) {
              if (response.IsSuccess == true) {
                  $scope.myTaskList = response.Data;
              } else {
                  alert(response.Message);
              }
          });

      }

    }])
    .controller('TopMostController', ['$scope', 'myFactory', function ($scope, myFactory) {
        myFactory.get(function (response) {
            if (response.IsSuccess == true) {
                $scope.myTaskList = response.Data;
            } else {
                alert(response.Message);
            }
        });
        $scope.Max_Char_Limit = 16;

    }
]);