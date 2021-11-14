import React from 'react'

export default function TopInsides(posts, IsProject) {
    let n = 0
    let message
    let toppings
  

        if(IsProject==='true'||IsProject===true){
            console.log(IsProject+"   IS TRUE")
            message=    posts.map(row => (
                
                    <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
                          <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.grade}</td>          
                         <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.assingmentName}</td>
                         <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n++ % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.assingmentID}</td>
                     
                     </tr>
              
                       ))
        
                       toppings=  <tr style={{ display: 'flex', justifyContent: 'center' }}>
                       <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Grade</td>
                      <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Assignment name</td>
                      <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Assignment ID</td>
                     
                  </tr>
        
         }else if(IsProject==='false'||IsProject===false){
            console.log(IsProject+"   IS FALSE")
            message=   posts.map(row => (
                
                <tr key={row.id} style={{ display: 'flex', justifyContent: 'center' }}>
                      <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n % 2) === 1 ? '#aae' : '#dde', width: 300 }}>{row.grade}</td>          
                 
                     <td style={{ border: "1px solid rgb(0, 0, 0)", backgroundColor: (n++ % 2) === 1 ? '#aae' : '#dde', width: 200 }}>{row.reviewerID}</td>
                 </tr>
          
                   ))
                toppings=  <tr style={{ display: 'flex', justifyContent: 'center' }}>
                <td style={{ border: "1px solid rgb(0, 0, 0)", width: 300 }}>Grade</td>
             
               <td style={{ border: "1px solid rgb(0, 0, 0)", width: 200 }}>Reviewer ID</td>
           </tr>
                
                }
             
                console.log(IsProject+"   IS IT THO PROJECT?")
            return (
                <div>
                    {toppings}
                   { message}
                </div>
            )


    }
   
    
