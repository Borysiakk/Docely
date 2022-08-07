/** @type {import('tailwindcss').Config} */


const colors = require('tailwindcss/colors');


module.exports = {
  content: ['./src/*.{html,ts}', './src/**/*.{html,ts}'],
  theme: {
    extend: {},
    colors: {
      'indigo': colors.indigo
    }
  },
  plugins: [
    require('@tailwindcss/forms')
  ],
}
