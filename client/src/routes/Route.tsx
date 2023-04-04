import {
  createBrowserRouter as Router,
  RouterProvider,
  Outlet,
} from 'react-router-dom';
import Home from '../pages/Home';
import Header from '../components/Header';

export const Root = () => {
  return (
    <>
      <Header />
      <Outlet />
      <div className='text-center mt-20'>
        {' '}
        &copy; Developed by Sidiiq {new Date().getFullYear()}
      </div>
    </>
  );
};

const routes = Router([
  {
    path: '/',
    element: <Root />,
    children: [
      {
        index: true,
        element: <Home />,
      },
    ],
  },
]);

export default routes;
