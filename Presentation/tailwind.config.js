/** @type {import("tailwindcss").Config} */
module.exports = {
  content: [
    "./Pages/**/*.cshtml",
    "./Views/**/*.cshtml"
  ],
  theme: {

    extend: {
      backgroundImage : {
        "account" : "url('/images/account/_Background.jpg')"
      },
      backgroundColor: {
        "nav": "#f9f9f9"
      },
      minWidth: {
        "logo": "5.625rem"
      },
      textColor: {
        "danger": "rgba(220, 53, 69, 1)"
      },
      borderWidth: {
        "1": "1px"
      },
      borderColor: {
        "e0": "#e0e0e0"
      }
    }
  },
  plugins: []
  
};

