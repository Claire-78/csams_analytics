import React, { Component } from 'react'
import axios from 'axios'

class AssiComments extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: '',
            ID: parseInt(props.match.params.id),
            AnswerType: "",
            Answer: "",
            Comment: ""
        }
    }

    clickHandler() { }

    changeHandler = (e) => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitHandler = (e) => {
        e.preventDefault()
        this.componentDidMount()
    }

    componentDidMount() {
        const { id } = this.props.match.params
        console.log(id)
        axios
            .post('https://localhost:44344/api/comment/project/', { ID: this.state.ID, AnswerType: this.state.AnswerType, Answer: this.state.Answer, Comment: this.state.Comment }, {
                headers: {
                    'content-type': 'application/json',
                    "Access-Control-Allow-Origin": "*"
                }
            })
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
                    <form onSubmit={this.submitHandler}>
                        <tr style={{ display: 'flex', justifyContent: 'center' }}>
                            <td style={{ width: 100 }}></td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}></td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}></td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", width: 150 }}>
                                <div>
                                    <input type='text' name='AnswerType' value={this.AnswerType} onChange={this.changeHandler} placeholder='Answer Type' style={{ width: 140 }} />
                                </div>
                            </td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", width: 100 }}>
                                <div>
                                    <input type='text' name='Answer' value={this.Answer} onChange={this.changeHandler} placeholder='Answer' style={{ width: 90 }} />
                                </div>
                            </td>
                            <td style={{ border: "1px solid rgb(0, 0, 0)", width: 1000 }}>
                                <div>
                                    <input type='text' name='Comment' value={this.Comment} onChange={this.changeHandler} placeholder='Comment' style={{ width: 990 }} />
                                </div>
                            </td>
                            <td style={{ width: 100 }}><button type='submit'>Submit </button></td>
                        </tr>
                    </form>
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

export default AssiComments
