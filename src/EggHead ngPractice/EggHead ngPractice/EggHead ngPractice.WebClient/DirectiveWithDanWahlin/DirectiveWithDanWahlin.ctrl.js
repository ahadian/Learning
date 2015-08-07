//Isolate Scope and Function Parameters
// Very tricky example of object literal , also nice one and complex one. cleared so many things in ui route :p 



angular.module('DirectiveWithDanWahlin').controller('AppCtrl', function ($scope) {
    var counter = 0;
    $scope.customer = {
        name: 'David',
        street: '1234 Anywhere St.'
    };

    $scope.customers = [];

    $scope.addCustomer = function (name) {
        console.log('I got my name Sir!', name);
        //console.log('A call from directive!', name);
        //counter++;
        //$scope.customers.push({
        //    name: (name) ? name : 'New Customer' + counter,
        //    street: counter + ' Cedar Point St.'
        //});
        //console.log($scope.customers);
    };

    $scope.changeData = function () {
        counter++;
        $scope.customer = {
            name: 'James',
            street: counter + ' Cedar Point St.'
        };
    };
});

//Option 1: Using an Object Literal
angular.module('DirectiveWithDanWahlin').directive('isolatedScopeWithController', function ($parse) {
    return {
        restrict: 'EA',
        scope: {
            datasource: '=',
            add: '&'
        },
        controller: function ($scope) {
            $scope.customers = [];
            $scope.addCustomer = function () {
                console.log('I have been requested!');
                //Call external scope's function
                var name = 'New Customer Added by Directive1';
                $scope.add({ name: name });


                //Add new customer to directive scope
                $scope.customers.push({
                    name: name
                });
            };
        },
        link: function (scope, elem, attrs) {
            console.log(attrs);
        },
        template:
    '<button ng-click="addCustomer()">Change Data</button><ul>' +
    '<li ng-repeat="cust in customers">{{ cust.name }}</li></ul>'
    };
});


//Option 2: Storing a Function Reference and Invoking It
angular.module('DirectiveWithDanWahlin').directive('isolatedScopeWithControllerAlternate', function ( $parse) {
    return {
        restrict: 'EA',
        scope: {
            datasource: '=',
            add: '&'
        },
        controller: function ($scope) {
            $scope.customers = [];
            $scope.addCustomer = function () {
                console.log('I have been requested!');
                //Call external scope's function
                var name = 'New Customer Added by Directive2';
                $scope.add()(name);


                //Add new customer to directive scope
                $scope.customers.push({
                    name: name
                });
            };
        },
        link:function(scope, elem, attrs) {
            console.log(attrs.add);
            var x = $parse(attrs.add);
            //holy shit!!!
            x('xyz');
        },
        template:
    '<button ng-click="addCustomer()">Change Data</button><ul>' +
    '<li ng-repeat="cust in customers">{{ cust.name }}</li></ul>'
    };
});
/*
Comments : 
The second technique looses 'this' on the caller site. I'm using the combination of both techniques: the user passes the method as in (2), 
in the directive I extract the string from attrs, combine it with the signature I want, $parse it as angular itself 
and invoke using technique (1). Now all semantics are preserved!
-Konstantin Triger 
*/