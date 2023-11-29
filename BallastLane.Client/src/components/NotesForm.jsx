import React, { useEffect, useState } from 'react'

const NotesForm = ({ note, onSubmit, userId, onDelete }) => {
    const [noteData, setNote] = useState({
        title: "",
        text: "",
        userId: userId,
        id: 0
    });

    useEffect(() => {
        if (note) {
            setNote(note);
        }
    }, [note?.id])


    const handleOnChange = (event) => {
        setNote({ ...noteData, [event.target.name]: event.target.value })
    }

    return (
        <>
            <div className="mb-4">
                <label className='text-gray-800' htmlFor='name'>Title</label>
                <input
                    type="text"
                    name="title"
                    id="title"
                    value={noteData?.title}
                    className="mt-2 block w-full p-3 bg-gray-200"
                    onChange={handleOnChange}
                />
            </div>

            <div className="mb-4">
                <label className='text-gray-800' htmlFor='lastName'>Text</label>
                <textarea
                    type="text"
                    name="text"
                    id="text"
                    value={noteData?.text}
                    onChange={handleOnChange}
                    className="mt-2 block w-full p-3 bg-gray-200"></textarea>
            </div>

            <button className="mt-5 w-full bg-blue-800 p-3 uppercase text-white text-lg rounded" onClick={() => { onSubmit(noteData) }}>Submit</button>
            
            {(note?.id > 0) && (
                <button className="mt-5 w-full bg-red-600 p-3 uppercase text-white text-lg rounded" onClick={() => { if (confirm("Are you sure you want to delete this note?")) { onDelete(noteData) } }}>Delete</button>
            )}
        </>
    )
}

export default NotesForm