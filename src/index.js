import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Kategorie from "./pages/Kategorie";
import Login from "./pages/Login";
import Profil from "./pages/Profil";
import Ranking from "./pages/Ranking";
import Register from "./pages/Register";
import MainPage from "./pages/HomePage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainPage />,
  },
  {
    path: "/kategorie",
    element: <Kategorie />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/profil",
    element: <Profil />,
  },
  {
    path: "/ranking",
    element: <Ranking />,
  },
  {
    path: "/register",
    element: <Register />,
  },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<RouterProvider router={router} />);
