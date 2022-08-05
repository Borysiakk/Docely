/** @type {import('tailwindcss').Config} */

const colors = require('tailwindcss/colors')

module.exports = {
  content: ['./src/*.html', './src/**/*.{html, ts}'],
  theme: {
    extend: {},
    colors: {
      'indigo': colors.indigo,
      'gray': colors.gray,
    }
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}
