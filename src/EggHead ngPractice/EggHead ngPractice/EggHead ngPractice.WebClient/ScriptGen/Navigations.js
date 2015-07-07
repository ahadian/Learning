//document.write('Hello');
var json = [
  {
      "FIELD1": "Id",
      "FIELD2": "ParentId",
      "FIELD3": "Name",
      "FIELD4": "Alias",
      "FIELD5": "IsPublished",
      "FIELD6": "RouteName",
      "FIELD7": "RouteUrl",
      "FIELD8": "IsAbstract",
      "FIELD9": "Views",
      "FIELD10": "Resolve",
      "FIELD11": "TypeId",
      "FIELD12": "Modules"
  },
  {
      "FIELD1": "2AF3D8B1-D522-E511-80CC-00163E535454",
      "FIELD2": "NULL",
      "FIELD3": "FPO",
      "FIELD4": "fpo",
      "FIELD5": "1",
      "FIELD6": "root.fpo",
      "FIELD7": "^/fpo",
      "FIELD8": "0",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "1",
      "FIELD12": "[{\"Name\":\"fpo-dashboard\",\"CustomTemplate\":\"\",\"ViewContainer\":\"body@root\",\"Query\":\"\",\"moduleIndex\":1,\"viewContainerIndex\":1,\"customTemplateIndex\":-1,\"hasCustomTemplate\":false}]"
  },
  {
      "FIELD1": "0A23D3C2-D522-E511-80CC-00163E535454",
      "FIELD2": "NULL",
      "FIELD3": "Login",
      "FIELD4": "login",
      "FIELD5": "1",
      "FIELD6": "root.login",
      "FIELD7": "^/login",
      "FIELD8": "0",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "1",
      "FIELD12": "[{\"Name\":\"login\",\"CustomTemplate\":\"\",\"ViewContainer\":\"body@root\",\"Query\":\"\",\"moduleIndex\":0,\"viewContainerIndex\":1,\"customTemplateIndex\":-1,\"hasCustomTemplate\":false}]"
  },
  {
      "FIELD1": "35823EE0-D522-E511-80CC-00163E535454",
      "FIELD2": "NULL",
      "FIELD3": "Supervisor",
      "FIELD4": "supervisor",
      "FIELD5": "1",
      "FIELD6": "root.supervisor",
      "FIELD7": "^/supervisor",
      "FIELD8": "0",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "1",
      "FIELD12": "[{\"Name\":\"supervisor-dashboard\",\"CustomTemplate\":\"\",\"ViewContainer\":\"body@root\",\"Query\":\"\",\"moduleIndex\":2,\"viewContainerIndex\":1,\"customTemplateIndex\":-1,\"hasCustomTemplate\":false}]"
  },
  {
      "FIELD1": "E81710AF-D622-E511-80CC-00163E535454",
      "FIELD2": "NULL",
      "FIELD3": "Pi Entry",
      "FIELD4": "pi-entry",
      "FIELD5": "1",
      "FIELD6": "root.pi-entry",
      "FIELD7": "^/pi-entry",
      "FIELD8": "0",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "1",
      "FIELD12": "[{\"Name\":\"performance-indicator-entry\",\"CustomTemplate\":\"\",\"ViewContainer\":\"body@root\",\"Query\":\"\",\"moduleIndex\":3,\"viewContainerIndex\":1,\"customTemplateIndex\":-1,\"hasCustomTemplate\":false}]"
  },
  {
      "FIELD1": "8A98B2BC-D622-E511-80CC-00163E535454",
      "FIELD2": "NULL",
      "FIELD3": "Pi Approval",
      "FIELD4": "pi-approval",
      "FIELD5": "1",
      "FIELD6": "root.pi-approval",
      "FIELD7": "^/pi-approval",
      "FIELD8": "0",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "1",
      "FIELD12": "[{\"Name\":\"performance-indicator-approval\",\"CustomTemplate\":\"\",\"ViewContainer\":\"body@root\",\"Query\":\"\",\"moduleIndex\":4,\"viewContainerIndex\":1,\"customTemplateIndex\":-1,\"hasCustomTemplate\":false}]"
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
    var fnConfig = [4,7,10];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.Navigations (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}