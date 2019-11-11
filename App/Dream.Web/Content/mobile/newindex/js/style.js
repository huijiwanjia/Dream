var tabsSwiper = new Swiper('.swiper-container',{
	speed:500,
	onSlideChangeStart: function(){
		$(".tabs .active").removeClass('active');
		$(".tabs a").eq(tabsSwiper.activeIndex).addClass('active');
	var Htabbox = $('.swiper-wrapper').find('ul').eq(tabsSwiper.activeIndex).outerHeight()+80;
    $('.swiper-wrapper').css('height',Htabbox);
	}
}); 
	var Htabbox = $('.swiper-wrapper').find('ul').outerHeight()+80;
    $('.swiper-wrapper').css('height',Htabbox);
$(".tabs a").on('touchstart mousedown',function(e){
	e.preventDefault()
	$(".tabs .active").removeClass('active');
	$(this).addClass('active');
	tabsSwiper.swipeTo($(this).index()); 
	var Htabbox = $('.swiper-wrapper').find('ul').eq($(this).index()).outerHeight()+80;
    $('.swiper-wrapper').css('height',Htabbox);
});

$(".tabs a").click(function(e){ 
	e.preventDefault();  
});  


$(".swiper-slide").find('button').click(function(){ 
	if($(this).html() == '查看所有待审核订单'){ 
		$(this).prev('ul').addClass('active');	
		$(this).html('窗口最小化'); 
	}else if($(this).html() == '窗口最小化'){
		$(this).prev('ul').removeClass('active');	
		$(this).html('查看所有待审核订单'); 
	}
	var Htabul = $(this).prev('ul').outerHeight() + 80;
	// console.log(Htabul);
	$('.swiper-wrapper').css('height',Htabul);
})