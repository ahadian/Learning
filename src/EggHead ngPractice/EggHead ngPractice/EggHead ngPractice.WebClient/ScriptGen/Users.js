//document.write('Hello');
var json = [
  {
      "FIELD1": "Id",
      "FIELD2": "UserName",
      "FIELD3": "UserType",
      "FIELD4": "FullName",
      "FIELD5": "Email",
      "FIELD6": "PhoneNumber",
      "FIELD7": "Organization",
      "FIELD8": "Department",
      "FIELD9": "Designation",
      "FIELD10": "Password"
  },
  {
      "FIELD1": "E3F64F2E-2E13-E511-80CC-00163E535454",
      "FIELD2": "supervisor",
      "FIELD3": "Admin",
      "FIELD4": "Supervisor",
      "FIELD5": "mahmuda.zaman@selise.ch",
      "FIELD6": "0123",
      "FIELD7": "NULL",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "A6579288-2E13-E511-80CC-00163E535454",
      "FIELD2": "fpo",
      "FIELD3": "User",
      "FIELD4": "FPO",
      "FIELD5": "anisul.islam@selise.ch",
      "FIELD6": "0123",
      "FIELD7": "NULL",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "D2AB8679-5213-E511-80CC-00163E535454",
      "FIELD2": "abdul",
      "FIELD3": "User",
      "FIELD4": "Mr. Md. Abdul Khalaque",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "1589",
      "FIELD7": "Information Management",
      "FIELD8": "Information Management-2",
      "FIELD9": "Assistant Secretary ",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "4EE20350-5313-E511-80CC-00163E535454",
      "FIELD2": "tofayel",
      "FIELD3": "User",
      "FIELD4": "Mr. Tofayel Ahmed",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "1234",
      "FIELD7": "BBS",
      "FIELD8": "Education",
      "FIELD9": "Deputy Director",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "25F923A7-5313-E511-80CC-00163E535454",
      "FIELD2": "sahabuddin",
      "FIELD3": "User",
      "FIELD4": "Mr. Md. Sahabuddin Sarkar",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "1234",
      "FIELD7": "BBS",
      "FIELD8": "Admin Department",
      "FIELD9": "Deputy Director",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "57B388F3-5313-E511-80CC-00163E535454",
      "FIELD2": "rafiqul",
      "FIELD3": "User",
      "FIELD4": "Mr. Muhammad. Rafiqul Islam",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "1523",
      "FIELD7": "BBS",
      "FIELD8": "Information Management-1",
      "FIELD9": "Deputy Director",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "E7BACF39-5413-E511-80CC-00163E535454",
      "FIELD2": "mahbubur",
      "FIELD3": "User",
      "FIELD4": "Mr. Mahbubur Rahman",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "1234",
      "FIELD7": "BBS",
      "FIELD8": "Information Management-3",
      "FIELD9": "Deputy Director",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD2": "topu",
      "FIELD3": "Admin",
      "FIELD4": "Shah Ali Newaj Topu",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "0111",
      "FIELD7": "SELISE",
      "FIELD8": "Admin Group",
      "FIELD9": "CTO",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "1718A74C-EB13-E511-80CC-00163E535454",
      "FIELD2": "rashdi",
      "FIELD3": "Admin",
      "FIELD4": "Chowdhury Rashdi",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "0111",
      "FIELD7": "SELISE",
      "FIELD8": "Admin Group",
      "FIELD9": "PDM",
      "FIELD10": "NULL"
  },
  {
      "FIELD1": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD2": "pradip",
      "FIELD3": "User",
      "FIELD4": "Mr. Pradip Kumar Saha",
      "FIELD5": "jonayet@selise.ch",
      "FIELD6": "0111",
      "FIELD7": "BBS",
      "FIELD8": "Admin-3",
      "FIELD9": "Deputy Secretary ",
      "FIELD10": "NULL"
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
    var command = 'insert into dbo.Users (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}