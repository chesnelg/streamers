<template>
  <div>
      <h3 class="total">
        Number of items loaded: <span>{{ count }}</span><br>
        Load status: <span> {{ isLoadComplete ? "Complete" : "Loading" }} </span>
      </h3>
      <div class="item-row"  v-for="item in resultset" :key="item.name">
        <div class="item-col-1">
          {{ item.name}}
        </div>
        <div class="item-col-2">
          {{ item.description }}
        </div>
      </div>
  </div>
</template>
<script>
import oboe from "oboe";

export default {
  data(){
    return {
      resultset: [],
      count: 0,
      isLoadComplete: false
    };
  },
  created(){
    oboe("http://localhost/streamers/api/values")
      .node("resultset.*", (item) => {
        this.resultset.push(item);
        this.count = this.resultset.length;
      })
      .done(() => {
        this.isLoadComplete = true;
      });
  }
};
</script>

<style lang="scss" scoped>
.item-row{
  display:flex;

  .item-col-1{
    flex: 1;
  }
  .item-col-2{
    flex: 2;
  }
}
h3 span{
  font-size: larger;
}

</style>
