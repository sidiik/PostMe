const PostSkeleton = () => {
  return (
    <div className=' mx-auto my-4'>
      {Array.from({ length: 6 }).map((_, i) => (
        <div className='border px-3 py-4'>
          <div className='w-[50%] skeleton  bg-gray-300 p-2 rounded-full '></div>
          <div className='w-[20%] skeleton  my-2 bg-gray-300 p-2 rounded-full '></div>
          <div className='w-[70%] skeleton  my-2 bg-gray-300 p-2 rounded-full '></div>
          <div className='w-[70%] skeleton  my-2 bg-gray-300 p-2 rounded-full '></div>
          <div className='w-[20%] skeleton  my-2 bg-gray-300 p-2 rounded-full '></div>
        </div>
      ))}
    </div>
  );
};

export default PostSkeleton;
