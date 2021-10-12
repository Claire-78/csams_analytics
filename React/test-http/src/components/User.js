import React from 'react'


function UserList({post}) {
    return (
        <div>
    	
    
		 <div key={post.id} style={{border: 'solid'}}>{post.id} ,  {post.userRole.name}
         
        </div>
       
      
        </div>
    )
}

export default UserList
