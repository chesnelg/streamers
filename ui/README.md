# streamers-ui
<a href="http://build.navimedix.com/viewType.html?buildTypeId=Branching2014Rollout_CI_StreamersUi">
<img src="http://build.navimedix.com/app/rest/builds/buildType:(id:Branching2014Rollout_CI_StreamersUi)/statusIcon"/>
</a>
> A header styled according to Feather. Following the pattern https://nhwiki.nanthealth.com/display/UX/Page+Header

## Install

### Prerequisites

To use `streamers-ui` you must have an `.npmrc` set up with the following line:

```
registry = http://dml.navimedix.com:8081/artifactory/api/npm/navinet-npm
```

**WARNING** - leaving the `.npmrc` checked in will not allow your package to be published to our private NPM.

### npm install

Run the following command to install `streamers-ui`

```
npm install streamers-ui
```

## Usage

```js
import Vue from "vue";
// import Vuex from "vuex";
// import VueI18n from "vue-i18n";
import StreamersUi from "streamers-ui";

// Vue.use(Vuex);
//   const store = new Vuex.Store({
// });
// Vue.use(VueI18n);
Vue.use(StreamersUi, { /*store*/ });
```

```html
<streamers-ui></streamers-ui>
```

## Dev Setup

1. Clone repo
2. `npm i` to install dependencies
3. `npm run dev` to start a dev server hosting the demos.
