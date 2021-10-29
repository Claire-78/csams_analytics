import React, { Component } from 'react'
import axios from 'axios'
import FullCommentList from './FullCommentList'
import StatisticsList from './StatisticsList'
import UserList from './PostListAgain'

class Filters extends Component {
	constructor(props) {
		super(props)

		this.state = {
			assignment: '',
			reviewerId: '',
			targetId: '',
			userReviews: [],
			statistics: [],
			errorMsg: '',
		}
	}


	clickHandler() {
	}

	changeHandler = (e) => {
		this.setState({ [e.target.name]: e.target.value })
	}

	submitHandler = (e) => {
		e.preventDefault()
		console.log(this.state)

		axios
			.post('https://localhost:44344/api/statistics/userReviewsFiltered', this.state)
			.then(Response => {
				console.log(Response)
				this.setState({ userReviews: Response.data })
			})
			.catch(error => {
				console.log(error)
				this.setState({ errorMsg: 'Error' })
			})

		axios
			.post('https://localhost:44344/api/statistics/userReviewsFilteredStatistics', this.state)
				.then(Response => {
					console.log(Response)
					this.setState({ statistics: Response.data })
				})
				.catch(error => {
					console.log(error)
					this.setState({ errorMsg: 'Error' })
				})

	}
	
	componentDidMount() {
		axios
			.get('https://localhost:44344/api/statistics/userReviews')
			.then(response => {
				console.log(response)
				this.setState({ userReviews: response.data })
			})
			.catch(error => {
				console.log(error)
				this.setState({ errorMsg: 'Error retrieving data' })
			})

		axios
			.get('https://localhost:44344/api/statistics/userReviewsStatistics')
			.then(response => {
				console.log(response)
				this.setState({ statistics: response.data })
			})
			.catch(error => {
				console.log(error)
				this.setState({ errorMsg: 'Error retrieving data' })
			})
	}


	render() {
		const { assignment, reviewerId, targetId, userReviews,statistics, errorMsg } = this.state
		const userReviewsList = userReviews.map(post => (
			<FullCommentList key={post.id} post={post}></FullCommentList >
		))
		const statisticslist = statistics.map(post => (
			<StatisticsList key={post.id} post={post}></StatisticsList >

		))
		return (
			<div>
				<h1>
					Filtering
				</h1>

				<div style={{ border: 'outset', textAlign: 'center' }}>
					<form onSubmit={this.submitHandler}>
						<div>
							<input type='text' name='assignment' value={assignment} onChange={this.changeHandler} placeholder='Assignment' />
						</div>
						<div>
							<input type='text' name='reviewerId' value={reviewerId} onChange={this.changeHandler} placeholder='ReviewerID' />
						</div>
						<div>
							<input type='text' name='targetId' value={targetId} onChange={this.changeHandler} placeholder='targetID' />
						</div>

						<button type='submit'>Submit </button>
					</form>
				</div>
				<div>
					<h1>
						Statistics
					</h1>
					{statisticslist}
				</div>

				<div>
					<h1>
						Comments
					</h1>
					ID, Name, Assignment Name, ReviewerID, TargetID
					{userReviewsList}
				</div>
				{errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default Filters