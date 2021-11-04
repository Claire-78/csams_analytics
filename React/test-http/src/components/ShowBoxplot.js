import React, { Component } from 'react'
import { Boxplot, computeBoxplotStats } from 'react-boxplot'

//These values are only for testing purposes
const values = [
    14,
    15,
    16,
    16,
    17,
    17,
    17,
    17,
    17,
    18,
    18,
    18,
    18,
    18,
    18,
    19,
    19,
    19,
    20,
    20,
    20,
    20,
    20,
    20,
    21,
    21,
    22,
    23,
    24,
    24,
    29,
]

const ShowBoxplot = () => (
    <Boxplot
        width={400}
        height={20}
        orientation="horizontal"
        min={0}
        max={30}
        stats={computeBoxplotStats(values)}
    />
)

export default ShowBoxplot