import React from "react";
import { useRouteError } from "react-router-dom";
import '../assets/scss/pages/ErrorPage.scss';
export default function ErrorPage(): JSX.Element {
  const error = useRouteError();
  console.error(error);

  return (
    <div id="error-page" className="bg-dark text-light full-page">
      <div className="container">
        <div className="col-md-10 m-auto">
          <h1 className="display-3">Oops! {
// @ts-ignore
          error.status}</h1>
          <p className="lead">Sorry, an unexpected error has occurred.</p>
          <p className="small">
            <i>
              {
// @ts-ignore
              error.statusText} | {error.data || error.message}</i>
              
          </p>
        </div>
      </div>
    </div>
  );
}
