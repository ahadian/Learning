angular.module('IntDirRnd').controller('AppCtrl', function ($scope) {
    $scope.data =
    [
        {
            Id: 1,
            Name: 'Najim',
            Phone: 123
        },
        {
            Id: 2,
            Name: 'Foysal Vai',
            Phone: 456
        }
    ];
    $scope.firstName = "Jakob";
    //$scope.username = '<div style="color: red">I am a bad boy!</div>';
});
angular.module('IntDirRnd').directive('detailsView', function() {
    return {
        restrict: 'E',
        scope: {
            userId: '=usrid'
        },
        compile: function (elem, attr) {
            console.log(elem, attr);
            return  function linkFunction(scope, elem, attr) {
                console.log(scope, elem, scope.userId);
                //scope.abc = 1;
                elem.bind('mouseenter', function () {
                    return '<div style="corlor:red">I am there</div>';
                    //console.log('123');
                });
            }
        },
        template: "<div> <a href='http://localhost:2357/GetDetails({{userId}})'>Clcik</a></div>{{usrId}}"
    }
}).directive('mytransclude', function () {
    var directive = {};

    directive.restrict = 'E'; /* restrict this directive to elements */
    directive.transclude = true;
    directive.template = "<div class='myTransclude' ng-transclude>ASD</div>";

    return directive;
});;