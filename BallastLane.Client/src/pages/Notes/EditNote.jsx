import React from 'react'
import NotesForm from '../../components/NotesForm';
import { useLoaderData, useNavigate } from 'react-router-dom';
import { getById, update, remove } from '../../services/notesService';

export async function loader({ params }) {
  const result = await getById(params.noteId);
  return result;
}

const EditNote = () => {
  const navigate = useNavigate();
  const action = async (note) => {
    console.log(note)
    const result = await update(note);
    navigate(`/user/${note.userId}/notes`);
  }

  const onDelete = async (note) => {
    console.log(note)
    const result = await remove(note.id);
    console.log(result)
    navigate(`/user/${note.userId}/notes`);
  }

  const loaderData = useLoaderData();
  console.log(loaderData)
  return (
    <>
      <div className='mt-10'>
        <div className="flex justify-end">
          <button
            onClick={() => navigate(`/user/${loaderData.userId}/notes`)}
            className="bg-orange-600 text-white px-3 py-1 font-bold uppercase rounded">Go back</button>
        </div>
        <NotesForm onSubmit={action} note={loaderData} onDelete={onDelete} />
      </div>
    </>

  )
}

export default EditNote