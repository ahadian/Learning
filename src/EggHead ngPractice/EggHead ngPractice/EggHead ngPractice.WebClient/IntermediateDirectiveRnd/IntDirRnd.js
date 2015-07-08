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
});
angular.module('IntDirRnd').directive('detailsView', function() {
    return {
        restrict: 'E',
        scope: {
            userId: '=usrid'
        },
        link: function(scope, elem, attr) {
            console.log(elem, scope.userId);
        },
        template: "<div> <a href='http://localhost:2357/GetDetails({{userId}})'>Clcik</a></div>{{usrId}}"
    }
});