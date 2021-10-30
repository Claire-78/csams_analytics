import React from 'react'


function UserList({post}) {
    return (
        <div>
    	
    
		 <div key={post.id} style={{border: 'solid'}}>{post.id} ,  {post.userRole.name} | <a href={"http://localhost:3000/Comment/reviewer/" + post.id}>Comments</a>
         
        </div>
       
      
        </div>
    )
}

export default UserList
