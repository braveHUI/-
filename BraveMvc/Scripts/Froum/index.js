var ha = ($('#videoBox').offset().top + $('#videoBox').height());

$(window).scroll(function () {

    if ($(window).scrollTop() > ha + 500) {
        $('#videoBox').css('bottom', '0');

    } else if ($(window).scrollTop() < ha - 200) {
        $('#videoBox').removeClass('out').addClass('in');
        $('#shipingdaxiao').css({ 'height': '450px' });
    } else {
        $('#videoBox').removeClass('in').addClass('out');
        $('#shipingdaxiao').css({ 'height': '300px' });
        $('#videoBox').css('bottom', '0px');
    };

});