import React, { Component } from 'react'
import axios from 'axios'
import UserReviewsList from './userReviewsList'
import StatisticsList from './StatisticsList'
import ShowBoxplot from './ShowBoxplot'

class Statistics extends Component {
	constructor(props) {
		super(props)

		this.state = {
			assignment: '',
			reviewerId: '',
			targetId: '',
			userReviews: [],
			statistics: [],
			errorMsg1: '',
			errorMsg2: '',
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
				this.setState({ errorMsg2: '' })
			})
			.catch(error => {
				console.log(error)
				this.setState({ userReviews: [] })
				this.setState({ errorMsg2: error.response.data })
			})

		axios
			.post('https://localhost:44344/api/statistics/userReviewsFilteredStatistics', this.state)
			.then(Response => {
				console.log(Response)
				this.setState({ statistics: Response.data })
				this.setState({ errorMsg1: '' })
			})
			.catch(error => {
				console.log(error)
				this.setState({ statistics: [] })
				this.setState({ errorMsg1: error.response.data })
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
		const { assignment, reviewerId, targetId, userReviews, statistics, errorMsg1, errorMsg2 } = this.state
		const userReviewsList = userReviews.map(post => (
			<UserReviewsList key={post.id} post={post}></UserReviewsList>
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
					{errorMsg1 ? <div>{errorMsg1}</div> : null}
				</div>
				<div>
					<ShowBoxplot />
				</div>
				<div>
					<h1>
						Comments
					</h1>
					{errorMsg2 ? <div>{errorMsg2}</div> : "ID, Name, Assignment Name, ReviewerID, TargetID, Answer"}
					{userReviewsList}
				</div>
			</div>
		)
	}
}

export default Statistics