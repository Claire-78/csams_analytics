import React from 'react'
import { Boxplot, computeBoxplotStats } from 'react-boxplot'

const ShowBoxplot = (values) => {
    const stats = computeBoxplotStats(values)
    return (


        <div>
            <Boxplot
                width={6000}
                height={200}
                orientation="horizontal"
                min={0}
                max={100}
                stats={stats}
            />
        </div>

    )

}

export default ShowBoxplot