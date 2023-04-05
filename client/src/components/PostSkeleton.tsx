import PostSkeletonHolder from './PostSkeletonHolder';

const PostSkeleton = () => {
  return (
    <div className=' mx-auto my-4'>
      {Array.from({ length: 6 }).map((_, i) => (
        <PostSkeletonHolder key={i} />
      ))}
    </div>
  );
};

export default PostSkeleton;
