/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Pages/**/*.cshtml',
    './Views/**/*.cshtml'
  ],
  theme: {
    extend: {
      backgroundColor: {
        "nav": "#f9f9f9"
      },
      minWidth: {
        "logo": "5.625rem"
      },
      textColor: {
      
      },
      borderWidth: {
        "1" : "1px"
      },
      borderColor: {
        "e0" : "#e0e0e0"
      }
    },
  },
  plugins: []
  ,
}

