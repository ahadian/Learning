console.log('I am loaded!');

var serverPath = "http://localhost:62731/api/Dictionary/Post";

function getSelectionText() {
    var text = "";
    if (window.getSelection) {
        text = window.getSelection().toString();
    } else if (document.selection && document.selection.type != "Control") {
        text = document.selection.createRange().text;
    }
    return text;
}

document.onclick = function(arg) {
    //console.log(arg);
    var selectedText = getSelectionText();
    console.log('selected text = ', selectedText);
    var params = 'value=' + selectedText;

    var xhr = new XMLHttpRequest();
    
    xhr.open('POST', serverPath, true);
    xhr.onload = function () {
        // do something to response
        console.log(this.responseText);
    };
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    console.log(params);
    xhr.send(params);
}