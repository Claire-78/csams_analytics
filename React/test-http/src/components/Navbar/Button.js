import React from "react";
import './Button.css'

const STYLES = [
    'btn--primary',
    'btn--outline'

]

export const Button = ({
    children,
    type,
    onclick,
    buttonStyle,
    buttonSize

}) => {
    const checkButtonStyle = STYLES.includes(buttonStyle) ? buttonStyle : STYLES[0]

    return (
        <button className={`btn ${checkButtonStyle} ${buttonStyle}`}
            onClick={onclick} type={type}>

            {children}
        </button>
    )


}


