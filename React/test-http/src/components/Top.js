import React, { Component } from 'react'
import axios from 'axios'
import TopInsides from './TopInsides'

class Top extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: '',
            N: '',
            Type: 'Top',
            IsProject: true,
            site: 'https://localhost:44344/api/Top/top',
            Submited: false,
            TopsClicked: false,
            ProjectsClicked: false,
            Backup: false


        }
    }

    changeHandler = (e) => {
        this.setState({ [e.target.name]: e.target.value })

    }

    Capitalize(str) {
        if (str.width > 1)
            return str.charAt(0).toUpperCase() + str.toLowerCase().toslice(1);
        return str
    }

    doSomething() {


        if (this.state.Submited === true) {
            axios
                .get(this.state.site + '/' + this.state.N + '/' + this.state.Type + '/' + this.state.IsProject)
                .then(response => {
                    console.log(response)
                    this.setState({ posts: response.data })
                    this.setState({ errorMsg: '' })
                    this.setState({ errorMsg2: '' })

                })
                .catch(error => {
                    console.log(error)
                    this.setState({ posts: [] })
                    this.setState({ errorMsg: 'Error retrieving data' })
                })
        }
    }

    submitHandler = (e) => {
        e.preventDefault()
        console.log('test')
        this.setState({ [e.target.name]: e.target.value })
        this.setState({ IsProject: this.state.IsProject })

        if (this.state.N < 1 || this.state.N > 300) {
            this.setState({ errorMsg2: ' Error in imput field 1. Provide possitive number (within reason)' })
        }
        this.setState({ Backup: this.state.IsProject })
        this.setState({ Submited: true }, () => { this.doSomething() })
    }

    onChangeValue(event) {
        this.setState({ Type: EventTarget.value })
    }
    changeColorIs() {
        this.setState({ ProjectsClicked: !this.state.ProjectsClicked })
    }

    changeColorType() {
        this.setState({ TopsClicked: !this.state.TopsClicked })
    }

    render() {
        let btn_classtype = this.state.TopsClicked ? "blackButton" : "whiteButton";
        let btn_classIs = this.state.ProjectsClicked ? "blackButton" : "whiteButton";
        let btn_classIs2 = this.state.ProjectsClicked ? "whiteButton" : "blackButton";
        let btn_classtype2 = this.state.TopsClicked ? "whiteButton" : "blackButton";
        const { posts, errorMsg, errorMsg2, N, } = this.state

        let message
        if (this.state.Submited === false) {
            message = <div>Please enter N,Top or Bottom and Projects or Reviewers</div>
        } else {
            console.log(this.state)
            message =
                <div style={{ textAlign: 'center' }}>
                    {TopInsides(posts, this.state.Backup)}
                </div>
        }


        return (

            <div style={{ border: 'outset', textAlign: 'center' }}>

                <div >
                    Top or Bottom:
                    <button
                        className={btn_classtype2}

                        title={"Top"}

                        onClick={() => {
                            this.setState({ Type: 'Top' });
                            if (this.state.TopsClicked === true) { this.setState({ TopsClicked: !this.state.TopsClicked }) }
                            console.log(this.state.Type + "Top")
                        }}
                        color="#841584"
                    >Top</button>

                    <button
                        className={btn_classtype}

                        title={"Bottom"}

                        onClick={() => {
                            this.setState({ Type: 'Bottom' });
                            if (this.state.TopsClicked === false) { this.setState({ TopsClicked: !this.state.TopsClicked }) }
                            console.log(this.state.Type + "BOTTOM")
                        }}
                        color="#841584"
                    >Bottom</button>

                </div>

                <div >
                    Projects or Reviewers:

                    <button
                        className={btn_classIs2}
                        title={"Projects"}

                        onClick={() => {
                            this.setState({ IsProject: 'true' });
                            if (this.state.ProjectsClicked === true) { this.setState({ ProjectsClicked: !this.state.ProjectsClicked }) }

                        }}
                        color="#841584"
                    >Projects</button>
                    <button
                        className={btn_classIs}
                        title={"Reviewers"}

                        onClick={() => {
                            this.setState({ IsProject: 'false' });
                            if (this.state.ProjectsClicked === false) { this.setState({ ProjectsClicked: !this.state.ProjectsClicked }) }
                            console.log(this.state)
                        }}
                        color="#841584"
                    >Reviewers</button>

                </div>

                <form onSubmit={this.submitHandler}>
                    <div>
                        <input type='text' name='N' value={N} onChange={this.changeHandler} placeholder='N' />
                    </div>
                    <button type='submit'>Submit </button>
                </form>
                <div>{message}</div>

                {errorMsg ? <div style={{ border: 'solid', borderColor: 'red' }} >{errorMsg}</div> : null}
                {errorMsg2 ? <div style={{ border: 'solid', borderColor: 'red' }} >{errorMsg2}</div> : null}

            </div>
        )
    }

}
export default Top
