$(function () {
    $("input[id=input1]").focus(function (even) {
        var pos = $(this).offset();
        $(".box").css({ display: "block" });
    });
    $("#searchBtn").on('click', function () {
        var keyValue = $.trim($("#input1").val());
        if (keyValue != "")
            window.open("https://ai.taobao.com/search/index.htm?key=" + keyValue + "&pid=mm_26940838_23770772_79264527")
        else
            window.open("https://s.click.taobao.com/t?e=m%3D2%26s%3Dt7SyaZ%2BeKrEcQipKwQzePCperVdZeJviK7Vc7tFgwiFRAdhuF14FMdXHBd53VmFHlovu%2FCElQOswu1A%2Bm6O3H62VQyeDdXrMyTvRS7kO%2FPKECvskMmpXyY7LAa3DUrM2zt5vEinufIW9AmARIwX9K84wywOXuyrlfjxl6AIniNq%2FN0khoSsOCsWdRNmtA%2BkW%2Ba5MsrQmHtLNJQsCgQmJeIXsRjRrjdUgca8lOOFYzXidzyyO9CIkVdQc6rs1qJwrxg5p7bh%2BFbQ%3D");
    });
    $("#wechat").mouseover(function () {
        $("#gongzhonghao").show();
        $(".qrcode").fadeIn();
    }).mouseout(function () {
        $(".qrcode").fadeOut();
        $("#gongzhonghao").hide();
    });
    $("#appdownload").mouseover(function () {
        $("#app").show();
        $(".qrcode").fadeIn();
    }).mouseout(function () {
        $(".qrcode").fadeOut();
        $("#app").hide();
    });
    document.onclick = function (e) {

        var e = e ? e : window.event;
        var tar = e.srcElement || e.target;
        if (tar.id != "input1") {
            if ($(tar).attr("class") == "box") {
                $(".box").css("display", "block")
            } else {
                $(".box").css("display", "none");
            }
        }
    }
})

