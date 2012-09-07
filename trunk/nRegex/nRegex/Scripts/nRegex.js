$(function () {

    window.setInterval(function () {
        var _rg = $("#regexEntryTextArea").val();
        var _target = $("#regexTargetArea").val();
        console.log("Regex: " + _rg + " / Target: " + _target);
    }, 500);


});