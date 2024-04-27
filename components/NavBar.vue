<template>

<div class="flex h-[60px] w-screen border text-center">
    <ul class="basis-1/4 flex flex-row items-center justify-around text-nowrap">
        <li>O нас</li>
        <li>Продавцам</li>
        <li>Покупателям</li>
    </ul>
    <div class="basis-1/2 flex flex-row-reverse items-center text-center space-x-10">
      <div class="basis-1/4 min-w-40 ml-3">
        <button class=" min-w-36 h-8 bg-blueish">Разместить</button>
      </div>
      <ul class='basis-1/3 flex flex-row justify-between text-nowrap space-x-0.5'>
        <li>Избранное</li>
        <li>Мои объявления</li>
      </ul>
    </div>
    <div class="basis-1/4 flex flex-row items-center justify-around text-nowrap">
        <p>Вход и регистрация</p>
    </div>
</div>
<div class="navbar" id="main">
    <div class="w-72 ml-6">
        <a href="index.html">
            <picture>
                <source media="(min-width: 1020px)" srcset="\img\guitar_logo.png">
                <img src="/img/guitar_logo_small.png">
            </picture>
        </a>
    </div>
</div>        
    
</template>

<style scoped>
.logo {
  padding: 0.1%;
  padding-left: 2vw;
  padding-right: 3vw;
  margin-right: 2vw;
  text-align: center;
  width: 17%;
  border-right: 1px solid #232122;
}
  
@media (max-width: 820px) {
  .logo {
    width: 6%;
  }
}

.navbar {
    display: flex;
    width: 100%;
    height: 120px;
    align-items : center;
    border-bottom: 1px solid #DDDEDE;
}

.searchbar {
  display: flex;
  width: 45vw;
  height: 70%;
  border: 1px solid #232122;
  border-radius: 5px;
  /* margin-left: 5%; */
  /* up to 1085 */
  justify-content: left;
  margin-right: 2vw;
  padding-left: 1px;
  padding-right: 7px;
  padding-top: 1px;
  padding-bottom: 1px;
}
  
.searchbar input {
  margin-left: 5px;
  width: 93%; 
  border: none;
  outline: none;
  color: #525c5c;
  border-radius: 5px;
}

.topmenu {
  display: flex;
  align-items: center;
  width: 100%;
  height: 60px;
  border-bottom: 1px solid #DDDEDE;
}

.topleftmenu {
  width: 20%;
  margin-left: 3dvw;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.topleftmenu li {
  list-style: none;
  text-wrap: nowrap;
  padding: 1vw;
}

.userbuttons {
  margin-left: auto;
  margin-right: 5%;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}

.userbuttons li {
  list-style: none;
  text-wrap: nowrap;
  padding: 0.5vw;
}

.userprofile {
  display: flex;
  align-items: center;
  height: 30px;
  margin-right: 3%;
  padding-left: 3%;
  border-left: 1px solid #DDDEDE;
}
</style>