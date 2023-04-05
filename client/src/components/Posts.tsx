import React, { useEffect, useState } from 'react';
import { Post } from '../types/PostTypes';
import { agents } from '../agent';
import PostSkeleton from './PostSkeleton';
import PostItem from './Post';

const Posts = () => {
  const [posts, setPosts] = useState<Post[]>([]);

  useEffect(() => {
    agents.Posts.all.then((res) => setPosts(res));
    console.log(posts);
  }, []);

  return (
    <div className='mx-auto'>
      <h3 className='text-2xl font-bold my-3'>Feed</h3>
      {!posts.length && <PostSkeleton />}
      <div className='mx-auto'>
        {posts.map((post, i) => (
          <PostItem key={i} post={post} />
        ))}
      </div>
    </div>
  );
};

export default Posts;
