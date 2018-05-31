
$(function () {
    var jsonContainer = $('#json-container');
    try {
        var json = $('#jsoninput').val();
        console.log(json);
    }
    catch (exception) {
        console.log(exception.message);
    }
    jsonContainer
        .jsonPresenter('destroy') // Clear any previous JSON being presented through this plugin for this container
        .jsonPresenter({ // Use the jquery.jsonPresenter plugin using the input from the textarea above
            json: json
        })
        .jsonPresenter('expand', 0); // Expand all JSON properties so that none of them are collapsed
});
