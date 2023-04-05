import {
  createBrowserRouter as Router,
  RouterProvider,
  Outlet,
} from 'react-router-dom';
import Home from '../pages/Home';
import Header from '../components/Header';
import NotFound from '../components/404';
import PostDetail from '../pages/PostDetail';

export const Root = () => {
  return (
    <div className='flex flex-col'>
      <Header />

      <div className='w-[60%] mx-auto my-8'>
        <Outlet />
      </div>

      <div className='text-center mt-20'>
        {' '}
        &copy; Developed by Sidiiq {new Date().getFullYear()}
      </div>
    </div>
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
      {
        path: '/post/:id',
        element: <PostDetail />,
      },
      {
        path: '*',
        element: <NotFound />,
      },
    ],
  },
]);

export default routes;
