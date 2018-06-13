import Vue from "vue";
import StreamersDbUi from "./StreamersDbUi.vue";

const getVm = function(options){
  const Constructor = Vue.extend(StreamersDbUi);
  return new Constructor({ ...options }).$mount();
};

describe("StreamersDbUi.vue", () => {
  it("should render hello", () => {
    const vm = getVm();
    expect(vm.$el.textContent)
      .toBe("Hello");
  });
});
