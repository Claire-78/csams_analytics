import React, { Component } from 'react'
import axios from 'axios'
import CommentList from './CommentList'


class Comments extends Component {
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
			.get('https://localhost:44344/api/Basic/comments')
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
		const commentlist=posts.map(post => (
			<CommentList key={post.id} post={post}></CommentList >

		))
		return (
			<div>
				   ID   ,  Reviewer, Assignment
               {commentlist}
				
        {errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default Comments