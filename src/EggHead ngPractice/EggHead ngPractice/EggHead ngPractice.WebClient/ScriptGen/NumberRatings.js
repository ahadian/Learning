//document.write('Hello');
var json = [
  {
      "FIELD1": "NumberRatingId",
      "FIELD2": "Rating",
      "FIELD3": "RatingResult"
  },
  {
      "FIELD1": "0B65441E-7A12-E511-80CC-00163E535454",
      "FIELD2": "5",
      "FIELD3": "5"
  },
  {
      "FIELD1": "70AD52EB-DC1F-E511-80CC-00163E535454",
      "FIELD2": "38",
      "FIELD3": "4.2"
  },
  {
      "FIELD1": "428A88C7-9A23-E511-80CC-00163E535454",
      "FIELD2": "1",
      "FIELD3": "0"
  }
];
function stringFormat(arg) {
    if (arg == 'NULL')return arg;
    return "'" + arg + "'";
}

function getKeySet(objects) {
    var keySet = '';
    for (var key in objects) {
        var value = objects[key];
        keySet += (',' + value);
    }
    //console.log(keySet.slice(1));
    return keySet.slice(1);
}

function getParams(jsonData, fnCofig) {
    var i = 0;
    var params = '';
    for (var key in jsonData) {
        var value = '';
        if (!(fnCofig.indexOf(i) > -1)) value = stringFormat(jsonData[key]);
        else value = jsonData[key];
        params += (',' + value);
        ++i;
    }
    //console.log(params.slice(1));
    return params.slice(1);
}

//console.log(json);
var keyset = getKeySet(json[0]);
for (var i = 1; i < json.length; i++) {
    var fnConfig = [1,2];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.NumberRatings (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}
