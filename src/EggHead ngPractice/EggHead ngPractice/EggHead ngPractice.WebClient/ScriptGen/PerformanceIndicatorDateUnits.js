//document.write('Hello');
var json = [
  {
      "FIELD1": "PerformanceIndicatorDateUnitId",
      "FIELD2": "Excellent",
      "FIELD3": "VeryGood",
      "FIELD4": "Good",
      "FIELD5": "Fair",
      "FIELD6": "Poor"
  },
  {
      "FIELD1": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-06-20 04:05:00.000",
      "FIELD4": "2015-06-25 04:05:00.000",
      "FIELD5": "2015-06-28 04:05:00.000",
      "FIELD6": "2015-06-30 04:05:00.000"
  },
  {
      "FIELD1": "E9D9A516-0910-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-05-10 04:05:00.000",
      "FIELD4": "2015-05-20 04:05:00.000",
      "FIELD5": "2015-05-28 04:05:00.000",
      "FIELD6": "2015-05-30 04:05:00.000"
  },
  {
      "FIELD1": "C3765E45-0910-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-06-10 04:05:00.000",
      "FIELD4": "2015-06-15 04:05:00.000",
      "FIELD5": "2015-06-20 04:05:00.000",
      "FIELD6": "2015-06-30 04:05:00.000"
  },
  {
      "FIELD1": "89A12CB3-421E-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-04-30 04:05:00.000",
      "FIELD4": "2015-05-15 04:05:00.000",
      "FIELD5": "2015-05-30 04:05:00.000",
      "FIELD6": "2015-06-30 04:05:00.000"
  },
  {
      "FIELD1": "F8E86CD8-421E-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-06-18 04:05:00.000",
      "FIELD4": "2015-06-20 04:05:00.000",
      "FIELD5": "2015-06-23 04:05:00.000",
      "FIELD6": "2015-06-30 04:05:00.000"
  },
  {
      "FIELD1": "9B07E518-481E-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-06-08 04:05:00.000",
      "FIELD4": "2015-06-10 04:05:00.000",
      "FIELD5": "2015-06-12 04:05:00.000",
      "FIELD6": "2015-06-15 04:05:00.000"
  },
  {
      "FIELD1": "286D202C-481E-E511-80CC-00163E535454",
      "FIELD2": "2015-07-07 00:00:00.000",
      "FIELD3": "2015-06-03 04:05:00.000",
      "FIELD4": "2015-06-04 04:05:00.000",
      "FIELD5": "2015-06-05 04:05:00.000",
      "FIELD6": "2015-06-06 04:05:00.000"
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
    var fnConfig = [];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.PerformanceIndicatorDateUnits (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}