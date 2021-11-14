import React from 'react'
import { Boxplot, computeBoxplotStats } from 'react-boxplot'
import StatisticsList from './StatisticsList'
console.log("You have gotten to the right page")

//These values are only for testing purposes
const values =
    [88,
        30,
        68,
        53,
        36,
        42,
        66,
        26,
        15,
        64,
        76,
        29,
        78,
        77,
        22,
        33,
        65,
        62,
        10,
        61,
        60,
        43,
        49,
        18,
        74,
        50,
        82,
        35,
        100,
        1
    ]

const ShowBoxplot = () => {
    // const values = int(statslist)
    const stats = computeBoxplotStats(values)
    return (


        <div>
            <h1>
                Boxplot
            </h1>
            <Boxplot
                width={600}
                height={300}
                orientation="horizontal"
                min={0}
                max={100}
                stats={stats}
            />
        </div>

    )

}

export default ShowBoxplot