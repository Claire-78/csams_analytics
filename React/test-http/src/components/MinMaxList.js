import React from 'react'


function MinMaxList({post}) {
  
    return (
        <div>
    	
    
		 <div key={post.id} style={{border: 'solid'}}>user: {post.id} for assingment:{post.name} with grade  {post.answer}

        
         
        </div>
       
      
        </div>
    )
}

export default MinMaxList
