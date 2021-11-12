import React, { Component } from 'react'
import axios from 'axios'

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
            Submited:false,
            TopsClicked:false,
            BottomsClicked:false,
           ProjectsClicked:false,
           ReviewersClicked:false
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
        this.forceUpdate()
            console.log(this.state)
           
           if(this.state.Submited===true){
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
        }
           dosomethingmore(){
            this.setState({site:this.state.site+'/'+this.state.N+'/'+this.state.Type+'/'+this.state.IsProject})
            this.setState({Submited:true})

            }
        submitHandler = (e) => {
            this.setState({[e.target.name]:e.target.value})
            

            this.setState({Type:this.Capitalize(this.state.Type)})
            this.setState({Type:this.Capitalize(this.state.IsProject)})     
            if(this.state.N<1||this.state.N>300){
                this.setState({ errorMsg2: ' Error in imput field 1. Provide possitive number (within reason)' })
            }
            // this.setState({Type:this.Capitalize(this.state.Type)})
            // if(this.state.Type!=='Top'||this.state.Type!=='Bottom'){
            //     this.setState({ errorMsg2: ' Error in imput field 2' })
            // }
            // this.setState({IsProject:this.Capitalize(this.state.IsProject)})
        
            // if(this.state.IsProject==='Projects' || this.Capitalize(this.state.IsProject)==='True'){
            //     this.setState({IsProject:'true'})
            // }else if(this.state.IsProject==='Reviewers' || this.Capitalize(this.state.IsProject)==='False'){
            //     this.setState({IsProject:'false'})
            // }
            // else{
            //     this.setState({ errorMsg2: ' Error in imput field 3' })
            // }
           // this.setState({site:this.state.site+'/'+this.state.N+'/'+this.state.Type+'/'+this.state.IsProject})
         // this.setState({Submited:true})
             this.dosomethingmore()
            e.preventDefault()
            this.doSomething()
            this.forceUpdate()
 
        }
    //clickHandler() { }
   
        onChangeValue(event){
            this.setState({Type:EventTarget.value})
            console.log(this.state)
        }


    render() {
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
             title={"Top"}
           
             onClick={() => {
               this.setState({ Type: 'Top' });
               this.setState({TopClicked:true });
             }}
              color="#841584"
              
            >Top</button>
         <button
             title={"Bottom"}
           
             onClick={() => {
               this.setState({ Type: 'Bottom' });
               this.setState({BottomClicked:true });
               console.log(this.state)
             }}
              color="#841584"
            >Bottom</button>
    
      </div>

      <div >
               Projects or Reviewers:

               
               <button
             title={"Projects"}
           
             onClick={() => {
               this.setState({ IsProject: 'true' });
               this.setState({ProjectsClicked:true });
             }}
              color="#841584"
            >Projects</button>
         <button
             title={"Reviewers"}
           
             onClick={() => {
               this.setState({IsProject:'false' });
               this.setState({ReviewersClicked:true });
               console.log(this.state)
             }}
              color="#841584"
            >Reviewers</button>
    
      </div>
           
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
