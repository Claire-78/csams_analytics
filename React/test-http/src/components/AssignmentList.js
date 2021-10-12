import React from 'react'

function AssignmentList({ post }) {
    return (
        <div>


            <div key={post.id} style={{ border: 'solid' }}>{post.name} | {post.course} | {post.deadline} | {post.reviewDeadline} | <a href={"http://localhost:3000/Comment/Project/" + post.id}>Comments</a>

            </div>


        </div>
    )
}

export default AssignmentList