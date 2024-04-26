<template>
  <div>
    <header>
      <NavBar />
    </header>
    <NuxtPage />
    <footer>
      <Footer />
    </footer>
  </div>
</template>

<style>
@font-face {
  font-family: "sans-serif";
  src: url("Roboto/Roboto-Regular.ttf");
}
html {
  font-family: 'Roboto', sans-serif;
  font-size: 20px;
}
footer {
  font-size: 16px;
  padding: 5%;
  background-color: rgb(227, 227, 227);
  margin: 0px -1%;
  margin-bottom: -1%;
}
</style>