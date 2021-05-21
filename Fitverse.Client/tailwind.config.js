module.exports = {
  purge: [],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      backgroundImage: theme => ({
        'login-page': "url('./img/login-bg.svg')"
      }),
      colors: {
        'fitverseGradientStart': '#43DCF7',
        'fitverseGradientEnd': '#9C5FEF',
        'fitverseLightGray': '#F1F1F1',
        'fitverseMidGray': '#D8D8D8',
        'fitverseCyan': '#44DBF7',
        'fitversePaleBlue': '#6AA5F3',
        'fitverseLightPurple': '#9B61F0',
        'fitverseDarkPurple': '#5905D4',
        'fitverseBackground': '#FAFAFA',
        'fitverseGrayText': '#f3f3f3',
        'fitverseMint': '#24E7B9'
      }
    },
  },
  variants: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}
