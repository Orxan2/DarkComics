window.onload = () => {



    function loader() {
        document.querySelector('.loader-container').classList.add('active');
    }

    function fadeOut() {
        setTimeout(loader, 4000);
    }

    $('.owl-carousel').owlCarousel({
        items: 4,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 2000,
        autoplayHoverPause: true,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            480: {
                items: 2,
                nav: false,
                margin: 5
            },
            768: {
                items: 3,
                nav: true,
            },
            1000: {
                items: 5,
                nav: true,
            }
        }
    });


    $('.play').on('click', function () {
        owl.trigger('play.owl.autoplay', [1000])
    })
    $('.stop').on('click', function () {
        owl.trigger('stop.owl.autoplay')
    })
    $(".toy-card").each(function (indexInArray, valueOfElement) {
        $(valueOfElement).on('mouseenter', function () {
            console.log(valueOfElement.children[0].children[1]);
            $(valueOfElement.children[0].children[1]).slideToggle();
        });
        $(valueOfElement).on('mouseleave', function () {
            console.log(valueOfElement.children[0].children[1]);
            $(valueOfElement.children[0].children[1]).slideToggle();
        });
    });


    var swiper = new Swiper(".books-slider", {
        loop: true,
        centeredSlides: true,
        autoplay: {
            delay: 9500,
            disableOnInteraction: false,
        },
        breakpoints: {
            0: {
                slidesPerView: 1,

            },
            768: {
                slidesPerView: 2,
            },
            //   1024: {
            //     slidesPerView: 3,
            //   },
        },
    });

    let loginForm = document.querySelector('.login-form-container');

    //document.querySelector('#login-btn').onclick = () => {
    //    loginForm.classList.toggle('active');
    //}
    $('#login-btn').onclick = () => {
        loginForm.classList.toggle('active');
    }

    $('#close-login-btn').onclick = () => {
        loginForm.classList.remove('active');
    }


    var swiper = new Swiper(".featured-slider", {
        spaceBetween: 10,
        loop: true,
        centeredSlides: true,
        autoplay: {
            delay: 9500,
            disableOnInteraction: false,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        breakpoints: {
            0: {
                slidesPerView: 1,
            },
            768: {
                slidesPerView: 2,
            },
            1024: {
                slidesPerView: 3,
            }
        },
    });

    //power skill Ratings
    var offset = $('#skill').offset();
    var innerheight = $('#skill').innerHeight();



    $(".percent #percent").each(function (indexInArray, valueOfElement) {

        let percent = $(valueOfElement).attr('data-degree');
        let color = $(valueOfElement).attr('data-color');
        $(valueOfElement).css('stroke-dashoffset', `${(440 - (440 * percent) / 10)}`);
        $(valueOfElement).css('stroke', color);


    });

    window.onscroll = () => {

        $(".percent #percent").each(function (indexInArray, valueOfElement) {
            if (window.scrollY >= (offset.top - innerheight)) {
                $(valueOfElement).css('animation-play-state', 'running');
            }
        });
    }

    let skip = 3;
    let take = 3;
    $('#loadMore').on('click', function () {
        Load(skip, take);
        skip += take;
        let count = $('#loadMore').attr('data-count');
        if (skip >= count) {
            $('#loadMore').css('display', 'none');
        }
    });

    $('#search .form-control').on('keyup', () => {
        //let word = document.querySelector('#search .form-control').valueOfElement;
        let word = $('#search .form-control').val();
        console.log(word);
        $('#addHere .col-12').each(function (index, element) {
            //console.log(element)
            $(element).css("display", "none");
        });
        if (word == "") {
            Load(0, 3);
        }
        $.ajax({
            url: `/Comic/Search?search=${word}`,
            type: "Get",
            success: function (response) {
                $('#addHere').append(response);
            }
        })
    });
    function Load(skip, take) {
        //console.log('okay');
        $.ajax({
            url: `/Comic/LoadMore?skip=${skip}&take=${take}`,
            type: "Get",
            success: function (response) {
                $('#addHere').append(response);
            }
        })
    }

    // Basket
    $('.basket').each(function (basketIndex, basketElement) {

        $(basketElement).on('click', function () {
            //console.log('okay');
            let id = $(basketElement).attr('data-id');
            //console.log(id);

            $('#basket-items .row').each(function (index, element) {
                $(element).css("display", "none");
            });

            $.ajax({
                url: `/Comic/AddBasket?id=${id}`,
                type: "Get",
                success: function (response) {
                    console.log(response);
                    $('#basket-items').append(response);
                }
            });

        });

    });
    //Loader
    fadeOut();

};
// It works after ajax complete
$(document).ajaxComplete(function () {
    //Delete Product
    $('.remove').each(function (basketIndex, basketElement) {      
        $(basketElement).on('click', function () {

            let id = $(basketElement).parent().parent().attr('data-id');
            $('#basket-items .row').each(function (index, element) {
                $(element).css("display", "none");
            });

            $.ajax({
                url: `/Comic/DeleteProduct?id=${id}`,
                type: "Get",
                success: function (response) {
                    $('#basket-items').append(response);
                }
            })
        });

    });
    //Decrease Product

    $('.minus').each(function (basketIndex, basketElement) {
      
        $(basketElement).on('click', function () {
            let id = $(basketElement).parent().parent().parent().attr('data-id');

            $('#basket-items .row').each(function (index, element) {
                $(element).css("display", "none");
            });

            $.ajax({
                url: `/Comic/DecreaseProduct?id=${id}`,
                type: "Get",
                success: function (response) {
                    $('#basket-items').append(response);
                }
            })
        });

    });

    //Increase Product
    $('.plus').each(function (basketIndex, basketElement) {
      $(basketElement).on('click', function () {
            let id = $(basketElement).parent().parent().parent().attr('data-id');

            $('#basket-items .row').each(function (index, element) {
                $(element).css("display", "none");
            });

            $.ajax({
                url: `/Comic/IncreaseProduct?id=${id}`,
                type: "Get",
                success: function (response) {
                    $('#basket-items').append(response);
                }
            })
        });

    });
});
