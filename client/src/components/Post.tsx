import { Post } from '../types/PostTypes';
import { Link } from 'react-router-dom';

const PostItem = ({ post }: { post: Post }) => {
  return (
    <Link to={`/post/${post.id}`}>
      <div className='border py-4 px-3'>
        <p className='text-white shadow-md my-2 bg-indigo-500 px-3 inline-block rounded-full text-sm'>
          {post.lastUpdatedAt.split('T')[0]}
        </p>
        <h1 className='text-xl font-bold'>{post.title}</h1>
        <p className='my-4'>{post.content}</p>
      </div>
    </Link>
  );
};

export default PostItem;
