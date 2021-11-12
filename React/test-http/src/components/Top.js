import React, { Component } from 'react'
import axios from 'axios'
import { Button} from 'react-bootstrap';
import ReactDOM from 'react-dom';
class Top extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: '',
            N:'',
            Type:'',
            IsProject:'',
            site:'https://localhost:44344/api/Top/top',
            Submited:false
        }
    }
  
    changeHandler=(e)=>{
        this.setState({[e.target.name]:e.target.value})
        
        }
       
        Capitalize(str){
            if(str.width>1)
            return str.charAt(0).toUpperCase() + str.toLowerCase().toslice(1); 
            return str
            }

doSomething(){
   // this.forceUpdate()
            console.log(this.state)
           
           
            axios
                .get(this.state.site)
                .then(response => {
                    console.log(response)
                    this.setState({ posts: response.data })
                    this.setState({site:'https://localhost:44344/api/Top/top'})
                })
                .catch(error => {
                    console.log(error)
                    this.setState({ errorMsg: 'Error retrieving data' })
                })
               // this.setState({Submited:false})
           }
        

        submitHandler = (e) => {
            this.setState({[e.target.name]:e.target.value})
            this.forceUpdate()

            this.setState({Type:this.Capitalize(this.state.Type)})
            this.setState({Type:this.Capitalize(this.state.IsProject)})     
            if(this.state.N<1||this.state.N>300){
                this.setState({ errorMsg2: ' Error in imput field 1. Provide possitive number (within reason)' })
            }
            this.setState({Type:this.Capitalize(this.state.Type)})
            if(this.state.Type!=='Top'||this.state.Type!=='Bottom'){
                this.setState({ errorMsg2: ' Error in imput field 2' })
            }
            this.setState({IsProject:this.Capitalize(this.state.IsProject)})
            console.log(this.state+" WTF!!!")
            if(this.state.IsProject==='Projects' || this.Capitalize(this.state.IsProject)==='True'){
                this.setState({IsProject:'true'})
            }else if(this.state.IsProject==='Reviewers' || this.Capitalize(this.state.IsProject)==='False'){
                this.setState({IsProject:'false'})
            }
            else{
                this.setState({ errorMsg2: ' Error in imput field 3' })
            }
            this.setState({site:this.state.site+'/'+this.state.N+'/'+this.state.Type+'/'+this.state.IsProject})
          this.setState({Submited:true})
          
            e.preventDefault()
            this.doSomething()
 
        }
    //clickHandler() { }
   
    render() {
        const { posts, errorMsg,errorMsg2,N,Type,IsProject } = this.state
        let n = 0

        let message
        if(this.state.Submited===false){
            message=<div>Please enter N,Top or Bottom and Projects or Reviewers</div>
        } else{
            console.log(this.state)
        message=  <div style={{ textAlign: 'center' }}>
    <tr style={{ display: 'flex', justifyContent: 'center' }}>
      <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Grade</td>
     <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Assignment name</td>
     <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Assignment ID</td>
     <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Reviewer ID</td>

</tr>

{posts.map(row => (
    
    <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.grade}</td>
        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.assingmentName}</td>
        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.assingmentID}</td>
        <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.reviewerID}</td>
    </tr>
))}

{errorMsg ? <div>{errorMsg}</div> : null}
{errorMsg2 ? <div>{errorMsg2}</div> : null}


</div>
        }


        return (

            <div style={{border: 'outset',textAlign:'center'}}>
           
           
           <View style={styles.buttonStyleContainer}>
            <Button
             title={"Top"}
             style={styles.buttonStyle}
             onPress={() => {
               this.setState({ IsProject: Top });
             }}
              color="#841584"
            />
              <Button
                 title={"Bottom"}
                onPress={() => {
                this.setState({ IsProject: Bottom });
             }}
             color="green"
           />

         </View>
           
            <form onSubmit={this.submitHandler}>
                <div>
                    <input type='text' name='N' value={N} onChange={this.changeHandler} placeholder='N'/>
                </div>
                <div>
                    <input type='text' name='Type' value={Type}  onChange={this.changeHandler} placeholder='Enter:Top or Bottom'/>
                </div>
                <div>
                    <input type='text' name='IsProject' value={IsProject}  onChange={this.changeHandler} placeholder='Groupby: Projects or Reviewers'/>
                </div>
                <button type='submit'>Submit </button>
            </form>
            <div>{message}</div>
        <div>Here???</div>
           
          
        </div>
        )
    }

}
export default Top
