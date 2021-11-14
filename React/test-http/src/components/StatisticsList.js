import React from 'react'


function StatisticsList({ post }) {

    return (
        <div>


            <div key={post.id} style={{ border: 'solid' }}>{post}


            </div>


        </div>
    )
}

export default StatisticsList
