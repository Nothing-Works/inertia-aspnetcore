import React, { useState } from "react";
import Layout from "../Shared/Layout";

const Counter = (props) => {
  const [currentCount, setCurrentCount] = useState(
    props.controller.initialValue
  );
  return (
    <Layout>
      <h1>Counter</h1>
      <p>This is a simple example of a React component.</p>

      <p aria-live="polite">
        Current count: <strong>{currentCount}</strong>
      </p>
      <div class="btn-group" role="group" aria-label="Basic example">
        <button
          className="btn btn-danger"
          onClick={() => setCurrentCount(currentCount - 1)}
        >
          Decrement
        </button>
        <button
          className="btn btn-success"
          onClick={() => setCurrentCount(currentCount + 1)}
        >
          Increment
        </button>
      </div>
    </Layout>
  );
};

export default Counter;
