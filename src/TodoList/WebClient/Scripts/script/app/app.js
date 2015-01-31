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
      $scope.TaskIsDone = function (myTask, idx) {
          myTask.Status = 1;
          myFactory.save(myTask,
              function (response) {
                  if (response.IsSuccess == true) {
                      $scope.myTaskList[idx] = myTask;
                      //console.log($scope.myTaskList[idx]);
                  } else {
                      alert(response.Message);
                  }
              });
      }
      //disabled
      $scope.DateIsOk = function (tnd) {
          console.log('HiHi re....');
          var timestamp = Date.parse(tnd);
          if (isNaN(timestamp) == false) {
              //console.log('Here I am');
              if (new Date() >= new Date(tnd)) {
                  //console.log('Returning false');
                  $scope.classdsbl = 'disabled';
                  console.log('False Ase na kan????' + tnd + $scope.classdsbl);
                  console.log( $scope.classdsbl);
                  return 'disabled';
              } else {
                  $scope.classdsbl = '';
                  console.log('True Ase na kan????' + tnd + $scope.classdsbl);
                  console.log( $scope.classdsbl);
                  return '';
              }
              
          } else {
              console.log('False Ase na kan????' + tnd + $scope.classdsbl);
              console.log( $scope.classdsbl);
              $scope.classdsbl = 'disabled';
              return 'disabled';
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
    $scope.TaskIsDone = function (myTask, idx) {
        myTask.Status = 1;
        myFactory.save(myTask,
            function (response) {
                if (response.IsSuccess == true) {
                    $scope.myTaskList[idx] = myTask;
                    //console.log($scope.myTaskList[idx]);
                } else {
                    alert(response.Message);
                }
            });
    }
    $scope.SetSortFactor = function(arg) {
        if ($scope.sortfactor.search(arg) == -1) {
            $scope.sortfactor = arg;
        } else {
            if ($scope.sortfactor[0] == '-') $scope.sortfactor = $scope.sortfactor.substr(1);
            else $scope.sortfactor = '-' + $scope.sortfactor;
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
    $scope.DateOk = function () {
        var timestamp = Date.parse($scope.newTask.TimeAndDate);
        if (isNaN(timestamp) == false) {
            //console.log('Here I am');
            if (new Date() >= new Date($scope.newTask.TimeAndDate)) {
                //console.log('Returning false');
                return false;
            }
            return true;

        }
        //console.log(new Date());
        //console.log(new Date($scope.newTask.TimeAndDate));
        //console.log(new Date() >= new Date($scope.newTask.TimeAndDate));
        return false;
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
                  $scope.myTaskList[$scope.currentIndex - 1] = $scope.Task2Update;
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
                $scope.Total_Page = Math.ceil($scope.myTaskList.length / $scope.Task_Per_Page);
                console.log($scope.Total_Page);
            } else {
                alert(response.Message);
            }
        });
        $scope.Max_Char_Limit = 16;
        $scope.Task_Per_Page = 5;
        $scope.Current_Page = 1;
        $scope.Low = 1;
        $scope.High = 5;

        $scope.NextPage = function() {
            $scope.Low += 5;
            $scope.High += 5;
            console.log('I came');
            $scope.Current_Page++;
        }
        $scope.PrevPage = function () {
            $scope.Low -= 5;
            $scope.High -= 5;
            $scope.Current_Page--;
        }
        console.log(new Date());
    }
]);