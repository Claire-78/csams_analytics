import React from 'react'


const Posts = ({ posts, loading }) => {
    if (loading) {
        return <h2>Loading...</h2>;
    }


    return (


        <ul className="list-group mb-5">

            {posts.map(post => (

                <li key={post.id} className='list-group-item' style={{ border: 'solid' }}>
                    {post.id} | {post.userReviewer} | {post.assignment.description}
                </li>
            ))}

        </ul>

    )
}


export default Posts
