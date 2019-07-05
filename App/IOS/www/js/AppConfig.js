﻿var curPage = "";
var curLocation = null;
var curCity = "";
//var SCServer = "http://192.168.48.1:8084/";
var SCServer = "http://sc.handsave.com/";
var mapRefreshInterval = null;

var scConfig = {
    iMServer: SCServer.concat("signalr"),
    redPacketsUrl: SCServer.concat("api/redpacket/"),
    accountUrl: SCServer.concat("api/dream/auth/"),
    mapRefreshInterval: 6000 * 10 * 2, //2 min
    tokenExpireTime: 7,//days
    attachmentUrl: SCServer.concat("api/attachment?url="),
    packetRecordsUrl: SCServer.concat("api/packetrecord/"),
    userInfoUrl: SCServer.concat("api/user/"),
    withdrawUrl: SCServer.concat("api/withdrawapply/"),
    alipayUrl: SCServer.concat("api/alipay/"),
    appId: "wxcf1c3c250e5e4d91",
    appSecret: "d4b03bcf09622fc6ea9cad4fdb34ad06",
    profitsUrl: SCServer.concat("api/profit/"),
    teamUrl: SCServer.concat("api/team/"),
    userContactsUrl: SCServer.concat("api/usercontacts/"),
    chatUrl: SCServer.concat("api/message/"),
}
var agencyType = {
    NotAgency: 0,
    City: 1,
    Country: 2,
}







