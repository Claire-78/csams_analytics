import React, { Component } from 'react'
import axios from 'axios'
import AssiCommentsList from './AssiCommentsList'

class AssiComments extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: ''
        }
    }

    clickHandler() { }

    componentDidMount() {
        const { id } = this.props.match.params
        console.log(id)
        axios
            .get('https://localhost:5001/api/comment/project/' + id)
            .then(response => {
                console.log(response)
                this.setState({ posts: response.data })
            })
            .catch(error => {
                console.log(error)
                this.setState({ errorMsg: 'Unexpected Error' })
            })
    }

    render() {
        const { posts, errorMsg } = this.state
        if (posts != []) {
            console.log(errorMsg)
            const assiComments = posts.map(post => (
                <AssiCommentsList key={post.target} post={post}></AssiCommentsList >

            ))
            return (
                <div>
                    Target  ,  Reviewer  ,  Answer Type  ,  Answer  ,  Comment
                    {assiComments}
                </div>
            )
        }
        else {
            return (
                <div>
                    errorMsg
                </div>
            )
        }
    }
}

export default AssiComments