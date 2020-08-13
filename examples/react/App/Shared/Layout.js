import { InertiaLink } from "@inertiajs/inertia-react";
import React from "react";

const Layout = ({ children }) => (
  <main>
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <a className="navbar-brand" href="#">
        Navbar
      </a>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div className="navbar-nav">
          <InertiaLink href="/" className="nav-item nav-link">
            Home
          </InertiaLink>
          <InertiaLink href="/forecast" className="nav-item nav-link">
            Forecast
          </InertiaLink>
          <InertiaLink href="/counter" className="nav-item nav-link">
            Counter
          </InertiaLink>
        </div>
      </div>
    </nav>

    <article>{children}</article>
  </main>
);

export default Layout;
