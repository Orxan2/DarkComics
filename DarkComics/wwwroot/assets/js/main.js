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
    let skip = 3;
    let take = 3;
    $('#loadMore').on('click', function () {
        Load(skip, take);
        skip += take;
        let count = $('#loadMore').attr('data-count');
        if (skip >= count) {
            $('#loadMore').css('display','none');
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

    
});