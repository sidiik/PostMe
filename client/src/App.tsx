import React from 'react';
import Header from './components/Header';
import Posts from './components/Posts';
import { RouterProvider } from 'react-router-dom';
import routes from './routes/Route';

function App() {
  return (
    <div>
      <RouterProvider router={routes} />
    </div>
  );
}

export default App;
