import React, { useState, useEffect } from 'react'
import axios from 'axios'
// import CommentList from './CommentList'
// import Posts from './Pagination/Posts'
// import { Pagination } from './Pagination/Pagination'
import ReactPaginate from "react-paginate";

const Comments = () => {
	const [posts, setPosts] = useState([]);
	const [loading, setLoading] = useState(false);

	const [currentPage, setCurrentPage] = useState(0);
	const [postsPerPage] = useState(15);
	//const pagesVisited = currentPage * postsPerPage;
	//const [pageNumber, setPageNumber] = useState(0);
	useEffect(() => {
		const fetchPosts = async () => {
			setLoading(true);
			const res = await axios.get('https://localhost:44344/api/Basic/comments');
			setPosts(res.data);
			setLoading(false);
		};

		fetchPosts();
	}, []);

	// Get current posts

	//const [pageNumber, setPageNumber] = useState(0);

	//const postsPerPage = 15;
	const pagesVisited = currentPage * postsPerPage;


	const displayposts = posts
		.slice(pagesVisited, pagesVisited + postsPerPage)
		.map((post) => {
			return (
				<li key={post.id} className='list-group-item' style={{ border: 'solid' }}>
					{post.id} | {post.userReviewer} | {post.assignment.description}
				</li>
			);
		});

	const pageCount = Math.ceil(posts.length / postsPerPage);

	const changePage = ({ selected }) => {
		setCurrentPage(selected);
	};
	console.log(pagesVisited, ' pages');
	return (

		<div className="App">
			{displayposts}
			<ReactPaginate
				previousLabel={"Previous"}
				nextLabel={"Next"}
				pageCount={pageCount}
				onPageChange={changePage}
				containerClassName={"paginationBttns"}
				previousLinkClassName={"previousBttn"}
				nextLinkClassName={"nextBttn"}
				disabledClassName={"paginationDisabled"}
				activeClassName={"paginationActive"}
			/>
		</div>
	);
};

export default Comments;
