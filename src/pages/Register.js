import { useCallback } from "react";
import { useNavigate } from "react-router-dom";

function Register() {
  const navigate = useNavigate();
  const handleClick = useCallback(
    () => navigate("/login", { replace: true }),
    [navigate]
  );

  return (
    <div className="container login-form d-flex align-items-center">
      <div className="row w-50 mx-auto border rounded-2">
        <h3 className="text-center login-text py-3">Zarejestruj</h3>
        <div>
          <div>
            <input
              type="text"
              className="form-control"
              placeholder="Imie"
              aria-label="Username"
              aria-describedby="basic-addon1"
            ></input>
          </div>
          <div className="my-3">
            <input
              type="email"
              className="form-control"
              placeholder="E-mail"
              aria-label="E-mail"
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
          <div className="my-3">
            <input
              type="password"
              className="form-control"
              placeholder="Powtorz haslo"
              aria-label="Password"
              aria-describedby="basic-addon1"
            ></input>
          </div>
          <button type="button" className="btn login-btn  w-100">
            Zarejestruj
          </button>
          <button
            type="button"
            className="btn register-btn my-3 w-100"
            onClick={handleClick}
          >
            Masz konto? Zaloguj
          </button>
        </div>
      </div>
    </div>
  );
}

export default Register;
