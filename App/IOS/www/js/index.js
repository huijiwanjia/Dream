/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

var app = {
    // Application Constructor
    initialize: function () {
        this.RouteInit();
        this.bindEvents();
    },
    // Bind Event Listeners
    //
    // Bind any events that are required on startup. Common events are:
    // 'load', 'deviceready', 'offline', and 'online'.
    bindEvents: function () {
        document.addEventListener('deviceready', this.onDeviceReady, false);
        // disable back button in andriod
        //document.addEventListener("backbutton", this.BackButtonCallback, false);
    },
    // deviceready Event Handler
    //
    // The scope of 'this' is the event. In order to call the 'receivedEvent'
    // function, we must explicitly call 'app.receivedEvent(...);'
    onDeviceReady: function () {
        app.receivedEvent('deviceready');
    },
    // Update DOM on a Received Event
    receivedEvent: function (id) {
        StatusBar.styleDefault();
        StatusBar.overlaysWebView(true);
        //init fast click
        FastClick.attach(document.body);
    },
    BackButtonCallback: function () { },
    RouteInit: function () {
        angular.module('ngRouteScApp', ['ui.router', 'ngAnimate'])
            .config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
                $stateProvider
                    .state('guide', {
                        url: "/guide",
                        views: {
                            'other': {
                                templateUrl: 'views/guide.html',
                                controller: 'GuideController'
                            }
                        }
                    })
                    .state('home', {
                        url: "/home",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/home.html',
                                controller: 'HomeController'
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }

                    })
                    .state('rebate', {
                        url: "/rebate",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/rebate.html',
                                controller: 'RebateController'
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }

                    })
                    .state('login', {
                        url: "/login",
                        views: {
                            'other': {
                                templateUrl: 'views/login.html',
                                controller: 'LoginController'
                            }
                        }
                    })

                    .state('userpage', {
                        url: "/userpage",
                        views: {
                            'other': {
                                templateUrl: 'views/userpage.html',
                                controller: 'UserpageController'
                            }
                        },
                        params: {
                            userId: null,
                            returnUrl: null
                        }
                    })
                    .state('order', {
                        url: "/order",
                        views: {
                            'other': {
                                templateUrl: 'views/order.html',
                                controller: 'OrderController'
                            }
                        }
                    })
                    .state('results', {
                        url: "/results",
                        views: {
                            'other': {
                                templateUrl: 'views/results.html',
                                controller: 'ResultsController'
                            }
                        },
                        params: {
                            itemName: null,   
                        }
                    })
                    .state('category', {
                        url: "/category",
                        views: {
                            'other': {
                                templateUrl: 'views/category.html',
                                controller: 'CategoryController'
                            }
                        },
                        params: {
                            type: null,
                            pageTitle:null
                        }
                    })
                    .state('bindAlipay', {
                        url: "/bindAlipay",
                        views: {
                            'other': {
                                templateUrl: 'views/bindAlipay.html',
                                controller: 'BindAlipayController'
                            }
                        },
                        params: {
                            alipay: null,
                            alipayName: null,
                            phone: null
                        }
                    })
                    .state('search', {
                        url: "/search",
                        views: {
                            'other': {
                                templateUrl: 'views/search.html',
                                controller: 'SearchController'
                            }
                        }
                    })
                    .state('setting', {
                        url: "/setting",
                        views: {
                            'other': {
                                templateUrl: 'views/setting.html',
                                controller: 'SettingController'
                            }
                        }
                    })
                    .state('team', {
                        url: "/team",
                        views: {
                            'other': {
                                templateUrl: 'views/team.html',
                                controller: 'TeamController'
                            }
                        }
                    })
                    .state('agency', {
                        url: "/agency",
                        views: {
                            'other': {
                                templateUrl: 'views/agency.html',
                                controller: 'AgencyController'
                            }
                        }
                    })
                    .state('update', {
                        url: "/update",
                        views: {
                            'other': {
                                templateUrl: 'views/update.html',
                                controller: 'UpdateController'
                            }
                        },
                        params: {
                            obj: { title: null, type: null, value: null }
                        }
                    })
                    .state('qrcode', {
                        url: "/qrcode",
                        views: {
                            'other': {
                                templateUrl: 'views/qrcode.html',
                                controller: 'QrcodeController'
                            }
                        }
                    })
                    .state('profits', {
                        url: "/profits",
                        views: {
                            'other': {
                                templateUrl: 'views/profits.html',
                                controller: 'ProfitsController'
                            }
                        }
                    })
                    .state('withdraw', {
                        url: "/withdraw",
                        views: {
                            'other': {
                                templateUrl: 'views/withdraw.html',
                                controller: 'WithdrawController'
                            }
                        }
                    })
                    .state('success', {
                        url: "/success",
                        views: {
                            'other': {
                                templateUrl: 'views/success.html',
                                controller: 'SuccessController'
                            }
                        },
                        params: {
                            obj: { header: null, title: null, details: null, amount: null }
                        }
                    })
                    .state('recommend', {
                        url: "/recommend",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/recommend.html',
                                controller: 'RecommendController'
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }
                    })
                    .state('my', {
                        url: "/my",
                        cache: true,
                        views: {
                            'content': {
                                templateUrl: 'views/my.html',
                                controller: 'MyController',
                            },
                            'footer': {
                                templateUrl: 'views/footer.html',
                                controller: 'FooterController'
                            }
                        }
                    });

                $urlRouterProvider.otherwise('/login');
            })
            .animation('.fade', function () {
                return {
                    enter: function (element, done) {
                        element.css({
                            opacity: 0
                        });
                        element.animate({
                            opacity: 1
                        }, 150, done);
                    },
                    leave: function (element, done) {
                        element.css({
                            opacity: 1
                        });
                        element.animate({
                            opacity: 0
                        }, 150, done);
                    }
                };
            })
            .factory('ls', ['$window', function ($window) {
                return {
                    set: function (key, value) {
                        $window.localStorage[key] = value;
                    },
                    get: function (key, defaultValue) {
                        return $window.localStorage[key] || defaultValue;
                    },
                    setObject: function (key, value) {
                        $window.localStorage[key] = JSON.stringify(value);
                    },
                    getObject: function (key) {
                        return JSON.parse($window.localStorage[key] || '{}');
                    },
                    clear: function () {
                        $window.localStorage.clear();
                    }
                };
            }])
            .service('sc', function ($state, ls, $http, $rootScope, $window) {
                this.checkTicketStillActive = function () {
                    var loginTime = ls.get('loginTime');
                    if (loginTime) {
                        var curTime = new Date();
                        var diff = curTime.getTime() - new Date(loginTime).getTime();
                        var diffDays = diff / (24 * 3600 * 1000);//相差天数
                        //判断凭证是否过期
                        if (diffDays < DreamConfig.tokenExpireTime) {
                            $state.go('home');
                        }
                        else {
                            ls.clear();
                        }
                    }
                };
                this.ValidateLogin = function () {
                    var userId = ls.getObject('userInfo').UserId;
                    if (typeof (userId) === "undefined") $state.go('login');
                };
                this.Login = function () {
                    //get from tencent
                    if (!DreamConfig.isDebug) {
                        Wechat.isInstalled(function (installed) {
                            var scope = "snsapi_userinfo",
                                state = "_" + (+new Date());
                            Wechat.auth(scope, state, function (response) {
                                // you may use response.code to get the access token.
                                //get access_token
                                var authUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + DreamConfig.appId + "&secret=" + DreamConfig.appSecret + "&code=" + response.code + "&grant_type=authorization_code";
                                Get($http, authUrl, function (data) {
                                    //get userinfo
                                    Get($http, "https://api.weixin.qq.com/sns/userinfo?access_token=" + data.access_token + "&openid=" + data.openid, function (userInfo) {
                                        //check user
                                        Post($http, DreamConfig.accountUrl, { openId: userInfo.openid, avatarUrl: userInfo.headimgurl, name: userInfo.nickname, sex: userInfo.sex, unionid: data.unionid }, function (authedUser) {
                                            ls.setObject('userInfo', authedUser);
                                            ls.set('loginTime', new Date());
                                            $state.go('home');
                                        });
                                    });
                                });
                            }, function (reason) {
                                DeviceEvent.Toast("Failed: " + reason);
                            });
                        }, function (reason) {
                            DeviceEvent.Toast("Failed: " + reason);
                        });
                    }
                    else {
                        var userInfo = { OpenId: "opaKA1SkGI3-qLqMSPW_Nlpz4byY", Phone:'17623852229',AvatarUrl: "http://thirdwx.qlogo.cn/mmopen/vi_32/DYAIOgq83eqKNWm1GAstFo4C5Zmwmwtl1nH8GNqTMGGJUMIIsR06bHULD6b1kGDaGEsdBiardvErKWwnw4ibibb6A/132", UnionId: "oMicm5ntgIaYSRsxMGg4KUgEQr5E", Name: "蜡笔小新", Sex: 1, UserId: 3 };
                        ls.setObject('userInfo', userInfo);
                        ls.set('loginTime', new Date());
                        $state.go('home');
                    }
                };
                this.logOut = function () {
                    DeviceEvent.Confirm("退出之后需要重新登陆",
                        function (buttonIndex) {
                            if (buttonIndex === 1) {
                                ls.clear();
                                ls.set('guideIsChecked', true);
                                $state.go('login');
                            }
                        }, "请确认退出", ['确认', '取消']);
                };
            })
            .controller('GuideController', function ($scope, ls, $state) {
                var swiper = new Swiper('.swiper-container', {
                    pagination: {
                        el: '.swiper-pagination',
                    },
                });
                $scope.goLogin=function(){
                    ls.set('guideIsChecked', true);
                    $state.go('login');
                };
            })

            .controller('UserpageController', function ($scope, $http, $state, sc, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go($stateParams.returnUrl);
                };
                Get($http, DreamConfig.userInfoUrl + "getbyid?userId=" + $stateParams.userId, function (userInfo) {
                    $scope.userInfo = userInfo;
                });
            })
            .controller('UpdateController', function ($scope, $http, $state, sc, ls, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('setting');
                };
                $scope.updateInfo = $stateParams.obj;
                $scope.save = function () {
                    var userInfo = {};
                    switch ($scope.updateInfo.type) {
                        case "name":
                            userInfo = { UserId: ls.getObject("userInfo").UserId, Name: $scope.updateInfo.value };
                            break;
                        case "alipay":
                            userInfo = { UserId: ls.getObject("userInfo").UserId, AliPay: $scope.updateInfo.value };
                            break;
                        case "alipayName":
                            userInfo = { UserId: ls.getObject("userInfo").UserId, AliPayName: $scope.updateInfo.value };
                            break;
                        case "phone":
                            userInfo = { UserId: ls.getObject("userInfo").UserId, Phone: $scope.updateInfo.value };
                            break;
                    }
                    Post($http, DreamConfig.userInfoUrl, userInfo, function (user) {
                        ls.setObject("userInfo", user);
                        $state.go('setting');
                    });
                };
            })
            .controller('TeamController', function ($scope, $http, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.goUserpage = function (userId) {
                    $state.go('userpage', { userId: userId, returnUrl: "team" });
                };
                Get($http, DreamConfig.userInfoUrl.concat("GetTeamById?userId=" + ls.getObject("userInfo").UserId), function (team) {
                    $scope.teamInfo = team;
                    console.log(team);
                });
            })
            .controller('ResultsController', function ($scope, $filter, $http, $state, sc, ls, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('home');
                };
                $scope.ClickLog = function (itemId, url, imgUrl) {
                    Post($http, DreamConfig.clickLog, { UserId: ls.getObject("userInfo").UserId, ItemId: itemId, Url: url, ImgUrl: imgUrl }, function (data) {
                    });
                };

                $scope.QueryText = $stateParams.itemName;
                $scope.QueryResult = {};
                $scope.Query = function () {
                    Post($http, DreamConfig.tbkQuery, { q: $scope.QueryText, pagesize: 100, platform:2 }, function (data) {
                        data = JSON.parse(data);
                        var ret = data.tbk_dg_material_optional_response.result_list.map_data;
                        for (i = 0; i < ret.length; i++) {
                            if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                            else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                            if (ret[i].zk_final_price == null) ret[i].zk_final_price = 0;
                            else ret[i].zk_final_price = parseFloat(ret[i].zk_final_price);
                            if (ret[i].tk_total_sales == null) ret[i].tk_total_sales = 0;
                            else ret[i].tk_total_sales = parseInt(ret[i].tk_total_sales);
                            if (ret[i].commission_rate == null) ret[i].commission_rate = 0;
                            else ret[i].commission_rate = parseFloat(ret[i].commission_rate);

                            if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                            else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                        }
                        $scope.QueryResult = ret;
                        console.log($scope.QueryResult);
                    });
                };
                var orderBy = $filter('orderBy');
                $scope.OrderBy = function (predicate, reverse) {
                    $scope.QueryResult = orderBy($scope.QueryResult, predicate, reverse);
                };
                $scope.Query();
            })
            .controller('SearchController', function ($scope, $http, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('home');
                };
                $scope.itemName = "";
                $scope.ToResult = function () {
                    $state.go('results', { itemName: $scope.itemName });
                };
              
            })
            .controller('BindAlipayController', function ($scope, $http, $state, sc, ls, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.alipay = $stateParams.alipay;
                $scope.alipayName = $stateParams.alipayName;
                $scope.phone = $stateParams.phone;

                $scope.submit = function () {
                    userInfo = { UserId: ls.getObject("userInfo").UserId, Alipay: $scope.alipay, AliPayName: $scope.alipayName, Phone: $scope.phone };
                    Post($http, DreamConfig.userInfoUrl, userInfo, function (user) {
                        ls.setObject("userInfo", user);
                        DeviceEvent.Toast("信息以完善，请重新提现");
                        $state.go('my');
                    });
                };
            })
            .controller('AgencyController', function ($scope, $state, $http, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };

                $scope.buyAgency = function (type) {
                    var title = "";
                    var amount = 0;
                    var subject = "";
                    var payInfo = "";

                    if (type === 1) {
                        if (ls.getObject("userInfo").AgencyType === 1 || ls.getObject("userInfo").AgencyType === 2) {
                            DeviceEvent.Toast("您已经是代理");
                            return;
                        }
                        title = "市区代理已生效";
                        subject = "市区代理";
                        amount = 0.01;
                    }
                    else {
                        if (ls.getObject("userInfo").AgencyType === 2) {
                            DeviceEvent.Toast("您已经是全国代理");
                            return;
                        }
                        title = "全国代理已生效";
                        subject = "全国代理";
                        amount = 0.01;
                    }
                    // 第一步：订单在服务端签名生成订单信息，具体请参考官网进行签名处理 https://docs.open.alipay.com/204/105465/
                    Post($http, DreamConfig.alipayUrl, { subject: subject, totalAmount: amount }, function (payInfo) {
                        // 第二步：调用支付插件            
                        cordova.plugins.alipay.payment(payInfo, function success(e) {
                            $state.go('success', { obj: { header: "购买成功", title: title, details: "您已完成本次交易", amount: amount } });
                        }, function error(e) {
                            DeviceEvent.Toast("支付失败");
                        });
                    });
                };
                $('.tab-box .col-md-6').click(function () {
                    $(this).find('.item-box').addClass('active').parents('.col-md-6').siblings().find('.item-box').removeClass('active');
                    $('.tab-conter .item-box').eq($(this).index()).addClass('active').siblings().removeClass('active');
                });
            })
            .controller('ProfitsController', function ($scope, $state, $http, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.profits = {};
                Get($http, DreamConfig.profitUrl.concat("?userId=" + ls.getObject("userInfo").UserId), function (profits) {
                    $scope.profits = profits;
                });
            })
            .controller('WithdrawController', function ($scope, $state, $http, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.withdrawApply = {};
                Get($http, DreamConfig.profitUrl + "QueryWithdraw?userId=" + ls.getObject("userInfo").UserId, function (withdrawApply) {
                    $scope.withdrawApply = withdrawApply;
                });
            })
            .controller('SettingController', function ($scope, $state, $http, sc, ls) {
                sc.ValidateLogin();
                $scope.logOut = function () {
                    sc.logOut();
                };
                $scope.back = function () {
                    $state.go('my');
                };

                $scope.userInfo = ls.getObject("userInfo");
                $scope.updateName = function () {
                    $state.go('update', { obj: { title: "设置你的昵称", type: "name", value: $scope.userInfo.Name } });
                };
                $scope.updateAlipay = function () {
                    $state.go('update', { obj: { title: "设置支付宝账号", type: "alipay", value: $scope.userInfo.AliPay } });
                };
                $scope.updateAlipayName = function () {
                    $state.go('update', { obj: { title: "设置支付宝姓名", type: "alipayName", value: $scope.userInfo.AliPayName } });
                };
                $scope.updatePhone = function () {
                    $state.go('update', { obj: { title: "设置手机号码", type: "phone", value: $scope.userInfo.Phone } });
                };
                $scope.share = function () {
                    Wechat.share({
                        message: {
                            title: "点击下载惠及万家APP，立刻享受淘宝购物高额报销",
                            description: "点击下载惠及万家APP，立刻享受淘宝购物高额报销.",
                            thumb: "www/images/icon-76@2x.png",
                            mediaTagName: "HJWJ-TAG-001",
                            messageExt: "点击下载惠及万家APP，立刻享受淘宝购物高额报销",
                            messageAction: "<action>dotalist</action>",
                            media: {
                                type: Wechat.Type.WEBPAGE,
                                webpageUrl: "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state=" + ls.getObject("userInfo").UserId + "&connect_redirect=1#wechat_redirect"
                            }
                        },
                        scene: Wechat.Scene.TIMELINE   // share to Timeline
                    }, function () {
                        DeviceEvent.Toast("分享成功");
                    }, function (reason) {
                        DeviceEvent.Toast("分享失败");
                    });
                };
            })
            .controller('QrcodeController', function ($scope, $state, sc, ls) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                $scope.userAvatar = ls.getObject("userInfo").AvatarUrl;
                //二维码生成
                $("#qrCode").empty();
                $("#qrCode").qrcode({
                    render: "canvas",
                    width: window.innerWidth - 150,
                    height: window.innerHeight / 3,
                    text: "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state=" + ls.getObject("userInfo").UserId + "&connect_redirect=1#wechat_redirect"
                });
            })
            .controller('SuccessController', function ($scope, $state, sc, $stateParams) {
                $scope.back = function () {
                    $state.go(curPage);
                };
                $scope.successInfo = $stateParams.obj;
                var _interval = setInterval(function () {
                    if (parseInt($("#time").text()) > 0) {
                        $("#time").text(parseInt($("#time").text()) - 1);
                    }
                    else {
                        clearInterval(_interval);
                        $state.go(curPage);
                    }
                }, 1000);
            })
            .controller('HomeController', function ($scope, $state, $http, sc, $rootScope, ls) {
                curPage = "home";
                sc.ValidateLogin();

                $scope.ClickLog = function (itemId, url, imgUrl) {
                    Post($http, DreamConfig.clickLog, { UserId: ls.getObject("userInfo").UserId, ItemId: itemId, Url: url, ImgUrl: imgUrl }, function (data) {
                    });
                };
                $scope.ToSearch = function () {
                    $state.go("search");
                };

                $scope.ToCategory = function (type, pageTitle) {
                    $state.go('category', { type: type, pageTitle: pageTitle });
                };

                $scope.goodItemList = {}; //好货优选
                var gParams = { PageSize: 5, MaterialId: 3786 };//品牌券  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, gParams, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.goodItemList = ret;
                });

                $scope.hotSalesItemList = {}; //热销榜单
                var hParams = { PageSize: 30, MaterialId: 4094 };//特惠  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, hParams, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.hotSalesItemList = ret;
                });

                $scope.recommentItemList = {}; //为你推荐
                var rParams = { PageSize: 100, MaterialId: 4092 };//有好货  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, rParams, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.recommentItemList = ret;
                });

            })
            .controller('FooterController', function ($scope, $state, ls) {
                $(".item-box").removeClass("active");
                switch (curPage) {
                    case "home":
                        $(".item-box.home").addClass("active");
                        break;
                    case "rebate":
                        $(".item-box.rebate").addClass("active");
                        break;
                    case "my":
                        $(".item-box.my").addClass("active");
                        break;
                    case "recommend":
                        $(".item-box.recommend").addClass("active");
                        break;
                }
            })
            .controller('LoginController', function ($scope, ls, sc, $state) {
                if (!ls.get('guideIsChecked')) $state.go('guide');
                sc.checkTicketStillActive();
                $scope.login = function () {
                    sc.Login();
                };
            })
            .controller('CategoryController', function ($scope, sc, ls, $state, $http, $stateParams) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('home');
                };
                $scope.itemList = {};
                $scope.ClickLog = function (itemId, url, imgUrl) {
                    Post($http, DreamConfig.clickLog, { UserId: ls.getObject("userInfo").UserId, ItemId: itemId, Url: url, ImgUrl: imgUrl }, function (data) {
                    });
                };
                $scope.pageTitle = $stateParams.pageTitle;
                var params = { PageSize: 100, MaterialId: $stateParams.type };  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, params, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.itemList = ret;
                });
            })
            .controller('RebateController', function ($scope, sc, ls, $state, $http) {
                curPage = "rebate";
                sc.ValidateLogin();
                $scope.itemList = {};
                $scope.ClickLog = function (itemId, url, imgUrl) {
                    Post($http, DreamConfig.clickLog, { UserId: ls.getObject("userInfo").UserId, ItemId: itemId, Url: url, ImgUrl: imgUrl }, function (data) {
                    });
                };
                var params = { PageSize: 100, MaterialId: 13366 };//高佣金  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, params, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.itemList = ret;
                    console.log(ret);
                });
            })
            .controller('RecommendController', function ($scope, sc, ls, $state, $http) {
                curPage = "recommend";
                sc.ValidateLogin();
                $scope.ClickLog = function (itemId, url, imgUrl) {
                    Post($http, DreamConfig.clickLog, { UserId: ls.getObject("userInfo").UserId, ItemId: itemId, Url: url, ImgUrl: imgUrl }, function (data) {
                    });
                };
                $scope.itemList = {};
                var params = { PageSize: 100, MaterialId: 3756 };//好券直播  参考类型地址:https://tbk.bbs.taobao.com/detail.html?appId=45301&postId=8576096
                Post($http, DreamConfig.tbkOptimusGet, params, function (data) {
                    data = JSON.parse(data);
                    var ret = data.tbk_dg_optimus_material_response.result_list.map_data;
                    for (i = 0; i < ret.length; i++) {
                        if (ret[i].coupon_amount == null) ret[i].coupon_amount = 0;
                        else ret[i].coupon_amount = parseInt(ret[i].coupon_amount);
                        if (!!ret[i].coupon_share_url) ret[i].coupon_share_url = encodeURIComponent(ret[i].coupon_share_url);
                        else ret[i].coupon_share_url = encodeURIComponent(ret[i].url);
                    }
                    $scope.itemList = ret;
                    console.log(ret);
                });
            })
            .controller('OrderController', function ($scope, sc, ls, $state, $http) {
                sc.ValidateLogin();
                $scope.back = function () {
                    $state.go('my');
                };
                Get($http, DreamConfig.userOrders + "/?userId=" + ls.getObject("userInfo").UserId, function (userOrders) {
                    $scope.userOrders = userOrders;
                });
                $scope.share = function (title, img, url, price, state, code) {
                    Wechat.share({
                        message: {
                            title: "我通过这个APP购买淘宝商品获得了高额返利，点击下载APP",
                            description: "我通过这个APP购买淘宝商品获得了高额返利，点击下载APP",
                            thumb: "www/images/icon-76@2x.png",
                            mediaTagName: "HJWJ-TAG-001",
                            messageExt: "我通过这个APP购买淘宝商品获得了高额返利，点击下载APP",
                            messageAction: "<action>dotalist</action>",
                            media: {
                                type: Wechat.Type.WEBPAGE,
                               // webpageUrl: url
                                webpageUrl: "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state=" + ls.getObject("userInfo").UserId + "&connect_redirect=1#wechat_redirect"
                            }
                        },
                        scene: Wechat.Scene.TIMELINE   // share to Timeline
                    }, function () {
                        var status = 1;
                        if (state === 2) status = 0;
                        Post($http, DreamConfig.profitUrl + "add", { userid: ls.getObject("userInfo").UserId, Amount: price * DreamConfig.shareBackRate, Type: 2, Status: status, FromOrder: code,Remark:"来自订单分享收益"}, function (data) {
                            DeviceEvent.Toast("分享成功,订单完成之后您将多获得20%额外奖励");
                        });
                    }, function (reason) {
                        DeviceEvent.Toast("分享失败," + reason);
                    });
                };
            })
            .controller('MyController', function ($scope, $state, sc, ls,$http) {
                curPage = "my";
                sc.ValidateLogin();
                $scope.userInfo = ls.getObject("userInfo");
                $scope.CopyYQM = function () {
                    CopyTextToClipboard(ls.getObject("userInfo").UserId);
                }
                Get($http, DreamConfig.userInfoUrl + "getbyid?userId=" + $scope.userInfo.UserId, function (userInfo) {
                    $scope.userInfo = userInfo;
                });
                Get($http, DreamConfig.userInfoUrl.concat("GetTeamById?userId=" + ls.getObject("userInfo").UserId), function (team) {
                    $scope.teamInfo = team;
                });
                $scope.updateAlipay = function () {
                    $state.go('update', { obj: { title: "设置支付宝账号", type: "alipay", value: $scope.userInfo.AliPay } });
                };
                $scope.remainAmout = 0;
                Get($http, DreamConfig.profitUrl.concat("GetRemainAmount?userId=" + $scope.userInfo.UserId), function (totalAmount) {
                    $scope.remainAmout = totalAmount;
                });
                $scope.AddParent = function () {
                    DeviceEvent.Prompt("", function (results) {
                        if (results.buttonIndex == 1) {
                            // value:results.input1
                            if (!results.input1) {
                                DeviceEvent.Toast("邀请码不能为空!");
                                return;
                            }
                            var userInfo = { UserId: ls.getObject("userInfo").UserId, PId: results.input1};
                            Post($http, DreamConfig.userInfoUrl, userInfo, function (user) {
                                if (!user) DeviceEvent.Toast("邀请码不存在!");
                                else {
                                    $scope.userInfo.PId = user.PId;
                                    ls.setObject("userInfo", $scope.userInfo);
                                    DeviceEvent.Toast("邀请码填写成功!");
                                }
                            });
                        }
                    }, "请输入邀请码", ['提交', '取消'], "");
                };

                $scope.withdraw = function () {
                    if ($scope.userInfo.AliPay === null || $scope.userInfo.AliPayName === null || $scope.userInfo.Phone===null) {
                        DeviceEvent.Confirm("您的支付宝信息尚未完善",
                            function (buttonIndex) {
                                if (buttonIndex === 1) {
                                    $state.go('bindAlipay', { alipay: $scope.userInfo.AliPay, alipayName: $scope.userInfo.AliPayName, phone: $scope.userInfo.Phone});
                                }
                            }, "请绑定支付宝", ['去完善', '取消']);
                    }
                    else if ($scope.remainAmout < 1) {
                        DeviceEvent.Toast("余额必须大于1元才能提现");
                    }
                    else {
                        Post($http, DreamConfig.profitUrl.concat("WithdrawApply/?userId=" + $scope.userInfo.UserId), null, function (data) {
                            DeviceEvent.Toast("提现成功，二个工作日内到账。");
                            $scope.remainAmout = 0;
                        });
                    }
                };

                $scope.share = function () {
                    Wechat.share({
                        message: {
                            title: "点击下载惠及万家APP，立刻享受淘宝购物高额报销",
                            description: "下载惠及万家APP，立刻享受淘宝购物高额报销",
                            thumb: "www/images/icon-76@2x.png",
                            mediaTagName: "HJWJ-TAG-001",
                            messageExt: "点击下载惠及万家APP，立刻享受淘宝购物高额报销",
                            messageAction: "<action>dotalist</action>",
                            media: {
                                type: Wechat.Type.WEBPAGE,
                                webpageUrl: "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state=" + ls.getObject("userInfo").UserId + "&connect_redirect=1#wechat_redirect"
                            }
                        },
                        scene: Wechat.Scene.TIMELINE   // share to Timeline
                    }, function () {
                        DeviceEvent.Toast("分享成功");
                    }, function (reason) {
                        DeviceEvent.Toast("分享失败");
                    });
                };

                $scope.toOrderPage = function () {
                    $state.go('order');
                };
                $scope.toSettingPage = function () {
                    $state.go('setting');
                };
                $scope.toTeamPage = function () {
                    $state.go('team');
                };
                $scope.toProfitPage = function () {
                    $state.go('profits');
                }; 
                $scope.toQrCodePage = function () {
                    $state.go('qrcode');
                };                                        
            });
    }
};

