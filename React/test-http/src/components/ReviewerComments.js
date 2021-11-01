import React, { Component } from 'react'
import axios from 'axios'

class ReviewerComments extends Component {
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
            .get('https://localhost:44344/api/comment/reviewer/' + id)
            .then(response => {
                console.log(response)
                this.setState({ posts: response.data })
            })
            .catch(error => {
                console.log(error)
                this.setState({ errorMsg: error.response.data })
            })
    }

    render() {
        const { posts, errorMsg } = this.state
        if (errorMsg == '') {
            console.log(errorMsg)
            let n = 0
            return (
                <div style={{ textAlign: 'center' }}>
                    <tr style={{ display: 'flex', justifyContent: 'center' }}>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>Target</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>Reviewer</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", width: 150 }}>Answer Type</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>Answer</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", width: 1000 }}>Comment</td>
                    </tr>
                    {posts.map(row => (
                        <tr style={{ display: 'flex', justifyContent: 'center' }}>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 100 }}>{row.target}</td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 100 }}>{row.reviewer}</td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 150 }}>{row.answerType}</td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 100 }}>{row.answer}</td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n++ % 2) === 1 ? '#aae' : '#dde', width: 1000 }}>{row.comment}</td>
                        </tr>
                    ))}
                </div>
            )
        }
        else {
            return (
                <div style={{ textAlign: 'center', color: 'red', fontSize: 50 }}>
                    {errorMsg}
                </div>
            )
        }
    }
}

export default ReviewerComments
