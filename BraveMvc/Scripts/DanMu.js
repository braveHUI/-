$(function () {
    //打开、关闭弹幕
    $("#dm-open,#dm-close").click(function () {
        $(".dm").toggle(1000);
    });
    //添加弹幕内容
    $(".chat_fabiao").click(function () {
        setTimeout(function () {
            var txt = $(".yincang_content div:last").text();

            var dix = "<div>" + txt + "</div>";
            $(".content_show").append(dix);


            init_screen();
        }, 500)
       
    });
    init_screen();
    setInterval(function () {
        var yinhtml = $(".yincang_content div:last").text();
        var htmls = $(".content_show div:last").text();
       
        if (yinhtml != htmls) {
            var texte = $(".yincang_content div:last").text();
            var dix = "<div>" + texte + "</div>";
            $(".content_show").append(dix);
            init_screen();
        }
    }, 5000);
});
function init_screen() {
    var _top = 0;
    var windasq = $(".detail_video");
    $(".content_show").find("div").show().each(function () {
        //获取弹幕初始位置：让它在最右边
        var _left = $(windasq).width() - $(this).width();
        var _height = $(windasq).height();

        $(this).css({ left: _left, top: _top, color: getRandomColor() });

        _top = _top + 40;
        if (_top >= _height - 100)
            _top = 0;
        
        var time = 10000;
        if ($(this).index() % 2 == 0)
            time = 15000;
        //jQuery动画
        $(this).animate({ left: '-' + _left+ 'px' }, time, "linear");

    });
}
//获取随机颜色
var getRandomColor = function () {
    return '#' +
        (function (color) {
            return (color += '0123456789abcdef'[Math.floor(Math.random() * 16)])
            && (color.length == 6) ? color : arguments.callee(color);
        })('');
}