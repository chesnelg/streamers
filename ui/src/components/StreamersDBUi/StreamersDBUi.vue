<template>
  <div>
    <div class="stream">
      <h3 class="total">
        Number of items loaded: <span>{{ streamCount }}</span><br>
        Stream Load status: <span> {{ isStreamLoadComplete ? "Complete" : "Loading" }} </span>
      </h3>
      <table>
        <tr>
          <th>ID</th>
          <th>Policy ID</th>
          <th>State Code</th>
          <th>County</th>
          <!-- <th>EQ Site Limit</th>
          <th>HU Site Limit</th>
          <th>FL Site Limit</th>
          <th>FR Site Limit</th>
          <th>Tiv 2011</th>
          <th>Tiv 2012</th>
          <th>EQ Site Deductible</th>
          <th>HU Site Deductible</th>
          <th>FL Site Deductible</th>
          <th>FR Site Deductible</th>
          <th>Point Latitude</th>
          <th>Point Longitude</th>
          <th>Line</th>
          <th>Construction</th>
          <th>Point Granularity</th> -->
        </tr>
        <tr v-for="item in streamResult" :key="item.id">
          <th>{{ item.id }}</th>
          <th>{{ item.policy_id }}</th>
          <th>{{ item.state_code }}</th>
          <th>{{ item.county }}</th>
          <!-- <th>{{ item.eq_site_limit }}</th>
          <th>{{ item.hu_site_limit }}</th>
          <th>{{ item.fl_site_limit }}</th>
          <th>{{ item.fr_site_limit }}</th>
          <th>{{ item.tiv_2011 }}</th>
          <th>{{ item.tiv_2012 }}</th>
          <th>{{ item.eq_site_deductible }}</th>
          <th>{{ item.hu_site_deductible }}</th>
          <th>{{ item.fl_site_deductible }}</th>
          <th>{{ item.fr_site_deductible }}</th>
          <th>{{ item.point_latitude }}</th>
          <th>{{ item.point_longitude }}</th>
          <th>{{ item.line }}</th>
          <th>{{ item.construction }}</th>
          <th>{{ item.point_granularity }}</th> -->
        </tr>
      </table>
    </div>
    <div class="non-stream">
      <h3 class="total">
        Number of items loaded: <span>{{ nonStreamCount }}</span><br>
        Non Stream Load status: <span> {{ isNonStreamLoadComplete ? "Complete" : "Loading" }} </span>
      </h3>
      <table>
        <tr>
          <th>ID</th>
          <th>Policy ID</th>
          <th>State Code</th>
          <th>County</th>
          <!-- <th>EQ Site Limit</th>
          <th>HU Site Limit</th>
          <th>FL Site Limit</th>
          <th>FR Site Limit</th>
          <th>Tiv 2011</th>
          <th>Tiv 2012</th>
          <th>EQ Site Deductible</th>
          <th>HU Site Deductible</th>
          <th>FL Site Deductible</th>
          <th>FR Site Deductible</th>
          <th>Point Latitude</th>
          <th>Point Longitude</th>
          <th>Line</th>
          <th>Construction</th>
          <th>Point Granularity</th> -->
        </tr>
        <tr v-for="item in nonStreamResult" :key="item.id">
          <th>{{ item.id }}</th>
          <th>{{ item.policy_id }}</th>
          <th>{{ item.state_code }}</th>
          <th>{{ item.county }}</th>
          <!-- <th>{{ item.eq_site_limit }}</th>
          <th>{{ item.hu_site_limit }}</th>
          <th>{{ item.fl_site_limit }}</th>
          <th>{{ item.fr_site_limit }}</th>
          <th>{{ item.tiv_2011 }}</th>
          <th>{{ item.tiv_2012 }}</th>
          <th>{{ item.eq_site_deductible }}</th>
          <th>{{ item.hu_site_deductible }}</th>
          <th>{{ item.fl_site_deductible }}</th>
          <th>{{ item.fr_site_deductible }}</th>
          <th>{{ item.point_latitude }}</th>
          <th>{{ item.point_longitude }}</th>
          <th>{{ item.line }}</th>
          <th>{{ item.construction }}</th>
          <th>{{ item.point_granularity }}</th> -->
        </tr>
      </table>
    </div>
  </div>
</template>
<script>
import oboe from "oboe";
/*eslint camelcase: ["error", {properties: "never"}]*/
export default {
  data(){
    return {
      streamResult: [],
      nonStreamResult: [],
      streamCount: 0,
      nonStreamCount: 0,
      isStreamLoadComplete: false,
      isNonStreamLoadComplete: false
    };
  },
  created(){
    oboe("http://localhost:5050/api/values/stream/database")
      .node("streamResult.*", (item) => {
        const smallStreamItem = {
          id: item.id,
          policy_id: item.policy_id,
          state_code: item.state_code,
          county: item.county
        };
        //this.streamResult.push(smallStreamItem);
        this.streamResult.splice(0, 0, smallStreamItem);
        this.streamCount = this.streamResult.length;

        // By returning oboe.drop, the parsed JSON object will be freed,
        // allowing it to be garbage collected.
        return oboe.drop;
      })
      .done(() => {
        this.isStreamLoadComplete = true;
      });

    oboe("http://localhost:5050/api/values/nonstream/database")
      // .node("nonStreamResult.*", (item) => {
      //   const smallNonStreamItem = {
      //     id: item.id,
      //     policy_id: item.policy_id,
      //     state_code: item.state_code,
      //     county: item.county
      //   };
      //   this.nonStreamResult.push(smallNonStreamItem);
      //   this.nonStreamCount = this.nonStreamResult.length;

      //   // By returning oboe.drop, the parsed JSON object will be freed,
      //   // allowing it to be garbage collected.
      //   return oboe.drop;
      // })
      .done((result) => {

        result.nonStreamResult.forEach((item) => {
          const smallNonStreamItem = {
            id: item.id,
            policy_id: item.policy_id,
            state_code: item.state_code,
            county: item.county
          };
          this.nonStreamResult.push(smallNonStreamItem);
        });

        this.nonStreamCount = this.nonStreamResult.length;

        this.isNonStreamLoadComplete = true;
      });
  }
};
</script>

<style lang="scss" scoped>
h3 span{
  font-size: larger;
}
.stream {
  float: left;
}
.non-stream {
  float: right;
}
</style>
