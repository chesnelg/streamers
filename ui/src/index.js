import ComponentsPlugin from "./components";
// import StoresPlugin from "./stores";

import { pluginBuilder } from "feather-utils";
const plugin = pluginBuilder([ComponentsPlugin /*, StoresPlugin*/]).auto(window);

export default plugin;
