import { useCallback } from "react";
import { useNavigate } from "react-router-dom";

import "../style.css";

function Login() {
  const navigate = useNavigate();
  const handleClick = useCallback(
    () => navigate("/register", { replace: true }),
    [navigate]
  );
  return (
    <div className="container login-form d-flex align-items-center">
      <div className="row w-50 mx-auto border rounded-2">
        <h3 className="text-center login-text py-3">Zaloguj sie</h3>
        <div>
          <div className="">
            <input
              type="text"
              className="form-control"
              placeholder="Login"
              aria-label="Username"
              aria-describedby="basic-addon1"
            ></input>
          </div>
          <div className="my-3">
            <input
              type="password"
              className="form-control"
              placeholder="Haslo"
              aria-label="Password"
              aria-describedby="basic-addon1"
            ></input>
          </div>
          <button type="button" className="btn login-btn  w-100">
            Zaloguj
          </button>
          <button
            type="button"
            className="btn register-btn my-3 w-100"
            onClick={handleClick}
          >
            Nie masz konta? Zaloz je!
          </button>
        </div>
      </div>
    </div>
  );
}

export default Login;
