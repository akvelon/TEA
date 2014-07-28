﻿$(function() {
    var taskCount = 1;

    var setButton = function() {
        if ($('.has-error').length == 0 && $('.input-poll').length > 1) {
            $(':submit').prop('disabled', false);
        } else {
            $(':submit').prop('disabled', true);
        }
    }

    var inputHandler = function(event) {
        var item = $(this);

        if (item.val() == '') {
            item.parent().addClass('has-error');
        }
        else if (item.parent().hasClass('has-error')) {
            item.parent().removeClass('has-error');
        }

        setButton();
    }

    var appendHandler = function (event) {
        var hasText = true;

        $('.input-poll').each(function() {
            if ($(this).val() == '') {
                hasText = false;
            }
        });

        if (hasText) {
            $('.input-poll:last').attr('placeholder', 'Leave this field filled in or remove it')
                .on("keyup", inputHandler)
                .attr('name', 'dsc')
                .after('<div class="input-group-btn"><button type="button" class="btn btn-default" tabindex="-1"><span class="glyphicon glyphicon-remove"></span></button></div>')
                .next().on('click', removeHandler).end()
                .prev().text(taskCount++);

            $('.input-poll').off("keyup", appendHandler);

            $('<div class="input-group input-group-poll"><span class="input-group-addon"><span class="glyphicon glyphicon-pencil"></span></span><input type="text" placeholder="Type here to add another text field" class="form-control input-poll"/></div>')
                .css('display', 'none')
                .appendTo('#maincontent')
                .slideDown(100);

            $('.input-poll:last').on("keyup", appendHandler);
        }
    }

    var removeHandler = function(event) {
        $(this).parent().remove();

        taskCount = 1;
        $('.input-group-poll:not(:last) > .input-group-addon').each(function() {
            $(this).text(taskCount++);
        });

        setButton();
    }

    $('.input-poll:last').on("keyup", appendHandler);
});