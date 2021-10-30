import React, { Component } from 'react'
import axios from 'axios'
import StatisticsList from './StatisticsList'

class Statistics extends Component {
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
			.get('https://localhost:44344/api/statistics/userReviewsStatistics')
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
		const statisticslist = posts.map(post => (
			<StatisticsList key={post.id} post={post}></StatisticsList >

		))
		return (
			<div>
				<h1>
					Statistics
				</h1>
               {statisticslist}
				
        {errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default Statistics