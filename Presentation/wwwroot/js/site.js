"use strict";

//Models


//EventHandlers


 function navContentClick(e) {
  $(".nav__item").removeClass("is--activated");
  const items = $(e.target.closest(".nav__item"));
  if (!items) return;
  items.addClass("is--activated");
}
// Controllers
$(".nav__content").click(navContentClick);
