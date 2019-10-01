var curPage = "";
//var DreamServer = "http://localhost:55605/";
var DreamServer = "http://api.huijiwanjia.com/";
var TBKServer = "http://tbk.huijiwanjia.com/";
//var TBKServer = "http://localhost:63224/";

var DreamConfig = {
    isDebug: false,
    shareBackRate:0.2,
    accountUrl: DreamServer.concat("dream/auth/"),
    tokenExpireTime: 7,//days
    attachmentUrl: DreamServer.concat("dream/attachment?url="),
    packetRecordsUrl: DreamServer.concat("dream/api/packetrecord/"),
    userInfoUrl: DreamServer.concat("dream/user/"),
    profitUrl: DreamServer.concat("dream/profit/"),
    tbkQuery: TBKServer.concat("api/tbk"), 
    tbkOptimusGet: TBKServer.concat("api/OptimusGet"),
    alipayUrl: DreamServer.concat("dream/alipay/"),
    appId: "wxcf1c3c250e5e4d91",
    appSecret: "d4b03bcf09622fc6ea9cad4fdb34ad06",
    clickLog: DreamServer.concat("dream/clicklog/"),
    userOrders: DreamServer.concat("dream/order")
};
var agencyType = {
    NotAgency: 0,
    City: 1,
    Country: 2
};








