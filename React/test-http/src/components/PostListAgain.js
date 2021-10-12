import React, { Component } from 'react'
import axios from 'axios'
import UserList from './User'

class PostListAgain extends Component {
	constructor(props) {
		super(props)

		this.state = {
      posts: [],
      errorMsg: ''
		}
	}


    clickHandler(){
        
        
    }

	componentDidMount() {
		axios
			.get('https://localhost:44344/api/sample/user')
			.then(response => {
				console.log(response)
				this.setState({ posts: response.data })
			})
			.catch(error => {
        console.log(error)
        this.setState({errorMsg: 'Error retrieving data'})
			})
	}

	render() {
		const { posts, errorMsg } = this.state
		const userlist=posts.map(post => (
			<UserList key={post.id} post={post}></UserList >

		))
		return (
			<div>
				   ID   ,  Title
               {userlist}
				
        {errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default PostListAgain