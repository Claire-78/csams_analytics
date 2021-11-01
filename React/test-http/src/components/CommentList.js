import React from 'react'


function CommentList({post}) {
    return (
        <div>
    	
    
		 <div key={post.id} style={{border: 'solid'}}>{post.id} | {post.userReviewer} | {post.assingment.description} 
         
         
        </div>
       
      
        </div>
    )
}

export default CommentList
