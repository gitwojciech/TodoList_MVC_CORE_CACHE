

$(document).ready(function () {
       

    function ajaxRemoveBtnClick() {
        var $form = $(this);
        var id = $form.attr('todoTaskId');
        var options = {
            url: $form.attr("href"),
            //type: $form.attr("method"),
            data: {
                todoTaskId: id
            }
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-tdl-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
    };

    function ajaxCheckBoxChange() {
        var $form = $(this);
        var id = $form.attr('id');
        var status = $form.prop('checked');
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: {
                todoTaskId: id,
                status: status
                }
            };

        $.ajax(options).done(function (response) {
            console.log(response);
            let  description = document.getElementById("description " + id).innerHTML.replace("<del>", "").replace("<\del>", "");
            if (status == true)
                document.getElementById("description " + id).innerHTML = "<del>" + description + "</del>";
            else
                document.getElementById("description " + id).innerHTML = description;
        });

        return false;
    };

    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-tdl-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        return false;
     };
   

    $("form[data-tdl-ajax='true']").submit(ajaxFormSubmit);
    $(document).on("change", ".tdlCheckBox", ajaxCheckBoxChange);
    $(document).on("click", ".tdlRemoveBtn", ajaxRemoveBtnClick);


   
});
