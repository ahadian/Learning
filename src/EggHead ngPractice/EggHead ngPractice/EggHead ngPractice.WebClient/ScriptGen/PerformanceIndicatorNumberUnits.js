//document.write('Hello');
var json = [
  {
      "FIELD1": "PerformanceIndicatorNumberUnitId",
      "FIELD2": "Excellent",
      "FIELD3": "VeryGood",
      "FIELD4": "Good",
      "FIELD5": "Fair",
      "FIELD6": "Poor"
  },
  {
      "FIELD1": "B3B580B0-0410-E511-80CC-00163E535454",
      "FIELD2": "5",
      "FIELD3": "8",
      "FIELD4": "10",
      "FIELD5": "12",
      "FIELD6": "15"
  },
  {
      "FIELD1": "B8373954-0810-E511-80CC-00163E535454",
      "FIELD2": "2",
      "FIELD3": "3",
      "FIELD4": "4",
      "FIELD5": "5",
      "FIELD6": "6"
  },
  {
      "FIELD1": "D7D1938E-481E-E511-80CC-00163E535454",
      "FIELD2": "50",
      "FIELD3": "45",
      "FIELD4": "40",
      "FIELD5": "35",
      "FIELD6": "30"
  },
  {
      "FIELD1": "8808C6AB-481E-E511-80CC-00163E535454",
      "FIELD2": "15",
      "FIELD3": "12",
      "FIELD4": "10",
      "FIELD5": "9",
      "FIELD6": "8"
  },
  {
      "FIELD1": "435880B3-481E-E511-80CC-00163E535454",
      "FIELD2": "15",
      "FIELD3": "12",
      "FIELD4": "11",
      "FIELD5": "10",
      "FIELD6": "9"
  },
  {
      "FIELD1": "445880B3-481E-E511-80CC-00163E535454",
      "FIELD2": "7",
      "FIELD3": "6",
      "FIELD4": "5",
      "FIELD5": "4",
      "FIELD6": "3"
  },
  {
      "FIELD1": "EDB036BF-481E-E511-80CC-00163E535454",
      "FIELD2": "24",
      "FIELD3": "17",
      "FIELD4": "15",
      "FIELD5": "14",
      "FIELD6": "12"
  },
  {
      "FIELD1": "68B73CC8-481E-E511-80CC-00163E535454",
      "FIELD2": "600",
      "FIELD3": "550",
      "FIELD4": "500",
      "FIELD5": "450",
      "FIELD6": "400"
  },
  {
      "FIELD1": "0C3CDDCF-481E-E511-80CC-00163E535454",
      "FIELD2": "95",
      "FIELD3": "85",
      "FIELD4": "75",
      "FIELD5": "70",
      "FIELD6": "60"
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
    var fnConfig = [1,2,3,4,5];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.PerformanceIndicatorNumberUnits (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}