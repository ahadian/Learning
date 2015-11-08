angular.module('myApp', [])
  .controller('myController', ['$scope', function ($scope) {
      console.log($scope.myLargeText);
      $scope.$watch('myLargeText', function (newValue, oldValue) {
          //console.log(oldValue, newValue);
          console.log(ParteItJson(newValue));
          $scope.json = ParteItJson(newValue);
          $scope.jsonStrict = ParteItJsonStrict(newValue);
      });
  }]);

function ParteItJson(texts) {
    if (typeof texts === "undefined") return "{\n}";
    var props = Filter(texts.split("\n"));
    var json = "{\n";
    for (var i = 0; i < props.length; i++) {
        if (i > 0) json += ",\n";
        json += (props[i] + ":" + '"' + props[i] + '"');
    }
    json += "\n}";
    return json;
}

function ParteItJsonStrict(texts) {
    if (typeof texts === "undefined") return "{\n}";
    var props = Filter(texts.split("\n"));
    var json = "{\n";
    for (var i = 0; i < props.length; i++) {
        if (i > 0) json += ",\n";
        json += ('"' + props[i] + '"' + ":" + '"' + props[i] + '"');
    }
    json += "\n}";
    return json;
}

function Filter(props) {
    var filteredProps = [];
    for (var i = 0; i < props.length; i++) {
        var tokens = props[i].split(" ");
        console.log("tokens", tokens);
        for (var j = 0; j < tokens.length; j++) {
            var idx = tokens[j].indexOf("{");
            console.log(tokens[j],idx);
            if(idx==0)filteredProps.push(tokens[j - 1]);
            else if (idx > 0) {
                filteredProps.push(tokens[j].substr(0,idx));
            }
        }
    }
    return filteredProps;
}
