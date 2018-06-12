import Vue from "vue";
import StreamersUi from "./StreamersUi.vue";

const getVm = function(options){
  const Constructor = Vue.extend(StreamersUi);
  return new Constructor({ ...options }).$mount();
};

describe("StreamersUi.vue", () => {
  it("should render hello", () => {
    const vm = getVm();
    expect(vm.$el.textContent)
      .toBe("Hello");
  });
});
