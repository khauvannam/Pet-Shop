"use strict";
$(".nav__content").click((e) => {
  $(".nav__item").removeClass("is--actived");
  const items = $(e.target.closest(".nav__item"));
  if (!items) return;
  items.addClass("is--actived");
});