angular.module('IsolateScopeAllTogether').directive('dynamicDiv', function ($compile) {
    return {
        restrict: 'E',
        scope: {
            width: '=width',
            height:'='
        },
        template: '<div> {{width}} => {{height}}' +
            '<dir-inside-dir passW="{{width}}" passH="{{height}}" > </dir-inside-dir>'+
            '</div>',
        link:function(scope,elem,attr) {
            //console.log(elem.contents());
            $compile(elem.contents())(scope);
        }
    }
});

angular.module('IsolateScopeAllTogether').directive('dirInsideDir', function ($compile) {
    return {
        restrict: 'E',
        scope: {
            x: '=passW',
            y: '=passH'
        },
        template: '<div> {{x+2}} + {{y+2}}</div>', 
        link: function (scope, elem, attr) {
            $compile(elem.contents())(scope);
            //console.log(scope, elem, attr);
        }
    }
});
