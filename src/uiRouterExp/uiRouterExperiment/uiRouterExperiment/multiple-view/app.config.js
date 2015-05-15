
angular.module('multipleViewExperiment').config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
        .state('home', {
            url: '/',
            views: {
                'header': {
                    templateUrl: "modules/header/header.tpl.html"
                },
                'content': {
                    templateUrl: "modules/content/content.tpl.html"
                },
                'footer': {
                    templateUrl: "modules/footer/footer.tpl.html"
                }
            }
        })
    .state('dashboard', {
        url: '/dashboard',
        views: {
            'header': {
                templateUrl: "modules/header/header.tpl.html"
            },
            'content': {
                templateUrl: "modules/header/dshboard/dashboard.tpl.html",
                controller: 'DashboardController'
            }
        }
    })
    .state('campaigns', {
        url: '/campaigns',
        views: {
            'content': {
                templateUrl: "modules/header/campaign/campaigns.tpl.html",
                controller: 'CampaignController'
            },
            'footer': {
                templateUrl: "modules/footer/footer.tpl.html"
            }
        }
    });
}]);