$('.slider-for').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: true,
    fade: true,
    asNavFor: '.slider-nav',
    swipeToSlide: true,
    touchThreshold: 5000
});
$('.slider-nav').slick({
    slidesToShow: 7,
    slidesToScroll: 1,
    asNavFor: '.slider-for',
    dots: false,
    arrows: false,
    centerMode: true,
    focusOnSelect: true,
    touchThreshold: 5000,
    swipeToSlide: true,
    responsive: [
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 3
            }
        }
    ]
});