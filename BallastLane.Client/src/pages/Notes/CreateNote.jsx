import React, { useState } from 'react'
import NotesForm from '../../components/NotesForm'
import { useLoaderData, useNavigate } from 'react-router-dom'
import { create } from "../../services/notesService"
import Error from '../../components/Error'

export async function loader({ params }) {
    console.log(params)
    return params;
}

const CreateNote = () => {
    const loaderData = useLoaderData();
    const navigate = useNavigate();
    const [errors, setErrors] = useState([]);

    const action = async (note) => {

        if (Object.values(note).includes('')) {
            setErrors([...errors,["You should Fill all the fields"]]);
            setTimeout(()=>{
                setErrors([])
            },2000)
            return;
        }

        const result = await create(note)
        console.log(result);
        navigate(`/user/${loaderData.userId}/notes`);
    }

    return (
        <>
            <div className='mt-10'>
                <div className="flex justify-end">
                    <button
                        onClick={() => navigate(-1)}
                        className="bg-orange-600 text-white px-3 py-1 font-bold uppercase rounded">Go back</button>
                </div>
                {errors?.length && errors.map((error, i) => <Error key={i}>{error}</Error>)}
                <NotesForm onSubmit={action} userId={loaderData?.userId} />

            </div>
        </>

    )
}

export default CreateNote