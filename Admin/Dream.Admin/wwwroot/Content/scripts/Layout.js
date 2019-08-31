$(function () {
    $("#about").on("click", function () {
        var msgHtml = "版本号：<span class='red lighter'>" + centerInfo.version + "</span>";
        msgHtml += "<br />";
        msgHtml += "最新更新日期：<span class='red lighter'>" + centerInfo.latestUpdateTime + "</span>";
        msgHtml += "<br />";
        msgHtml += "网址：<span class='red lighter'>" + centerInfo.site + "</span>";
        msgHtml += "<br />";
        msgHtml += "联系地址：<span class='red lighter'>" + centerInfo.address + "</span>";
        msgHtml += "<br />";
        msgHtml += "所属权：<span class='red lighter'>" + centerInfo.companyName + "&copy; 2016-2029</span>";

        bootbox.dialog({
            title: "<i class='fa fa-leaf'></i>&nbsp&nbsp&nbsp&nbsp惠及万家后台管理平台",
            message: msgHtml
        });
    });
});

var centerInfo = {
    version: "1.1",
    latestUpdateTime: "2018-01-18",
    companyName: "惠及万家科技（重庆）有限公司",
    site: "huijiwanjia.com",
    address: "重庆市"
};

var WaitDialog = {
    show: function () {
        //backdrop: 'static', keyboard: false 禁止点击背景和键盘ESC关闭等待框
        $("#WaitDialog").modal({ show: true, backdrop: 'static', keyboard: false });
    },

    hide: function () {
        $("#WaitDialog").modal('hide');
    }
};

var UserStatu = {
    NotCompleted: 0,
    Completed: 1
};
var WithdrawStatu = {
    NotCompleted: 0,
    Completed: 1
};
var OrderState = {
    已付款: 0,
    已收货: 1,
    已结算: 2,
    已失效: 3,
    已返利: 4
};

var config = {
    dataProcessUrl: "/DataProcess/import",
    userUrl: "http://api.huijiwanjia.com/dream/User",
    orderPaginationUrl: "http://api.huijiwanjia.com/dream/Order/pagination",
    orderChangeStatusUrl: "http://api.huijiwanjia.com/dream/Order/changestatus",
    withdrawUrl: "http://api.huijiwanjia.com/dream/Profit/GetWithdrawApply",
    withdrawChangeStatusUrl: "http://api.huijiwanjia.com/dream/Profit/ChangeStatus",
    wechatAppid: "wx457087c6f3e2d3be",
    wechatAppSecret: "fae0a7e5a5c6e480f7e50c7cca4988b2"
};
