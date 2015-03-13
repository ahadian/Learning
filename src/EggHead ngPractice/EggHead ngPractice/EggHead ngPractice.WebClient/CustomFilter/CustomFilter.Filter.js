angular.module('custom.filter').filter('incrementFilter',function() {
   

    return function (input, index, incrementvalue) {
        console.log(input, index, incrementvalue);
        return input[index - 1] + incrementvalue;
    }
});
