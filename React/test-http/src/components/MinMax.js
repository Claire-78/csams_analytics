import React, { Component } from 'react'
import axios from 'axios'

class MinMax extends Component {
	constructor(props) {
		super(props)

		this.state = {
			posts: [],
			errorMsg: '',
			Minid: 0,
			Maxid: 0,
			Min: 100,
			Max: -1,
			IsMax: false,
			IsMin: false
		}
	}


	clickHandler() {


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
				this.setState({ errorMsg: 'Error retrieving data' })
			})
	}


	MinAdd(post) {
		this.setState({ Min: post.answer })
		this.setState({ Minid: post.id })
		console.log(post.id, 'id')
	}

	MaxAdd(post) {
		this.setState({ Max: post.answer })
		this.setState({ Maxid: post.id })
		console.log(post.id, 'id')
	}

	MaxCliked() {

		this.setState({ IsMax: true })
		this.setState({ IsMin: false })
		console.log(this.state.IsMin, 'min')
		console.log(this.state.IsMax, 'max')
	}

	MinCliked() {
		this.setState({ IsMin: true })
		this.setState({ IsMax: false })
	}

	render() {
		const { posts, errorMsg } = this.state

		posts.map(post => (



			this.state.Min > post.answer ? this.MinAdd(post) : this.state.Min,
			this.state.Max < post.answer ? this.MaxAdd(post) : this.state.Max
		))

		let message
		if (this.state.IsMin) { message = <h1 style={{ borderBlock: 'solid' }}> min is: {this.state.Min} with id {this.state.Minid} </h1> }
		else if (this.state.IsMax) {
			message = <h1 style={{ borderBlock: 'solid' }}> max is: {this.state.Max} with id {this.state.Maxid} </h1>
		}
		else { message = null }

		return (

			<div>

				<button onClick={() => this.MaxCliked()}>Show Max </button>
				<button onClick={() => this.MinCliked()}>Show Min </button>
				{message}

				{errorMsg ? <div>{errorMsg}</div> : null}
			</div>
		)
	}
}

export default MinMax