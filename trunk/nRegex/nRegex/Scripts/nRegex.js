/* NREGEX - A .NET regular expression evaluator :: https://github.com/t3rse/nRegex
/**
* @author t3rse (David Seruyange) / http://www.t3rse.com
* @author you? - would love comments / feedback
**/

var nRegexEngine = (function () {
    var _ = {
        previousData: '',
        regex: '',
        ignoreCaseOption: '',
        singleLineOption: '',
        multiLineOption: '',
        explicitCapture: '',
        target: '',
        replaceText: '',
        //
        serviceUrl: '',
        evaluateRegex: function () {
            // if there's nothing in regex or target, skip
            if (_.regex.val().length == 0 || _.target.val().length == 0) return;

            var regexPackage = {
                Regex: _.regex.val(),
                Target: _.target.val(),
                IgnoreCase: _.ignoreCaseOption[0].checked,
                SingleLine: _.singleLineOption[0].checked,
                MultiLine: _.multiLineOption[0].checked,
                ExplicitCapture: _.explicitCapture[0].checked,
                ReplaceText: _.replaceText.val()
            };
            var rData = JSON.stringify(regexPackage);
            if (rData == _.previousData) {
                return;
            }
            else {
                _.previousData = rData;
            }
            try {
                $("#regexEntryTextArea").css("background-color", "white");
                $.ajax(
                    {
                        url: _.serviceUrl,
                        type: 'post',
                        data: { queryObject: JSON.stringify(regexPackage) },
                        success: function (responseData, status, xhr) {
                            $("#resultPane").html(responseData);
                            $(".matchAccordion").accordion();
                        },
                        error: function (xhr, status, err) {
                            console.log(err);
                            $("#regexEntryTextArea").css("background-color", "yellow");
                        }
                    }
                );
            }
            catch (x) {
                console.log(x);
            }

        },
        init: function (timeThresh, initParams) {
            _.serviceUrl = initParams.ServiceUrl;
            _.regex = initParams.RegexTextArea;
            _.ignoreCaseOption = initParams.IgnoreCaseCheckbox;
            _.singleLineOption = initParams.SingleLineCheckbox;
            _.multiLineOption = initParams.MultiLineCheckbox;
            _.explicitCapture = initParams.ExplicitCaptureCheckbox;
            _.target = initParams.TargetTextArea;
            _.replaceText = initParams.ReplaceTextArea;
            // call the evaluator every timeThresh interval
            window.setInterval(_.evaluateRegex, timeThresh);
        }
    };

    return {
        init: _.init,
        internals: _
    };

})();