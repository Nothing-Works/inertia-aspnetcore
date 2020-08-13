import { InertiaApp } from "@inertiajs/inertia-react";
import React from "react";

const App = (props) => (
  <InertiaApp
    initialPage={JSON.parse(app.dataset.page)}
    resolveComponent={(name) =>
      import(`./Pages/${name}`).then((module) => module.default)
    }
  />
);

export default App;
