import React from 'react'
import { Boxplot, computeBoxplotStats } from 'react-boxplot'
console.log("You have gotten to the right page")

// Values for testing purpose only
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
    // backend return array with strings
    // min, max, mean, median, Q1, Q3, SD
    // min = whiskerlow, max = whiskerhigh, Q1 = quartile1, Q3 = quartile3, median = quartile3

    // temp
    const stats = computeBoxplotStats(values)

    // const statlist = int(values)
    // statlist[0] etc
    return (


        <div>
            <Boxplot
                width={600}
                height={300}
                orientation="horizontal"
                min={0}
                max={100}
                stats={stats}
            /* stats={{
                whiskerLow: 1,
                quartile1: 1,
                quartile2: 3,
                quartile3: 4,
                whiskerHigh: 5,
                outliers: [],
            }} */
            />
        </div>

    )

}

export default ShowBoxplot