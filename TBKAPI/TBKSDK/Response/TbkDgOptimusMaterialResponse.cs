using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Top.Api.Response
{
    /// <summary>
    /// TbkDgOptimusMaterialResponse.
    /// </summary>
    public class TbkDgOptimusMaterialResponse : TopResponse
    {
        /// <summary>
        /// 推荐信息-是否抄底
        /// </summary>
        [XmlElement("is_default")]
        public string IsDefault { get; set; }

        /// <summary>
        /// resultList
        /// </summary>
        [XmlArray("result_list")]
        [XmlArrayItem("map_data")]
        public List<MapDataDomain> ResultList { get; set; }

	/// <summary>
/// WordMapDataDomain Data Structure.
/// </summary>
[Serializable]

public class WordMapDataDomain : TopObject
{
	        /// <summary>
	        /// 链接-商品相关关联词落地页地址
	        /// </summary>
	        [XmlElement("url")]
	        public string Url { get; set; }
	
	        /// <summary>
	        /// 商品相关的关联词
	        /// </summary>
	        [XmlElement("word")]
	        public string Word { get; set; }
}

	/// <summary>
/// MapDataDomain Data Structure.
/// </summary>
[Serializable]

public class MapDataDomain : TopObject
{
	        /// <summary>
	        /// 商品信息-叶子类目id
	        /// </summary>
	        [XmlElement("category_id")]
	        public long CategoryId { get; set; }
	
	        /// <summary>
	        /// 商品信息-叶子类目名称
	        /// </summary>
	        [XmlElement("category_name")]
	        public string CategoryName { get; set; }
	
	        /// <summary>
	        /// 链接-宝贝推广链接
	        /// </summary>
	        [XmlElement("click_url")]
	        public string ClickUrl { get; set; }
	
	        /// <summary>
	        /// 商品信息-佣金比率(%)
	        /// </summary>
	        [XmlElement("commission_rate")]
	        public string CommissionRate { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券面额。如：满299元减20元
	        /// </summary>
	        [XmlElement("coupon_amount")]
	        public long CouponAmount { get; set; }
	
	        /// <summary>
	        /// 链接-宝贝+券二合一页面链接(该字段废弃，请勿再用)
	        /// </summary>
	        [XmlElement("coupon_click_url")]
	        public string CouponClickUrl { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券结束时间
	        /// </summary>
	        [XmlElement("coupon_end_time")]
	        public string CouponEndTime { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券满减信息
	        /// </summary>
	        [XmlElement("coupon_info")]
	        public string CouponInfo { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券剩余量
	        /// </summary>
	        [XmlElement("coupon_remain_count")]
	        public long CouponRemainCount { get; set; }
	
	        /// <summary>
	        /// 链接-宝贝+券二合一页面链接
	        /// </summary>
	        [XmlElement("coupon_share_url")]
	        public string CouponShareUrl { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券起用门槛，满X元可用。如：满299元减20元
	        /// </summary>
	        [XmlElement("coupon_start_fee")]
	        public string CouponStartFee { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券开始时间
	        /// </summary>
	        [XmlElement("coupon_start_time")]
	        public string CouponStartTime { get; set; }
	
	        /// <summary>
	        /// 优惠券信息-优惠券总量
	        /// </summary>
	        [XmlElement("coupon_total_count")]
	        public long CouponTotalCount { get; set; }
	
	        /// <summary>
	        /// 商品信息-宝贝描述（推荐理由,不一定有）
	        /// </summary>
	        [XmlElement("item_description")]
	        public string ItemDescription { get; set; }
	
	        /// <summary>
	        /// 商品信息-宝贝id
	        /// </summary>
	        [XmlElement("item_id")]
	        public long ItemId { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团几人团
	        /// </summary>
	        [XmlElement("jdd_num")]
	        public long JddNum { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团拼成价，单位元
	        /// </summary>
	        [XmlElement("jdd_price")]
	        public string JddPrice { get; set; }
	
	        /// <summary>
	        /// 聚划算信息-聚淘结束时间
	        /// </summary>
	        [XmlElement("ju_online_end_time")]
	        public string JuOnlineEndTime { get; set; }
	
	        /// <summary>
	        /// 聚划算信息-聚淘开始时间
	        /// </summary>
	        [XmlElement("ju_online_start_time")]
	        public string JuOnlineStartTime { get; set; }
	
	        /// <summary>
	        /// 商品信息-一级类目ID
	        /// </summary>
	        [XmlElement("level_one_category_id")]
	        public long LevelOneCategoryId { get; set; }
	
	        /// <summary>
	        /// 商品信息-一级类目名称
	        /// </summary>
	        [XmlElement("level_one_category_name")]
	        public string LevelOneCategoryName { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-折扣条件，价格百分数存储，件数按数量存储。可以有多个折扣条件，与折扣字段对应，','分割
	        /// </summary>
	        [XmlElement("maochao_play_conditions")]
	        public string MaochaoPlayConditions { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-玩法类型，2:折扣(满n件折扣),5:减钱(满n元减m元)
	        /// </summary>
	        [XmlElement("maochao_play_discount_type")]
	        public string MaochaoPlayDiscountType { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-折扣，折扣按照百分数存储，其余按照单位分存储。可以有多个折扣，','分割
	        /// </summary>
	        [XmlElement("maochao_play_discounts")]
	        public string MaochaoPlayDiscounts { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-活动结束时间，精确到毫秒
	        /// </summary>
	        [XmlElement("maochao_play_end_time")]
	        public string MaochaoPlayEndTime { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-当前是否包邮，1:是，0:否
	        /// </summary>
	        [XmlElement("maochao_play_free_post_fee")]
	        public string MaochaoPlayFreePostFee { get; set; }
	
	        /// <summary>
	        /// 猫超玩法信息-活动开始时间，精确到毫秒
	        /// </summary>
	        [XmlElement("maochao_play_start_time")]
	        public string MaochaoPlayStartTime { get; set; }
	
	        /// <summary>
	        /// 多件券单品件数
	        /// </summary>
	        [XmlElement("multi_coupon_item_count")]
	        public string MultiCouponItemCount { get; set; }
	
	        /// <summary>
	        /// 多件券优惠比例
	        /// </summary>
	        [XmlElement("multi_coupon_zk_rate")]
	        public string MultiCouponZkRate { get; set; }
	
	        /// <summary>
	        /// 商品信息-新人价
	        /// </summary>
	        [XmlElement("new_user_price")]
	        public string NewUserPrice { get; set; }
	
	        /// <summary>
	        /// 店铺信息-卖家昵称
	        /// </summary>
	        [XmlElement("nick")]
	        public string Nick { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团结束时间
	        /// </summary>
	        [XmlElement("oetime")]
	        public string Oetime { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团一人价（原价)，单位元
	        /// </summary>
	        [XmlElement("orig_price")]
	        public string OrigPrice { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团开始时间
	        /// </summary>
	        [XmlElement("ostime")]
	        public string Ostime { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品主图
	        /// </summary>
	        [XmlElement("pict_url")]
	        public string PictUrl { get; set; }
	
	        /// <summary>
	        /// 多件券件单价
	        /// </summary>
	        [XmlElement("price_after_multi_coupon")]
	        public string PriceAfterMultiCoupon { get; set; }
	
	        /// <summary>
	        /// 商品信息-一口价
	        /// </summary>
	        [XmlElement("reserve_price")]
	        public string ReservePrice { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团已售数量
	        /// </summary>
	        [XmlElement("sell_num")]
	        public long SellNum { get; set; }
	
	        /// <summary>
	        /// 店铺信息-卖家id
	        /// </summary>
	        [XmlElement("seller_id")]
	        public long SellerId { get; set; }
	
	        /// <summary>
	        /// 店铺信息-店铺名称
	        /// </summary>
	        [XmlElement("shop_title")]
	        public string ShopTitle { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品短标题
	        /// </summary>
	        [XmlElement("short_title")]
	        public string ShortTitle { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品小图列表
	        /// </summary>
	        [XmlArray("small_images")]
	        [XmlArrayItem("string")]
	        public List<string> SmallImages { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团剩余库存
	        /// </summary>
	        [XmlElement("stock")]
	        public long Stock { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品标题
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
	
	        /// <summary>
	        /// 营销-天猫营销玩法
	        /// </summary>
	        [XmlElement("tmall_play_activity_info")]
	        public string TmallPlayActivityInfo { get; set; }
	
	        /// <summary>
	        /// 拼团专用-拼团库存数量
	        /// </summary>
	        [XmlElement("total_stock")]
	        public long TotalStock { get; set; }
	
	        /// <summary>
	        /// 店铺信息-卖家类型，0表示集市，1表示商城
	        /// </summary>
	        [XmlElement("user_type")]
	        public long UserType { get; set; }
	
	        /// <summary>
	        /// 商品信息-预售数量
	        /// </summary>
	        [XmlElement("uv_sum_pre_sale")]
	        public long UvSumPreSale { get; set; }
	
	        /// <summary>
	        /// 商品信息-30天销量
	        /// </summary>
	        [XmlElement("volume")]
	        public long Volume { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品白底图
	        /// </summary>
	        [XmlElement("white_image")]
	        public string WhiteImage { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品关联词
	        /// </summary>
	        [XmlArray("word_list")]
	        [XmlArrayItem("word_map_data")]
	        public List<WordMapDataDomain> WordList { get; set; }
	
	        /// <summary>
	        /// 物料块id(测试中请勿使用)
	        /// </summary>
	        [XmlElement("x_id")]
	        public string XId { get; set; }
	
	        /// <summary>
	        /// 商品信息-商品折扣价格
	        /// </summary>
	        [XmlElement("zk_final_price")]
	        public string ZkFinalPrice { get; set; }
}

    }
}
