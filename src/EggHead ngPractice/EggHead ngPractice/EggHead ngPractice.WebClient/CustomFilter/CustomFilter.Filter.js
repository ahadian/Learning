angular.module('custom.filter').filter('incrementFilter',function() {
    return function (input, index, incrementvalue) {
        console.log(input, index, incrementvalue);
        return input[index - 1] + incrementvalue;
    }
});

angular.module('custom.filter').filter('GuruGiveMeLength', function () {
    return function (input) {
        console.log(input);
        return input.length;
    }
});
