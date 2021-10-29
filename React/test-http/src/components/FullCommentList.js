import React from 'react'


function FullCommentList({ post }) {
    return (
        <div>


            <div key={post.id} style={{ border: 'solid' }}>{post.id} | {post.name} | {post.assignment.name} | {post.userReviewer} | {post.userTarget}


            </div>


        </div>
    )
}

export default FullCommentList
