import React from 'react'
import Notes from "../../components/Notes"
import { useLoaderData, Link, useNavigate } from 'react-router-dom'
import { getUserWithNotes } from '../../services/userService'
import Info from '../../components/Info'


export async function loader({ params }) {
    const result = await getUserWithNotes(params.userId);
    return result;
}

const UserNotes = () => {
    const user = useLoaderData();
    const navigate = useNavigate();
    const goToNote = (noteId) => {
        navigate(`/notes/${noteId}/edit`)
    }
    return (

            <>

                <div className='grid grid-cols-4'>
                    <h1 className='font-black text-lg '>{user.name}`s Notes</h1>
                </div>
                <div className='grid grid-cols-4'>
                    <p className='font-normal text-md '>Here you can see the existing notes, click one of them if you want to edit it or delete it.</p>
                </div>
                <div className="flex justify-end">
                    <Link
                        to={`/notes/${user.id}/create`}
                        className="m-5 bg-blue-500 text-white px-4 py-2 rounded float-right mb-5">
                        Create Note
                    </Link>
                    <button
                        onClick={() => navigate("/")}
                        className="bg-orange-600 text-white px-3 py-1 font-bold uppercase rounded">Go back</button>
                </div>
                <div className='grid grid-cols-3 gap-4 mt-5'>
                    {user.notes.map((note, key) => (
                        <Notes key={key} title={note.title} text={note.text} id={note.id} onNoteClicked={goToNote} />
                    ))}
                </div>
                {user?.notes.length < 1 && (
                <div className='flex items-center'>
                    <Info children={{ title: `The user ${user.name} doesn't have any notes` }} />

                </div>
            )}
            </>

    )
}

export default UserNotes