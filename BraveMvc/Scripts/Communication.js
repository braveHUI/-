

//获取私信内容


//获取聊天内容
$(".sixin423-switch-friend").click(function () {
    $(this).closest(".commun_ren").children(":eq(2)").hide(500);
    $(this).closest(".commun_ren").children(":eq(3)").show(500);
    $(this).addClass('onaction').siblings().removeClass('onaction');
    var panren = $(this).closest(".commun_ren").children(":eq(3)").children(".sixin423-users-row-active").children(":eq(1)").text();
    var panrenid = $(this).closest(".commun_ren").children(":eq(3)").children(".sixin423-users-row-active").children(".dangqiasdsd_id").val();
    $(".lian_content").children().remove();
    $(".lian_content").append('<div id="contant_loatiande"></div>')
    $(".sixing_pople").children().text("正在与 " + panren + " 聊天");
    $("#message_user_id").val(panrenid);
})
//选择与人聊天
$(".sixin423-users-row").click(function () {
    var dewqzhi = $(this).children(":eq(1)").text();
    var dewqzhiid = $(this).children(".dangqiasdsd_id").val();
    var messcontent = $(this).children(".content_message").val();
    var time = $(this).children(".sixin_shijian").val();
    var img = $(this).children('img').attr('src');
    var communid = $(this).children(".sixin_communicaid").val();

    $(this).addClass('sixin423-users-row-active').siblings().removeClass('sixin423-users-row-active');
    $(".sixing_pople").children().text("正在与 " + dewqzhi + " 聊天");
    $("#message_user_id").val(dewqzhiid);
    $(".sdadweqdasdsdvqq").remove();
    $(".yonghu_content").remove();
    $(".lian_content_liaotian").append('<div class="row sdadweqdasdsdvqq"><div class="mesaage_user_conhjtent"> <div class="sixin_content_time">' + time + '</div> <img src=' + img + ' /> <span class="sixin_user_contekjkng"> ' + messcontent + ' </span> </div> </div>');
    if (communid > 0) {
        $.ajax({
            type: "post",
            url: "/Communication/Update",
            data: { id: communid },
            success: function (data) {


            }
        });
    }

})
//聊天初始化
$(document).ready(function () {
    var sdeqw = $(".sixing_pople").children();
    var panduan = $(".commun_ren").children(":eq(2)");
    $(".commun_ren").children(":eq(3)").children(":eq(0)").addClass('sixin423-users-row-active')
    $(".commun_ren").children(":eq(2)").children(":eq(0)").addClass('sixin423-users-row-active')

    var deadew;

    deadew = $(".commun_ren").children(":eq(2)").children(".sixin423-users-row-active").children(":eq(1)").text();
    var usdfid = $(".commun_ren").children(":eq(2)").children(".sixin423-users-row-active").children(".dangqiasdsd_id").val();
    var messcontent = $(".commun_ren").children(":eq(2)").children(".sixin423-users-row-active").children(".content_message").val();
    var time = $(".commun_ren").children(":eq(2)").children(".sixin423-users-row-active").children(".sixin_shijian").val();
    var img = $(".commun_ren").children(":eq(2)").children(".sixin423-users-row-active").children('img').attr('src');

    sdeqw.text("正在与 " + deadew + " 聊天");
    $("#message_user_id").val(usdfid);
    $(".sdadweqdasdsdvqq").remove();
    $(".yonghu_content").remove();
    $(".lian_content_liaotian").append('<div class="row sdadweqdasdsdvqq"><div class="mesaage_user_conhjtent"> <div class="sixin_content_time">' + time + '</div> <img src=' + img + ' /> <span class="sixin_user_contekjkng"> ' + messcontent + ' </span> </div> </div>');
})


