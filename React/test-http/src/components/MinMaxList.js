import React from 'react'


function MaxTest({ posts }) {
    var Min = 100;
    var Max = -1;
    var Maxid, Minid;
    console.log(posts)

    // posts.map((post)=>
    // console.log(post.answer)
    // //post.answer>Max ? {Max: post.answer} : post
    // //post.answer<Min ? {Min=post.answer,Minid=post.id} : post
    // )
    return (
        <div>
            hi
            {/* Max number is:{Max} Max id is: {Maxid} */}
            {/*  Minnumber is:{Min} Max id is: {Minid} */}
        </div>


    )


}


function MinMaxList({ post }) {

    return (
        <div>


            <div key={post.id} style={{ border: 'solid' }}>user: {post.id} for assingment:{post.name} with grade  {post.answer}



            </div>


        </div>
    )
}

export default MaxTest


