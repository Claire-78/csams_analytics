import React, { Component } from 'react'
import axios from 'axios'

class Top extends Component {
    constructor(props) {
        super(props)

        this.state = {
            posts: [],
            errorMsg: '',
            N:'',
            Type:'Top',
            IsProject:false,
            site:'https://localhost:44344/api/Top/top',
            Submited:false,
            TopsClicked:false,
           ProjectsClicked:false,
          
         
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
      
            console.log(this.state)
           
           if(this.state.Submited===true){
            axios
                .get(this.state.site+'/'+this.state.N+'/'+this.state.Type+'/'+this.state.IsProject)
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
        }
           
        submitHandler = (e) => {
            this.setState({[e.target.name]:e.target.value})
            
   
            if(this.state.N<1||this.state.N>300){
                this.setState({ errorMsg2: ' Error in imput field 1. Provide possitive number (within reason)' })
            }
         
            this.setState({Submited:true},()=>{ this.doSomething()})
           // this.setState({site:this.state.site+'/'+this.state.N+'/'+this.state.Type+'/'+this.state.IsProject},()=>{ this.doSomething()})
          
           
            e.preventDefault()
           // this.doSomething()
          
 
        }
    //clickHandler() { }
   
        onChangeValue(event){
            this.setState({Type:EventTarget.value})
            console.log(this.state)
        }
        changeColorIs(){
            this.setState({ProjectsClicked: !this.state.ProjectsClicked})
        }

        changeColorType(){
            this.setState({TopsClicked: !this.state.TopsClicked})
            console.log(this.state+"COLOR CHANGE!!")
        }

    render() {
        let btn_classtype = this.state.TopsClicked ? "blackButton" : "whiteButton";
        let btn_classIs = this.state.ProjectsClicked ? "blackButton" : "whiteButton";
        let btn_classIs2 = this.state.ProjectsClicked ? "whiteButton" : "blackButton" ;
        let btn_classtype2 = this.state.TopsClicked ? "whiteButton" : "blackButton" ;
        const { posts, errorMsg,errorMsg2,N,Type,IsProject } = this.state
        let n = 0

        let message
        if(this.state.Submited===false){
            message=<div>Please enter N,Top or Bottom and Projects or Reviewers</div>
        } else {
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
           
           
           <div >
               Top or Bottom:

               
               <button 
            className={btn_classtype2}
     
             title={"Top"}
           
             onClick={() => {
               this.setState({ Type: 'Top' });
              // this.setState({TopClicked:false });
              this.setState({TopsClicked: !this.state.TopsClicked})
               console.log(this.state.TopsClicked +"Top")
             }}
              color="#841584"
            >Top</button>

         <button 
            className={btn_classtype}
     
             title={"Bottom"}
           
             onClick={() => {
               this.setState({ Type: 'Bottom' });
              // this.setState({TopClicked:false });
              this.setState({TopsClicked: !this.state.TopsClicked})
               console.log(this.state.TopsClicked +"BOTTOM")
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
              // this.setState({ProjectsClicked:true });
               this.setState({ProjectsClicked: !this.state.ProjectsClicked})
             }}
              color="#841584"
            >Projects</button>
         <button
           className={btn_classIs}
             title={"Reviewers"}
           
             onClick={() => {
               this.setState({IsProject:'false' });
             //  this.setState({ProjectsClicked:false });
               this.setState({ProjectsClicked: !this.state.ProjectsClicked})
               console.log(this.state)
             }}
              color="#841584"
            >Reviewers</button>
    
      </div>
           
            <form onSubmit={this.submitHandler}>
                <div>
                    <input type='text' name='N' value={N} onChange={this.changeHandler} placeholder='N'/>
                </div>
                {/* <div>
                    <input type='text' name='Type' value={Type}  onChange={this.changeHandler} placeholder='Enter:Top or Bottom'/>
                </div>
                <div>
                    <input type='text' name='IsProject' value={IsProject}  onChange={this.changeHandler} placeholder='Groupby: Projects or Reviewers'/>
                </div> */}
                <button type='submit'>Submit </button>
            </form>
            <div>{message}</div>
        <div>Here???</div>
           
          
        </div>
        )
    }

}
export default Top
