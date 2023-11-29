import React, { useState } from 'react'

const Notes = ({ title, text, id, onNoteClicked }) => {


    return (
        <>
            <div onClick={() => { onNoteClicked(id) }} className="max-w-sm rounded overflow-hidden shadow-lg m-5 mt-10 hover:cursor-pointer hover:bg-gray-100">
                <div className="px-6 py-4">
                    <div className="font-bold text-xl mb-2">{title}</div>
                    <p className=" text-base">
                        {text}
                    </p>
                </div>
            </div>
        </>
    )
}

export default Notes