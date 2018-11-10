$(window).scroll(function() {
  if ($(this).scrollTop() > 0) {
    $('.sub-menu').slideUp();
    // $(".profhi").css("display","none")
   
  } else {
    $('.sub-menu').slideDown();
    // $(".profhi").css("display","block")
  }
});
