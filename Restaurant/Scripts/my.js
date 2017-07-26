
//$ invokes a jquery and pass in a function
//$ mean jquery will execute code when dom is ready
$(function(){
    
    //a jquery selector for looking all forms that mach particular attribute
    //jquery can use css selectors
    //when we selected elements we wire up submit event 
    //when user clicks submit button
    //instead post event to the server it will go to my.js code ajaxFormSubmit
    $("form[data-my-ajax='true']").submit(ajaxFormSubmit);
   
    var submitAutocompleteForm = function (event, ui) {
        //this will point to dom element that we interacting with (input)
        var $input = $(this);
        //we set its value
        //ui is a parameter that autocomplete passes in
        $input.val(ui.item.label);
        //finding the form first
                                    //first form
        var $form = $input.parents("form:first");
        //tell aform to submit itself
        $form.submit();

    }

    var createAutocomplete = function () {
        //when jquery invokes this function it will pass along the input as this parameter
        //for each input it finds with data-my-autocomplete attribute it will invoke this func
        //and pass along this single input as this reference
        //wraping into jquery
        var $input = $(this);

        var options = {
            //tell widget autocomplete where get the data
            //we just take the url that embeded in data- attribute
            //will pull out using attribute 'attr' and put it on a source property on options object
            source: $input.attr("data-my-autocomplete"),
            //when a user selects something
            //we call a function submitAutocompleteForm
            select: submitAutocompleteForm 
        };

        //to wire up autocomplete we need to go to input invoke autocomplete and oass it option object
        $input.autocomplete(options);
    };


    //this function will handle submition
    var ajaxFormSubmit = function () {
        //take a referencer of the form that is being submited
        //this reference inside eventhandler
        //we wrap inside jquery
        var $form = $(this);

        var options = {
            //url we will go to look for action attribute
            url: $form.attr("actioh"),
            //type of requett get/post we get it from method attribute on a form
            type: $form.attr("method"),
            //data to send to the server
            data: $form.serialize()
        };

        //asynk call with $.ajax
        //this a callback function
        //if it is successful it will send back data
        $.ajax(options).done(function (data) {
            //take a identifier data-my-target
            var $target = $($form.attr('data-my-target'));
            //we replace data-my-target with html we got from the server
            $target.replaceWith(data);
        });
    //stop browser his default actioh from going to the server and redrawing page
        return false;

    };


    $("input[data-my-autocomplete]").each(createAutocomplete);
});