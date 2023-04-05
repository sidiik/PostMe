import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
const Header = () => {
  const navigate = useNavigate();

  const handleClick = () => {
    navigate('/new');
  };

  return (
    <div className='bg-gray-100 p-4'>
      <div className='w-[90%] mx-auto flex justify-between items-center'>
        <Link to={'/'} className='logo'>
          <h1 className='text-2xl'>Try PostMe.</h1>
        </Link>

        <div>
          <button
            onClick={handleClick}
            className='bg-indigo-500 text-white px-4 py-2 rounded-md'
          >
            Create Post
          </button>
        </div>
      </div>
    </div>
  );
};

export default Header;
