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
        msgHtml += "所属权：<span class='red lighter'>" + centerInfo.companyName + "&copy; 2016-2017</span>";

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
}

var WaitDialog = {
    show: function () {
        //backdrop: 'static', keyboard: false 禁止点击背景和键盘ESC关闭等待框
        $("#WaitDialog").modal({ show: true, backdrop: 'static', keyboard: false });
    },

    hide: function () {
        $("#WaitDialog").modal('hide');
    }
};

var WithdrawApplyStatu = {
    NotCompleted: 0,
    Completed: 1
}

var config = {
    withdrawApplyApiUrl: "http://sc.handsave.com/api/WithdrawApply",
    userManageUrl: "http://sc.handsave.com/api/UserManage",
    withdrawApplyStatusUrl:"http://sc.handsave.com/api/withdrawApplyStatus",
    dataProcessUrl:"/DataProcess/import",
    redpacketApiUrl: "http://sc.handsave.com/api/RedPacket",
    accountUrl: "http://sc.handsave.com/api/Account",
    userUrl: "http://sc.handsave.com/api/User",
    teamUrl: "http://sc.handsave.com/api/Team",
    profitsUrl: "http://sc.handsave.com/api/Profit",
    recommentUrl: "http://sc.handsave.com/api/Recomment",
    userRelationUrl:"http://sc.handsave.com/api/UserRelation",
    wechatAppid: "wx457087c6f3e2d3be",
    wechatAppSecret:"fae0a7e5a5c6e480f7e50c7cca4988b2",
}
