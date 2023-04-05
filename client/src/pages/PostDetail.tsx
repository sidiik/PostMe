import React, { useEffect, useState } from 'react';
import { Post } from '../types/PostTypes';
import { useParams } from 'react-router-dom';
import { agents } from '../agent';
import PostSkeletonHolder from '../components/PostSkeletonHolder';
import PostItem from '../components/Post';

const PostDetail = () => {
  const [post, setPost] = useState<Post | null>(null);
  const { id } = useParams();

  useEffect(() => {
    async function getPost() {
      const post = await agents.Posts.getPost(parseInt(id!));
      setPost(post);
    }

    getPost();
  }, [id]);

  return (
    <div>
      <h1 className='my-3'>
        <span className='text-2xl font-bold'>Post Detail</span>
      </h1>
      {!post ? (
        <PostSkeletonHolder />
      ) : (
        <>
          <PostItem post={post} />
        </>
      )}
    </div>
  );
};

export default PostDetail;
