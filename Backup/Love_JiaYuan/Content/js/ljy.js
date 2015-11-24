/// <reference path="jquery-1.11.1.min.js" />
$(function () {
    $('#content').masonry({
        // options  
        itemSelector: '.item',
        columnWidth: 300
    });



    $("#form1").submit(function () {
        var ages = $("#ages").val();
        var agee = $("#agee").val();

        if (ages > agee) {
            alert("年龄不正确！");
            return false;
        }
    });




    $("#subl").click(function () {
        var area = $("#area").val();
        var ages = $("#ages").val();
        var agee = $("#agee").val();

        if (ages > agee) {
            alert("年龄不正确！");
            return false;
        }

        $.post("/Home/AsynData", { area: area, ages: ages, agee: agee }, function (data) {
            //alert(data.count)
            if (data.count > 0) {
                var content = $("#content");
                $.each(data.userInfo, function (i, v) {
                    // alert(v.nickname)
                    $('<div class="item"><div class="row-fluid"><div class="col-md-6 column"><img alt="140x140" src="' + v.image + '" class="img-thumbnail" /></div><div class="col-md-6"><p class="name">' + v.nickname + '</p><span class="label label-success">' + v.age + ' 岁</span><span class="label label-success">' + v.work_location + '</span><p class="zhufang">' + v.randTag + '</p></div></div><div class="row-fluid"><div class="col-md-12 column info"><p>身高：' + v.height + ' cm    &nbsp;&nbsp; 学历：' + v.education + ' <br />是否在线：' + v.online + '</p><span>她的Tags:</span><p class="tag">' + v.randListTag + '</p><span>她的择偶标准：</span><p class="alert alert-info" role="alert">' + v.matchCondition + '</p><span>她的自我介绍：</span><p class="alert alert-warning" role="alert">' + v.shortnote + '</p></div></div></div>').appendTo(content);
                });
                //
                //var item = $('<div class="item"></div>').appendTo(content);

            }


        });





    });


});