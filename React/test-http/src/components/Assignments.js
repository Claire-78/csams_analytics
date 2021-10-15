import React, { Component } from 'react'
import axios from 'axios'
import AssignmentList from './AssignmentList'

class Assignments extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: ''
        }
    }

    clickHandler() { }

    componentDidMount() {
        axios
            .get('https://localhost:5001/api/Assignment')
            .then(response => {
                console.log(response)
                this.setState({ posts: response.data })
            })
            .catch(error => {
                console.log(error)
                this.setState({ errorMsg: 'Error retrieving data' })
            })
    }

    render() {
        const { posts, errorMsg } = this.state
        const assignmentList = posts.map(post => (
            <AssignmentList key={post.id} post={post}></AssignmentList >

        ))
        return (
            <div>
                Assignment  ,  Course  ,  Deadline  ,  ReviewDeadline
                {assignmentList}

                {errorMsg ? <div>{errorMsg}</div> : null}
            </div>
        )
    }
}

export default Assignments