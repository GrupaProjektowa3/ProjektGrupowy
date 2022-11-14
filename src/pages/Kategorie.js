import React, { useState } from "react";

function Kategorie() {
  const [posts, setPosts] = useState([]);

  function getCategories() {
    const url = 'https://localhost:5001/api/Categories'
    let controller = new AbortController();
    let signal = controller.signal;

    fetch(url, {
      method: 'GET',
    })
      .then(response => response.json())
      .then(postsFromServer => {
        console.log(postsFromServer);
        setPosts(postsFromServer);
      })
      .catch((error) => {
        console.log(error)
        alert(error)
      })
  }

  function renderCategoriesTable() {
    return (
      <div className="table-responsive mt-5">
        <button onClick={getCategories}>Get Categories</button>
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Nazwa</th>
              <th scope="col">Opis</th>
            </tr>
          </thead>
        </table>
      </div>
    )
  }

  return (
    renderCategoriesTable()
  );
}

export default Kategorie;
