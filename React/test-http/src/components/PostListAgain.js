import React, { Component/*,useState,useEffect*/ } from 'react'
import axios from 'axios'
import UserList from './User'

class PostListAgain extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],

            errorMsg: '',
            ShowAll: true
        }

    }

    componentDidMount() {
        axios
            .get('https://localhost:44344/api/sample/user')
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
        var n = 0
        return (
            <div key='0' style={{ border: 'solid', textAlign: 'center' }} >
                <tr style={{ display: 'flex', justifyContent: 'center' }}>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>ID</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>Title</td>
                    <td style={{ border: "1px solid rgb(0, 0, 0)", width: 150 }}>Review Comments</td>
                </tr>
                {posts.map(row => (
                    <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 100 }}>{row.id}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 100 }}>{row.userRole.name}</td>
                        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n++ % 2) === 1 ? '#aae' : '#dde', width: 150 }}><a href={"http://localhost:3000/Comment/reviewer/" + row.id}>Comments</a></td>
                    </tr>
                ))}

                {errorMsg ? <div>{errorMsg}</div> : null}
            </div>
        )
    }
}

export default PostListAgain
