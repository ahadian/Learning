//document.write('Hello');
var json = [
  {
      "FIELD1": "PerformanceIndicatorId",
      "FIELD2": "Description",
      "FIELD3": "Weight",
      "FIELD4": "ActivityId",
      "FIELD5": "FocalPointOfficerId",
      "FIELD6": "SupervisorId",
      "FIELD7": "PerformanceIndicatorDateUnitId",
      "FIELD8": "PerformanceIndicatorNumberUnitId",
      "FIELD9": "DateRatingId",
      "FIELD10": "NumberRatingId",
      "FIELD11": "Status",
      "FIELD12": "IsApproved",
      "FIELD13": "IsCompleted",
      "FIELD14": "RatingTypeId"
  },
  {
      "FIELD1": "B4B580B0-0410-E511-80CC-00163E535454",
      "FIELD2": "Draft of revised Actsubmitted to Legislative Division",
      "FIELD3": "3",
      "FIELD4": "AAA0E890-0410-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "A67930E4-4F1E-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "in progress...",
      "FIELD12": "1",
      "FIELD13": "1",
      "FIELD14": "0"
  },
  {
      "FIELD1": "9BB9B9DA-0410-E511-80CC-00163E535454",
      "FIELD2": "Draft of Allocation of Business submitted to Cabinet Division",
      "FIELD3": "4",
      "FIELD4": "53F1852E-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "9FDAFC60-501E-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "draft",
      "FIELD12": "1",
      "FIELD13": "1",
      "FIELD14": "0"
  },
  {
      "FIELD1": "1FC7B2F5-0410-E511-80CC-00163E535454",
      "FIELD2": "Draft of the Informatics policy submitted to  Legislative Division",
      "FIELD3": "3",
      "FIELD4": "829D6364-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "1B5AB8E5-501E-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "done",
      "FIELD12": "0",
      "FIELD13": "0",
      "FIELD14": "0"
  },
  {
      "FIELD1": "A92BB468-0910-E511-80CC-00163E535454",
      "FIELD2": "Annual GDP Estimates",
      "FIELD3": "3",
      "FIELD4": "87705A79-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "ED277E00-DA1F-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "asd",
      "FIELD12": "NULL",
      "FIELD13": "1",
      "FIELD14": "0"
  },
  {
      "FIELD1": "29E37470-0910-E511-80CC-00163E535454",
      "FIELD2": "First Revised estimates of National Income",
      "FIELD3": "2",
      "FIELD4": "87705A79-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "E9D9A516-0910-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "34F9B7C1-521E-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "asd",
      "FIELD12": "NULL",
      "FIELD13": "1",
      "FIELD14": "0"
  },
  {
      "FIELD1": "F660AC76-0910-E511-80CC-00163E535454",
      "FIELD2": "Preliminary estimate  of current year of National accounts and final estimates  of previous year",
      "FIELD3": "2",
      "FIELD4": "87705A79-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "C3765E45-0910-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "3A52851E-DC1F-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "my status",
      "FIELD12": "NULL",
      "FIELD13": "1",
      "FIELD14": "0"
  },
  {
      "FIELD1": "8081C67E-0910-E511-80CC-00163E535454",
      "FIELD2": "CPI publish",
      "FIELD3": "2",
      "FIELD4": "BA0C4685-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "9B07E518-481E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "18966218-FB22-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "0",
      "FIELD14": "0"
  },
  {
      "FIELD1": "A929D68B-0910-E511-80CC-00163E535454",
      "FIELD2": "Timely release of QIIP",
      "FIELD3": "2",
      "FIELD4": "4470DA8E-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "286D202C-481E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "910EC705-441E-E511-80CC-00163E535454",
      "FIELD2": "Statistical Year Book of Bangladesh 2014",
      "FIELD3": "3",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "DF6BB642-441E-E511-80CC-00163E535454",
      "FIELD2": "Statistical pocket book 2014",
      "FIELD3": "3",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "89A12CB3-421E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "C5290931-501E-E511-80CC-00163E535454",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "0",
      "FIELD14": "0"
  },
  {
      "FIELD1": "7969D169-441E-E511-80CC-00163E535454",
      "FIELD2": "Agriculture yearbook 2013",
      "FIELD3": "3",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "89A12CB3-421E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "0319B395-441E-E511-80CC-00163E535454",
      "FIELD2": "Publications of Economic census 2013",
      "FIELD3": "4",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "89A12CB3-421E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "70A85CCD-441E-E511-80CC-00163E535454",
      "FIELD2": "Data collection from the field",
      "FIELD3": "4",
      "FIELD4": "BA0C4685-0610-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "F8E86CD8-421E-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "AC72E91B-451E-E511-80CC-00163E535454",
      "FIELD2": "On-time completion of the programme",
      "FIELD3": "6",
      "FIELD4": "90A30A64-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "99FBA4DA-0810-E511-80CC-00163E535454",
      "FIELD8": "NULL",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "0"
  },
  {
      "FIELD1": "4323C20A-491E-E511-80CC-00163E535454",
      "FIELD2": "Publications of Population and housing census 2011",
      "FIELD3": "6",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "D7D1938E-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "70AD52EB-DC1F-E511-80CC-00163E535454",
      "FIELD11": "NULL",
      "FIELD12": "1",
      "FIELD13": "1",
      "FIELD14": "1"
  },
  {
      "FIELD1": "34157961-491E-E511-80CC-00163E535454",
      "FIELD2": "Survey reports",
      "FIELD3": "4",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "8808C6AB-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "1"
  },
  {
      "FIELD1": "6B16B16C-491E-E511-80CC-00163E535454",
      "FIELD2": "Small area atlas of Bangladesh",
      "FIELD3": "4",
      "FIELD4": "2FA98631-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "435880B3-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "1"
  },
  {
      "FIELD1": "93DB83B2-491E-E511-80CC-00163E535454",
      "FIELD2": "District Gazetteer published",
      "FIELD3": "3",
      "FIELD4": "41FED743-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "445880B3-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "1"
  },
  {
      "FIELD1": "CD282421-4A1E-E511-80CC-00163E535454",
      "FIELD2": "Seminar/Workshop organized",
      "FIELD3": "8",
      "FIELD4": "8FA30A64-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "EDB036BF-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "1"
  },
  {
      "FIELD1": "B3751449-4A1E-E511-80CC-00163E535454",
      "FIELD2": "Trainees attended",
      "FIELD3": "8",
      "FIELD4": "8FA30A64-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "68B73CC8-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "NULL",
      "FIELD11": "NULL",
      "FIELD12": "NULL",
      "FIELD13": "NULL",
      "FIELD14": "1"
  },
  {
      "FIELD1": "F9C60A64-4A1E-E511-80CC-00163E535454",
      "FIELD2": "Trainees sent to International training",
      "FIELD3": "8",
      "FIELD4": "8FA30A64-431E-E511-80CC-00163E535454",
      "FIELD5": "A98D8177-EB13-E511-80CC-00163E535454",
      "FIELD6": "3712EAE0-EA13-E511-80CC-00163E535454",
      "FIELD7": "NULL",
      "FIELD8": "0C3CDDCF-481E-E511-80CC-00163E535454",
      "FIELD9": "NULL",
      "FIELD10": "428A88C7-9A23-E511-80CC-00163E535454",
      "FIELD11": "asd",
      "FIELD12": "NULL",
      "FIELD13": "1",
      "FIELD14": "1"
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
    var fnConfig = [2,11,12,13];
    var params = getParams(json[i],fnConfig);//stringFormat(ActivityId) + ' , ' + stringFormat(Description) + ' , ' + stringFormat(ObjectiveId);
    var command = 'insert into dbo.PerformanceIndicators (' + keyset + ') values (' + params + ');';
    console.log(command);
    //document.writeln(command + "<br/>");
}