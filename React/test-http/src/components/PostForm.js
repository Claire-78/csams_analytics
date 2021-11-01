import React, { Component } from 'react'
import axios from 'axios'
 class PostForm extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             id:'',
             role:''
        }
    }
    
changeHandler=(e)=>{
    this.setState({[e.target.name]:e.target.value})
}

submitHandler=(e)=>{
    e.preventDefault()
    console.log(this.state)
   
 
    axios.post('https://localhost:44344/api/sample/user',this.state)
    .then(Response=> {
        console.log(Response)
    })
    .catch(error=>{
        console.log(error)
    })


  
  


}
    render() {
        const{id,role}=this.state
        return (
            <div style={{border: 'outset',textAlign:'center'}}>
                <form onSubmit={this.submitHandler}>
                    <div>
                        <input type='text' name='id' value={id} onChange={this.changeHandler} placeholder='ID'/>
                    </div>
                    <div>
                        <input type='text' name='role' value={role}  onChange={this.changeHandler} placeholder='RoleID'/>
                    </div>
                   
                    <button type='submit'>Submit </button>
                </form>
            </div>
        )
    }
}

export default PostForm
