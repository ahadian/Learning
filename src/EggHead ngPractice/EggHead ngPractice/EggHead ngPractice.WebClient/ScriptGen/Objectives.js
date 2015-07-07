//document.write('Hello');
var json = [
  {
      "FIELD1": "ObjectiveId",
      "FIELD2": "Description",
      "FIELD3": "Weight"
  },
  {
      "FIELD1": "2F02488A-0410-E511-80CC-00163E535454",
      "FIELD2": "Formulating act/rules/policies related to statistics and informatics need of the country",
      "FIELD3": "10"
  },
  {
      "FIELD1": "F7289B03-0610-E511-80CC-00163E535454",
      "FIELD2": "Providing data/statistics on identified key parameters to Planners and Policy makers in Government and to others",
      "FIELD3": "45"
  },
  {
      "FIELD1": "E2083506-431E-E511-80CC-00163E535454",
      "FIELD2": "Improving National Statistical System (NSS) and to make it consistent with international standards by implementing NSDS.",
      "FIELD3": "30"
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
    var fnConfig = [2];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.Objectives (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}