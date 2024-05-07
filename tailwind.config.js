const animate = require("tailwindcss-animate")

/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: ["class"],
  content: [
    './pages/**/*.{ts,tsx,vue}',
    './components/**/*.{ts,tsx,vue}',
    './app/**/*.{ts,tsx,vue}',
    './src/**/*.{ts,tsx,vue}',
	],
  prefix: "",
  theme: {
    container: {
      center: true,
      padding: "2rem",
      screens: {
        "2xl": "1400px",
      },
    },
    extend: {
      keyframes: {
        "accordion-down": {
          from: { height: 0 },
          to: { height: "var(--radix-accordion-content-height)" },
        },
        "accordion-up": {
          from: { height: "var(--radix-accordion-content-height)" },
          to: { height: 0 },
        },
      },
      animation: {
        "accordion-down": "accordion-down 0.2s ease-out",
        "accordion-up": "accordion-up 0.2s ease-out",
      },
      colors: {
        "lime-green":{ 
          100: "#a5c05b", 
          200: "#65ae6c", 
          300: "#48a366", 
          400: "#2d967a", 
        },
        "red": "#fe6c5f",
        "red-hover": "#f73b3b",
        "cream-white": "#eee8d9",
        "cold-white": "#f8fff8",
        "slate-gray": "#a9ad9b",
        "soft-gray": "#dddede",
        //"blue-gray": "#7BA4A8",
        "blue-gray": "#94b0b3",
        "dark-blue": "#2f4858"
      }
    },
  },
  plugins: [animate],
}