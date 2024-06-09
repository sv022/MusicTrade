<template>

<div class="footer_images">
    <picture>
        <source media="(min-width: 730px)" srcset="/img/guitar_logo.png" style="width: 15%; transition: 1s;">
        <img src="/img/guitar_logo_small.png" style="width: 20%; transition: 1s;">
    </picture>
    <div class="footer_images_links">
        <a href="https://vk.com/sv022"><img src="/img/vklogo.png" style="height: 30px; margin-right: 1%;"></a>
        <a href="https://t.me/sv_022"><img src="/img/telegramlogo.png" style="height: 30px;"></a>
    </div>
</div>
<div class="site_footer">
    <div class="footer_about">
        <p>© 2023-2023 MusicTrade<sup>TM</sup> - интернет-площадка. <br>Все права защищены. Копирование материалов с сайта без ссылки на этот ресурс запрещено. <br>г. Москва, пр-кт Ленинский, 137к2</p>
    </div>
    <div class="footer_useragreement">
        Пользовательское соглашение<br>Политика обработки персональных данных
    </div>
</div>        
    
</template>

<style scoped>
.footer_images {
  display: flex;
  flex-direction: column;
  max-width: fit-content;
}

.footer_images_links{
  margin-top: 2%;
  margin-left: 3%;
}

.site_footer {
  display: flex;
  align-items: center;
}

.site_footer .footer_useragreement {
  text-align: right;
  margin-left: auto;
}
</style>