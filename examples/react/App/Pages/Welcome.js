import React from "react";
import Layout from "../Shared/Layout";

const Welcome = (props) => (
  <Layout>
    <h1>Welcome</h1>
    <p>Welcome to my first Inertia.js app!</p>
    <p>Id: {props.controller.id}</p>
  </Layout>
);

export default Welcome;
