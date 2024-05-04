<template>
    <div class="p-10">
        <h2 class="p-10 pl-0 text-3xl">Искать в категории</h2>
        <div class="flex flex-wrap w-3/4 pl-10">
            <div class="category">Электрогитары</div>
            <div class="category">Классические гитары</div>
            <div class="category">Акустические гитары</div>
            <div class="category">Гитарное усиление</div>
            <div class="category">Педали эффектов</div>
        </div>
    </div>
</template>

<style scoped>
.category {
  width: 29%;
  min-width: 280px;
  border: 1px solid #232122;
  background-color: #fdfdfd;
  padding: 1.5%;
  margin: 3px;
  border-radius: 5px;
  text-align: center;
  text-wrap: nowrap;
  font-size: larger;
}

.category a {
  text-decoration: none;
  color:#232122;
}
</style>