/* NREGEX - A .NET regular expression evaluator :: https://github.com/t3rse/nRegex
/**
* @author t3rse (David Seruyange) / http://www.t3rse.com
* @author you? - would love comments / feedback
**/

var nRegexEngine = (function () {
    var _ = {
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
            var regexPackage = {
                Regex: _.regex.val(),
                Target: _.target.val(),
                IgnoreCase: _.ignoreCaseOption[0].checked,
                SingleLine: _.singleLineOption[0].checked,
                MultiLine: _.multiLineOption[0].checked,
                ExplicitCapture: _.explicitCapture[0].checked,
                ReplaceText: _.replaceText.val()
            };
            try {
                $.ajax(
                    {
                        url: _.serviceUrl,
                        type: 'post',
                        data: { queryObject: JSON.stringify(regexPackage) },
                        success: function (responseData, status, xhr) {
                            $("#resultPane").html(responseData);
                            // console.log(responseData);
                        },
                        error: function (xhr, status, err) {
                            console.log(err);
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
            //window.setInterval(_.evaluateRegex, timeThresh);
        }
    };

    return {
        init: _.init,
        internals: _
    };

})();