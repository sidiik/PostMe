import React from 'react';

const NotFound = () => {
  return (
    <div className='flex items-center justify-center w-full h-[20vh] text-center mt-20'>
      <div>
        <h1 className='text-8xl font-bold my-4 text-transparent bg-clip-text bg-gradient-to-l from-green-400 via-indigo-500 to-slate-100'>
          404
        </h1>
        <p>
          The page you are looking for does not exist. Please check the URL and
          try again.
        </p>

        <p className='text-gray-500'>
          Current URL:{' '}
          <span className='text-gray-700'>{window.location.href}</span>
        </p>

        <button className='px-4 my-4 py-3 rounded-md text-white bg-indigo-500'>
          <a href='/'>Go Back</a>
        </button>
      </div>
    </div>
  );
};

export default NotFound;
