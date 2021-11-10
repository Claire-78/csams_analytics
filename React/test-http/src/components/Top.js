import React, { Component } from 'react'
import axios from 'axios'

class Top extends Component {
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
            .get('https://localhost:44344/api/Top/top/3/Top/true')
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
        let n = 0
        return (
            <div style={{ textAlign: 'center' }}>
                <tr style={{ display: 'flex', justifyContent: 'center' }}>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Grade</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Assignment name</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Assignment ID</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Reviewer ID</td>

                </tr>
                {posts.map(row => (
                    <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.grade}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.assignmentName}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.assignmentID}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.reviewerID}</td>
                    </tr>
                ))}

                {errorMsg ? <div>{errorMsg}</div> : null}


            </div>

        )
    }
}

export default Top
