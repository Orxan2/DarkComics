$(document).ready(function () {
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

    document.querySelector('#login-btn').onclick = () => {
        loginForm.classList.toggle('active');
    }

    document.querySelector('#close-login-btn').onclick = () => {
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

    window.onload = () => {
        fadeOut();
    }

    function loader() {
        document.querySelector('.loader-container').classList.add('active');
    }

    function fadeOut() {
        setTimeout(loader, 4000);
    }
});

