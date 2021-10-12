import React, { Component } from 'react'
import axios from 'axios'
import MinMaxList from './MinMaxList'

class MinMax extends Component {
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
			.get('https://localhost:44344/api/MinMax/userReviewsMinMax')
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
		const minmaxlist=posts.map(post => (
			<MinMaxList key={post.id} post={post}></MinMaxList >

		))
		return (
			<div>
                    <h1> 
                        </h1> 
               {minmaxlist}
				
        {errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default MinMax