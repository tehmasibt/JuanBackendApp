﻿$(document).ready(function () {
	//AddBasket
	$(".addToBasket").click(function (ev) {
		ev.preventDefault();
		var id = $(this).data("id");
		console.log(id);
		axios.get("/basket/addBasket?id="+id)
			.then(function (datas) {
				console.log(datas)
			})
	})


	
	//Modal
    $(".productModal").click(function (ev) {
        ev.preventDefault();
        let url=$(this).attr("href");
        axios.get(url)
            .then(function (response) {
                // handle success
                $(".product-details-inner").html(response.data)
				$('.product-large-slider').slick({
					fade: true,
					arrows: false,
					asNavFor: '.pro-nav'
				});
				// product details slider nav active
				$('.pro-nav').slick({
					slidesToShow: 4,
					asNavFor: '.product-large-slider',
					arrows: false,
					focusOnSelect: true
				});
				$('.pro-qty').prepend('<span class="dec qtybtn">-</span>');
				$('.pro-qty').append('<span class="inc qtybtn">+</span>');
				$('.qtybtn').on('click', function () {
					var $button = $(this);
					var oldValue = $button.parent().find('input').val();
					if ($button.hasClass('inc')) {
						var newVal = parseFloat(oldValue) + 1;
					} else {
						// Don't allow decrementing below zero
						if (oldValue > 0) {
							var newVal = parseFloat(oldValue) - 1;
						} else {
							newVal = 0;
						}
					}
					$button.parent().find('input').val(newVal);
				});
            })
	})


	//Search
	$(document).on("keyup", "#searchInput", function () {
		$("#searchList").html("")
		let searchValue = $(this).val();
		axios.get("/product/SearchProduct?search="+searchValue)
			.then(function (datas) {
				$("#searchList").html(datas.data)
			})
	})
})




