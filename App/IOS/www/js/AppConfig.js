var curPage = "";
var DreamServer = "http://localhost:55605/";
//var DreamServer = "http://huijiwanjia.com/datacenter/";
var TBKServer = "http://tbkapi.huijiwanjia.com/";

var DreamConfig = {
    accountUrl: DreamServer.concat("dream/auth/"),
    mapRefreshInterval: 6000 * 10 * 2, //2 min
    tokenExpireTime: 7,//days
    attachmentUrl: DreamServer.concat("api/attachment?url="),
    packetRecordsUrl: DreamServer.concat("api/packetrecord/"),
    userInfoUrl: DreamServer.concat("api/user/"),
    withdrawUrl: DreamServer.concat("api/withdrawapply/"),
    tbkQuery: TBKServer.concat("api/tbk"),
    alipayUrl: DreamServer.concat("dream/alipay/"),
    appId: "wxcf1c3c250e5e4d91",
    appSecret: "d4b03bcf09622fc6ea9cad4fdb34ad06",
    clickLog: DreamServer.concat("dream/clicklog/"),
}
var agencyType = {
    NotAgency: 0,
    City: 1,
    Country: 2,
}








