/** @type {import('tailwindcss').Config} */


const colors = require('tailwindcss/colors');


module.exports = {
  content: ['./src/*.{html,ts}', './src/**/*.{html,ts}'],
  theme: {
    extend: {},
    colors: {
      ...colors
    }
  },
  plugins: [
    require('@tailwindcss/forms')
  ],
}
