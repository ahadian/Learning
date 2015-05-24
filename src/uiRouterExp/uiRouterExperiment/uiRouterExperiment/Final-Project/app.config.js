angular.module('finalProject').config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
        .state('app', {
            url: '/',
            views: {
                'header': {
                    templateUrl: 'Header/header.tpl.html'
                },
                'content': {
                    templateUrl: 'Content/content-list.tpl.html'
                },
                'footer': {
                    templateUrl: 'Footer/footer.tpl.html'
                }
            }
        })
    .state('app.book', {
        url: 'books',
        views: {
            'content@': {
                templateUrl: 'Content/book/book-list/book-list.tpl.html',
                controller: 'bookListCtrl'
            }
        }
    })
     .state('app.dashboard', {
         url: '/dashboard',
         views: {
             'content@': {
                 templateUrl: 'Content/dashboard/dashboard.tpl.html',
                 controller: 'dashboardCtrl'
             }
         }
     })
    .state('app.book.details', {
        url: '/:id',
        views: {
            'detail@app.book': {
                templateUrl: 'Content/book/book-details/book-details.tpl.html',
                controller: 'bookDetilCtrl'
            }
        }
    })
    ;
}]);