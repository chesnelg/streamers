import Vue from "vue";
// import Vuex from "vuex";
// import VueI18n from "vue-i18n";
// import messages from "./../src/locales/en";
import StreamersDbUi from "./../src/components/";

// Vue.use(Vuex);
// const store = new Vuex.Store({
// });
// Vue.use(VueI18n);
Vue.use(StreamersDbUi, { /* store */});

// const i18n = new VueI18n({
//   locale: "en", // set locale
//   fallbackLocale: "en",
//   messages: {en: messages} // set locale messages
// });


var app = new Vue({
  //store,
  //i18n,
  el: "#app"
});

export default app;
