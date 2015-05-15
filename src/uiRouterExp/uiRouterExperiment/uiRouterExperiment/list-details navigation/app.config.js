angular.module('uiRoutingExample').config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/shows');

        //$urlRouterProvider.rule(function ($injector, $location) {
        //    var path = $location.url();
        //    console.log(path);
        //    //// check to see if the path already has a slash where it should be
        //    //if (path[path.length - 1] === '/' || path.indexOf('/?') > -1) {
        //    //    return;
        //    //}

        //    //if (path.indexOf('?') > -1) {
        //    //    return path.replace('?', '/?');
        //    //}

        //    return path;
        //});


        $stateProvider
            .state('shows', {
                url: '/shows',
                //template:'<div><h3>Hello There</h3></div>',
                templateUrl: 'modules/list-view/shows-list.tpl.html',
                controller: 'ShowsController'
            })
            .state('shows.details', {
                url: '/details/:id',
                templateUrl: 'modules/details-view/shows-details.tpl.html',
                controller: 'ShowsDetailsController'
            });
    }
]);