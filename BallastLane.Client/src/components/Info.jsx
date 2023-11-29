import React from 'react'
import sorry from "../assets/sorry.png"

const Info = ({children}) => {
    const {title, description}= children;

    return (
        <>
            <div className="max-w-sm rounded overflow-hidden shadow-lg center">
                <img className="w-full" src={sorry}/>
                    <div className="px-6 py-4">
                        <div className="font-bold text-xl mb-2">{title}</div>
                        <p className="text-gray-700 text-base">
                            {description}
                        </p>
                    </div>
            </div>
        </>
    )}
export default Info

