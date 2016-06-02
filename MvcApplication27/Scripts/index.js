//$(function() {
//    $("#clickMe").on('click', function () {
//        var min = $("#min").val();
//        var max = $("#max").val();
//        $.get('/home/getrandom?min=' + min + "&max=" + max, function (result) {
//            $("#number").text(result.Number);
//            result.MoreNums.forEach(function (num) {
//                $("ul").append("<li>" + num + "</li>");
//            });
//        });
//    });
//});

$(function() {
    $("#clickMe").on('click', function () {
        var minText = $("#min").val();
        var maxText = $("#max").val();
        $.post('/home/getrandom', { min: minText, max: maxText }, function (result) {
            $("#number").text(result.Number);
            result.MoreNums.forEach(function (num) {
                $("ul").append("<li>" + num + "</li>");
            });
        });
    });

    $("#username").on('input', function() {
        var text = $(this).val();
        $.get('/home/isusernameavailable', { username: text }, function(result) {
            $("#info").text(result.isAvailable ? "Go for it!" : "Sorry try again");
            $("#submit-button").prop('disabled', !result.isAvailable);
        });
    });

    $("#reverse-button").on('click', function() {
        var text = $("#sometext").val();
        $.get('/home/reversed', { text: text }, function(result) {
            $("#reversed").text(result.reversed);
        });
    });
});
