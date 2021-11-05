import React, { Component } from 'react'
import axios from 'axios'

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
            .get('https://localhost:44344/api/Assignment')
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
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Assignment</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Course</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Deadline</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Review Deadline</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 250 }}>Review Comments</td>
                </tr>
                {posts.map(row => (
                    <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.name}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.course}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.deadline}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.reviewDeadline}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n++ % 2) === 1 ? '#aae' : '#dde', width: 250 }}><a href={"http://localhost:3000/Comment/Project/" + row.id}>Comments</a></td>
                    </tr>
                ))}

                {errorMsg ? <div>{errorMsg}</div> : null}


            </div>
        )
    }
}

export default Assignments
