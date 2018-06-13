import { pluginBuilder } from "feather-utils";
import StreamersUiPlugin from "./StreamersUi";
import StreamersDbUiPlugin from "./StreamersDbUi";

export default pluginBuilder([
  StreamersUiPlugin,
  StreamersDbUiPlugin
]);
