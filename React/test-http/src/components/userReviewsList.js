import React from 'react'


function UserReviewsList({ post }) {
    return (
        <div>


            <div key={post.id} style={{ border: 'solid' }}>{post.id} | {post.name} | {post.assignment.name} | {post.userReviewer} | {post.userTarget} | {post.answer}


            </div>


        </div>
    )
}

export default UserReviewsList
