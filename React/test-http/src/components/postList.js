import React, { Component } from 'react'
import axios from 'axios'

 class PostList extends Component {
constructor(props) {
    super(props)

    this.state = {
         post:[]
    }
}

componentDidMount(){
    axios
    .get('https://localhost:44344/api/sample/user')
    .then(response => {
        console.log(response)
        this.setState({posts: response.data})
    })
    .catch(error => {console.log(error)})
}

    render() {
        const { posts } =this.state
        return (
            <div>
               hello list 
               {
					posts.map(post => <div key={post.id}>{post.role}</div>)
        }
  
            </div>
             
        )
    }
}

export default PostList
