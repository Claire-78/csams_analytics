import React from 'react'

function AssignmentList({ post }) {
    return (
        <div>


            <div key={post.target} style={{ border: 'solid' }}>{post.target} | {post.reviewer} | {post.answerType} | {post.answer} | {post.comment}

            </div>


        </div>
    )
}

export default AssignmentList
