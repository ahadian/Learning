//document.write('Hello');
var json = [
    {
        "FIELD1": "ActivityId",
        "FIELD2": "Description",
        "FIELD3": "ObjectiveId"
    },
    {
        "FIELD1": "AAA0E890-0410-E511-80CC-00163E535454",
        "FIELD2": "Review and update the existing Staistics Act and submit the final draft to Legislative Division",
        "FIELD3": "2F02488A-0410-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "53F1852E-0610-E511-80CC-00163E535454",
        "FIELD2": "Review and update the Allocation of Business of SID and submit to the cabinet Division",
        "FIELD3": "2F02488A-0410-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "829D6364-0610-E511-80CC-00163E535454",
        "FIELD2": "Formulation of national Informatics policy",
        "FIELD3": "2F02488A-0410-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "87705A79-0610-E511-80CC-00163E535454",
        "FIELD2": "Compilation and release of Estimates of National Income",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "BA0C4685-0610-E511-80CC-00163E535454",
        "FIELD2": "Compilation and release of monthly Consumer Price Index (CPI)",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "4470DA8E-0610-E511-80CC-00163E535454",
        "FIELD2": "Compilation and release of monthly Quantum Index of Industrial Production (QIIP)",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "2FA98631-431E-E511-80CC-00163E535454",
        "FIELD2": "Bringing out statistical publications",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "41FED743-431E-E511-80CC-00163E535454",
        "FIELD2": "Publication of District Gazetteer",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "BC67065A-431E-E511-80CC-00163E535454",
        "FIELD2": "National Household Data collection and compilation",
        "FIELD3": "F7289B03-0610-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "8FA30A64-431E-E511-80CC-00163E535454",
        "FIELD2": "Cooperation with national and international organizations regarding training of statistics",
        "FIELD3": "E2083506-431E-E511-80CC-00163E535454"
    },
    {
        "FIELD1": "90A30A64-431E-E511-80CC-00163E535454",
        "FIELD2": "Ensuring “NSDS Implementation Assistance programme”",
        "FIELD3": "E2083506-431E-E511-80CC-00163E535454"
    }
];
function stringFormat(arg) {
    return "'" + arg + "'";
}
console.log(json);
for (var i = 1; i < json.length; i++) {
    var ActivityId = json[i].FIELD1;
    var Description = json[i].FIELD2;
    var ObjectiveId = json[i].FIELD3;
    var params = stringFormat(ActivityId) + stringFormat(Description) + stringFormat(ObjectiveId);

    var command = 'insert into dbo.Activities (ActivityId,Description,ObjectiveId) values (' + params + ');' + "<br/>";
    document.writeln(command);
}