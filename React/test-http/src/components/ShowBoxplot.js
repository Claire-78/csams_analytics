import React from 'react'
import { Boxplot, computeBoxplotStats } from 'react-boxplot'
console.log("You have gotten to the right page")
//These values are only for testing purposes

const ShowBoxplot = ({ values }) => {
    const stats = computeBoxplotStats(values)
    return (

        <div>
            <Boxplot
                width={400}
                height={40}
                orientation="horizontal"
                min={0}
                max={30}
                stats={stats}
            />
        </div>
    )

}

export default ShowBoxplot